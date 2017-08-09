using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Tremor.Items;

namespace Tremor.NPCs
{
	// TODO: fix Motherboard despawn on first hit
	// TODO: motherboard does not spawn in MP
	// TODO: rewrite this thing, lol
	[AutoloadBossHead]
	public class Motherboard : ModNPC
	{
		#region "Константы"

		private const int StateOneFollowPlayerTime = 120; // Time of following player in 1st stage
		private const int StateOneDisappearingTime = 30; // Time of disappearing in 1st stage
		private const int StateOneAppearingTime = 30; // Time of appearing in 1st stage
		private const int StateSecondFollowPlayerTime = 90; // Time of following player in 2nd stage
		private const int StateSecondDisappearingTime = 30; //Time of disappearing in 2nd stage
		private const int StateSecondAppearingTime = 30; // Time of appearing in 2nd stage
		private const int MaxDrones = 20; // Maximum amount of Drones
		private const int DronSpawnAreaX = 300; // Area size in which Drone can spawn by X value
		private const int DronSpawnAreaY = 300; // Area size in which Drone can spawn by Y value
		private const int StartDronCount = 8; // Initial amount of Drones
		private const int ShootRate = 150; // Fire rate in ticks
		private const int LaserDamage = 40; // Laser damage
		private const float LaserKb = 1; // Laser knockback
		private const int LaserYOffset = 95; // Laser spawn offset by Y value
		private const int TimeToLaserRate = 3; // Fire rate (From drones to player)
		private const int LaserType = ProjectileID.ShadowBeamHostile; // Laser type
		private const int AnimationRate = 6; // Animation rate
		private const int SecondShootCount = 3;
		private const float SecondShootSpeed = 15f;
		private const int SecondShootDamage = 30;
		private const float SecondShootKn = 1.0f;
		private const int SecondShootRate = 60;
		private const int SecondShootSpread = 65;
		private const float SecondShootSpreadMult = 0.05f;
		#endregion

		#region "Переменные"

		private int _appearTime;
		private bool _firstAi = true; // Is it the first time when AI method is called?
		private bool _firstState = true; // Is it 1st stage?
		private List<int> _signalDrones = new List<int>(); // ID of Signal Drones
		private int _lastSignalDron = -1; // Last Drone 
		private int _stateTime = StateOneAppearingTime + StateOneDisappearingTime + StateOneFollowPlayerTime; // Stage time
		private bool _shootNow; // Does the Motherboard shoots right now?
		private int _timeToNextDrone = 1; // Time for spawning next Drone
		private int _timeToShoot = 60; // Time for next shoot
		private int _timeToLaser = 3; // Time for next shoot (Drones lasers)
		private int _currentFrame; // Current frame
		private int _timeToAnimation = 6; // Animation rate
		private List<int> _clampers = new List<int>(); // Clampers list
		private int _secondShootTime = 60;
		private int _ai = 0;

		private int GetStateTime => GetAppearingTimeNow + GetDisappearingTimeNow + GetFollowPlayerTimeNow;
		//-----
		// Get time needed for full cycle of changing states 
		private int GetTimeToNextDrone => (Main.rand.Next(3, 6) * 60);
		// Get time for spawning next Drone

		//----- Methods of getting times of states at the moment
		private int GetFollowPlayerTimeNow => (_firstState) ? StateOneFollowPlayerTime : StateSecondFollowPlayerTime;
		private int GetDisappearingTimeNow => (_firstState) ? StateOneDisappearingTime : StateSecondDisappearingTime;
		private int GetAppearingTimeNow => (_firstState) ? StateOneAppearingTime : StateSecondAppearingTime;
		//-----
		#endregion

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Motherboard");
			Main.npcFrameCount[npc.type] = 6;

			NPCID.Sets.MustAlwaysDraw[npc.type] = true;
			NPCID.Sets.NeedsExpertScaling[npc.type] = true;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 45000;
			npc.damage = 30;
			npc.knockBackResist = 0f;
			npc.defense = 70;
			npc.width = 170;
			npc.height = 160;
			npc.aiStyle = 2; // -1
			npc.npcSlots = 50f;
			music = MusicID.Boss3;

			npc.dontTakeDamage = true;
			npc.noTileCollide = true;
			npc.noGravity = true;
			npc.boss = true;
			npc.lavaImmune = true;

			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath10;

			bossBag = mod.ItemType<MotherboardBag>();
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}

		public override bool UsesPartyHat() => false;

		// ?? Doesn't seem to fix much
		public override void SendExtraAI(BinaryWriter writer)
		{
			writer.Write(_appearTime);
			writer.Write(_firstAi);
			writer.Write(_firstState);
			writer.Write(_signalDrones.Count);
			foreach (int drone in _signalDrones)
			{
				writer.Write(drone);
			}
			writer.Write(_lastSignalDron);
			writer.Write(_shootNow);
			writer.Write(_timeToNextDrone);
			writer.Write(_timeToShoot);
			writer.Write(_timeToLaser);
			writer.Write(_currentFrame);
			writer.Write(_timeToAnimation);
			writer.Write(_clampers.Count);
			foreach (int clamper in _clampers)
			{
				writer.Write(clamper);
			}
			writer.Write(_secondShootTime);
			writer.Write(_ai);
		}

		public override void ReceiveExtraAI(BinaryReader reader)
		{
			_appearTime = reader.ReadInt32();
			_firstAi = reader.ReadBoolean();
			_firstState = reader.ReadBoolean();
			int c = reader.ReadInt32();
			_signalDrones = new List<int>();
			for (int i = 0; i < c; i++)
			{
				_signalDrones[i] = reader.ReadInt32();
			}
			_lastSignalDron = reader.ReadInt32();
			_shootNow = reader.ReadBoolean();
			_timeToNextDrone = reader.ReadInt32();
			_timeToShoot = reader.ReadInt32();
			_timeToLaser = reader.ReadInt32();
			_currentFrame = reader.ReadInt32();
			_timeToAnimation = reader.ReadInt32();
			c = reader.ReadInt32();
			for (int i = 0; i < c; i++)
			{
				_clampers[i] = reader.ReadInt32();
			}
			_secondShootTime = reader.ReadInt32();
			_ai = reader.ReadInt32();
		}

		private void Teleport()
		{
			npc.aiStyle = 2;
			npc.position += npc.velocity * 2;
		}

		public override void AI()
		{
			Animation();
			if (Helper.GetNearestPlayer(npc.position, true) == -1 || Main.dayTime)
			{
				npc.aiStyle = 11;
				npc.damage = 1000;
				npc.ai[0] = 2;
			}
			if (npc.aiStyle == 11)
			{
				npc.rotation = 0;
				return;
			}
			if (_firstAi)
			{
				_firstAi = false;
				for (int i = 0; i < ((StartDronCount <= 0) ? 1 : StartDronCount); i++)
				{
					Vector2 spawnPosition = Helper.RandomPointInArea(new Vector2(npc.Center.X - DronSpawnAreaX / 2, npc.Center.Y - DronSpawnAreaY / 2), new Vector2(npc.Center.X + DronSpawnAreaX / 2, npc.Center.Y + DronSpawnAreaY / 2));
					_signalDrones.Add(NPC.NewNPC((int)spawnPosition.X, (int)spawnPosition.Y, mod.NPCType("SignalDron"), 0, 0, 0, 0, npc.whoAmI));
				}
			}
			ChangeAi();
			if (_firstState)
			{
				Main.npcHeadBossTexture[NPCID.Sets.BossHeadTextures[npc.type]] = mod.GetTexture("NPCs/Motherboard_Head_Boss");
				Drones();
				npc.dontTakeDamage = true;
			}
			else
			{
				Main.npcHeadBossTexture[NPCID.Sets.BossHeadTextures[npc.type]] = mod.GetTexture("NPCs/Motherboard_Head_Boss2");
				Teleport();
				if (_ai == 1)
				{
					npc.TargetClosest(true);
					Vector2 vector142 = new Vector2(npc.Center.X, npc.Center.Y);
					float num1243 = Main.player[npc.target].Center.X - vector142.X;
					float num1244 = Main.player[npc.target].Center.Y - vector142.Y;
					float num1245 = (float)Math.Sqrt(num1243 * num1243 + num1244 * num1244);
					if (npc.ai[1] == 0f)
					{
						if (Main.netMode != 1)
						{
							npc.localAI[1] += 1f;
							if (npc.localAI[1] >= 120 + Main.rand.Next(200))
							{
								npc.localAI[1] = 0f;
								npc.TargetClosest(true);
								int num1249 = 0;
								int num1250;
								int num1251;
								while (true)
								{
									num1249++;
									num1250 = (int)Main.player[npc.target].Center.X / 16;
									num1251 = (int)Main.player[npc.target].Center.Y / 16;
									num1250 += Main.rand.Next(-50, 51);
									num1251 += Main.rand.Next(-50, 51);
									if (!WorldGen.SolidTile(num1250, num1251) && Collision.CanHit(new Vector2(num1250 * 16, num1251 * 16), 1, 1, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
									{
										break;
									}
									if (num1249 > 100)
									{
										return;
									}
								}
								npc.ai[1] = 1f;
								npc.ai[2] = num1250;
								npc.ai[3] = num1251;
								npc.netUpdate = true;
								return;
							}
						}
					}
					else if (npc.ai[1] == 1f)
					{
						npc.alpha += 3;
						if (npc.alpha >= 255)
						{
							npc.alpha = 255;
							npc.position.X = npc.ai[2] * 16f - npc.width / 2;
							npc.position.Y = npc.ai[3] * 16f - npc.height / 2;
							npc.ai[1] = 2f;
							return;
						}
					}
					else if (npc.ai[1] == 2f)
					{
						npc.alpha -= 3;
						if (npc.alpha <= 0)
						{
							npc.alpha = 0;
							npc.ai[1] = 0f;
							return;
						}
					}
				}
				CheckClampers();
				SecondShoot();
				npc.dontTakeDamage = false;
				return;
			}
			ChangeStady();
		}

		private void Animation()
		{
			if (--_timeToAnimation <= 0)
			{

				if (++_currentFrame > 3)
					_currentFrame = 1;
				_timeToAnimation = AnimationRate;
				npc.frame = GetFrame(_currentFrame + ((_firstState) ? 0 : 3));
			}
		}

		private Rectangle GetFrame(int number)
		{
			return new Rectangle(0, npc.frame.Height * (number - 1), npc.frame.Width, npc.frame.Height);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MotherboardGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MotherboardGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MotherboardGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MotherboardGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MotherboardGore4"), 1f);
			}
		}

		private void SecondShoot()
		{
			for (int i = (int)npc.position.X - 8; i < (npc.position.X + 8 + npc.width); i += 8)
				for (int l = (int)npc.Center.Y + 90; l < (npc.Center.Y + 106); l += 8)
					if (WorldGen.SolidTile(i / 16, l / 16))
						return;
			if (--_secondShootTime <= 0)
			{
				_secondShootTime = SecondShootRate;
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y + 95, 0, 0, mod.ProjectileType("projMotherboardSuperLaser"), SecondShootDamage, SecondShootKn, 0, npc.whoAmI, 0);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y + 95, 0, 0, mod.ProjectileType("projMotherboardSuperLaser"), SecondShootDamage, SecondShootKn, 0, npc.whoAmI, 1);
			}
		}

		private void ChangeStady() // Trying change stage
		{
			CheckDrones(); // Checking for Drones
			if (_signalDrones.Count <= 0) // If there are no Drones alive
			{
				_firstState = false; // Toggling off 1st Stage
				_clampers = new List<int>
				{
					NPC.NewNPC((int) npc.Center.X - 15, (int) npc.Center.Y + 25, mod.NPCType("Clamper"), 0, 0, 0, 0, npc.whoAmI),
					NPC.NewNPC((int) npc.Center.X - 10, (int) npc.Center.Y + 25, mod.NPCType("Clamper"), 0, 0, 0, 0, npc.whoAmI),
					NPC.NewNPC((int) npc.Center.X + 10, (int) npc.Center.Y + 25, mod.NPCType("Clamper"), 0, 0, 0, 0, npc.whoAmI),
					NPC.NewNPC((int) npc.Center.X + 15, (int) npc.Center.Y + 25, mod.NPCType("Clamper"), 0, 0, 0, 0, npc.whoAmI)
				};
				Main.npc[_clampers[0]].localAI[1] = 1;
				Main.npc[_clampers[1]].localAI[1] = 2;
				Main.npc[_clampers[2]].localAI[1] = 3;
				Main.npc[_clampers[3]].localAI[1] = 4;
			}
		}

		private void ChangeAi() // Changes state (Following/disappearing/appearing)
		{
			if (_firstState)
			{
				--_stateTime; // Lowering states time
				if (_stateTime <= 0) // If state time < or = 0 then update a variable
					_stateTime = GetStateTime; // Updating
				for (int i = 0; i < _clampers.Count; i++)
					Main.npc[_clampers[i]].ai[2] = 1;
				if (_stateTime <= GetAppearingTimeNow) // If it is appearing state
				{
					npc.ai[0] = -3; // Then appear
					return; // Ending the method
				}
				if (_stateTime <= GetAppearingTimeNow + GetDisappearingTimeNow) // If it is disappearing state
				{
					npc.ai[0] = -2; // Then disappear
					return; // Ending the method
				}
			}
			// This will toggle if only it is following state
			if (npc.ai[0] == -2)
				_appearTime = GetAppearingTimeNow;
			if (--_appearTime > 0)
			{
				npc.ai[0] = -3;
				return;
			}
			npc.ai[0] = -1; // Follow the player
		}

		private void CheckClampers()
		{
			for (int index = 0; index < _clampers.Count; index++) // Passing through each element of array with ID of clampers
				if (!Main.npc[_clampers[index]].active || Main.npc[_clampers[index]].type != mod.NPCType("Clamper")) // If
																													 // NPC with ID from array isn't a Clamper or is dead then...
				{
					_clampers.RemoveAt(index); // Remove ID of this NPC from Clamper list
					--index; // Lowering index by 1 in order not to miss 1 element in array of IDs
				}
			foreach (int ID in _clampers)
			{
				int id = Projectile.NewProjectile(npc.Center.X, npc.Center.Y + LaserYOffset, 0, 0, mod.ProjectileType("projClamperLaser"), LaserDamage, LaserKb, 0, npc.whoAmI, ID);
				Main.projectile[id].localAI[1] = _stateTime;
			}
		}

		private void Drones() // Drones in 1st Stage
		{
			CheckDrones(); // Removes dead Drones from the listУдаляет из списка всех мёртвых дронов
			SpawnDrones(); // Spawns Drones
			ShootDrones(); // Shoots lasers 
		}

		private void CheckDrones() // Removes all dead Drones from the list
		{
			for (int index = 0; index < _signalDrones.Count; index++) // Passing through each element of array with ID of clampers
				if (!Main.npc[_signalDrones[index]].active || Main.npc[_signalDrones[index]].type != mod.NPCType("SignalDron")) // If
																																// NPC with ID from array isn't a Drone or is dead then...
				{
					_signalDrones.RemoveAt(index); // Remove ID of this NPC from Drones list
					--index; // Lowering index by 1 in order not to miss 1 element in array of IDs
				}
		}

		private void SpawnDrones() // If it is time to spawn a Drone
		{
			if (_signalDrones.Count >= MaxDrones) // If the current amount of Drones = or > maximum amount of drones then...
				return; // End the method
			if (--_timeToNextDrone <= 0) // Lowering the time of spawning next Drone. If the time < or = 0 then...
			{
				_timeToNextDrone = GetTimeToNextDrone; // Setting new time of spawning Drones
				Vector2 spawnPosition = Helper.RandomPointInArea(new Vector2(npc.Center.X - DronSpawnAreaX / 2, npc.Center.Y - DronSpawnAreaY / 2), new Vector2(npc.Center.X + DronSpawnAreaX / 2, npc.Center.Y + DronSpawnAreaY / 2));
				// Defining random position around the boss (Via Helper) and write it into Var 01
				_signalDrones.Add(NPC.NewNPC((int)spawnPosition.X, (int)spawnPosition.Y + LaserYOffset, mod.NPCType("SignalDron"), 0, 0, 0, 0, npc.whoAmI));
				// Spawning Drone with coordinates from Var 01 and with ID in ai[3]
			}
		}

		private void ShootDrones() // If it is time to shoot
		{
			if (_signalDrones.Count <= 0) // If there're no Drones then...
				return; // Ending the method
			if (--_timeToShoot <= 0 || _shootNow) // If it is time to shoot or if the boss is already shooting then...
			{
				if (_lastSignalDron == -1 && npc.ai[0] != -1)
					return;
				_timeToShoot = ShootRate; // Setting new shoot time
				_shootNow = true; // Shooting
				if (--_timeToLaser <= 0) // If it is time to shoot Drones lasers then...
				{
					_timeToLaser = TimeToLaserRate; // Set new shoot time
					if (_lastSignalDron == -1) // If there's no last Drone shooting then...
					{
						_lastSignalDron = 0; // Take new Drone from the array
						Main.projectile[Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("projMotherboardLaser"), LaserDamage, LaserKb, 0, npc.whoAmI, _signalDrones[_lastSignalDron])].localAI[1] = 1;
						// Shoot the Drone from the boss
						return; // Ending the method
					}
					++_lastSignalDron; // Taking new Drone
					if (_lastSignalDron < _signalDrones.Count) // Checking for exiting the bounds of array
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("projMotherboardLaser"), LaserDamage, LaserKb, 0, _signalDrones[_lastSignalDron - 1], _signalDrones[_lastSignalDron]);
					// Shoot laser
					if (_lastSignalDron + 1 >= _signalDrones.Count) // If it is last drone then...
					{
						Vector2 vel = Helper.VelocityToPoint(Main.npc[_signalDrones[_signalDrones.Count - 1]].Center, Main.player[npc.target].Center, 15f);
						for (int i = 0; i < SecondShootCount; i++)
						{
							Vector2 velocity = Helper.VelocityToPoint(Main.npc[_signalDrones[_signalDrones.Count - 1]].Center, Main.player[npc.target].Center, SecondShootSpeed);
							velocity.X = velocity.X + Main.rand.Next(-SecondShootSpread, SecondShootSpread + 1) * SecondShootSpreadMult;
							velocity.Y = velocity.Y + Main.rand.Next(-SecondShootSpread, SecondShootSpread + 1) * SecondShootSpreadMult;
							Projectile.NewProjectile(npc.Center.X, npc.Center.Y, velocity.X, velocity.Y, LaserType, SecondShootDamage, SecondShootKn);
						}
						_lastSignalDron = -1;
						_shootNow = false;
						// Shooting the player with anotherl laser, setting last Drone to -1 and ending the cycle of shooting
					}
				}
			}
		}

		public override void NPCLoot()
		{
			NPC.downedMechBossAny = true;
			NPC.downedMechBoss1 = true;
			TremorWorld.downedBoss[TremorWorld.Boss.Motherboard] = true;

			if (Main.expertMode)
			{
				npc.DropBossBags();
			}
			else
			{
				this.SpawnItem((short)mod.ItemType<SoulofMind>(), Main.rand.Next(20, 41));
				this.SpawnItem(ItemID.GreaterHealingPotion, Main.rand.Next(5, 16));
				this.SpawnItem(ItemID.HallowedBar, Main.rand.Next(15, 36));

				if (Main.rand.Next(7) == 0)
				{
					this.SpawnItem((short)mod.ItemType<MotherboardMask>());
				}
			}

			if (Main.rand.Next(10) == 0)
			{
				this.SpawnItem((short)mod.ItemType<MotherboardTrophy>());
			}
			if (Main.rand.Next(3) == 0)
			{
				this.SpawnItem((short)mod.ItemType<BenderLegs>());
			}
			if (Main.rand.Next(10) == 0)
			{
				this.SpawnItem((short)mod.ItemType<FlaskCore>());
			}
			if (NPC.downedMoonlord 
				&& Main.rand.NextBool(TremorWorld.Boss.Tremode.Downed() ? 1 : 2))
			{
				this.SpawnItem((short)mod.ItemType<CarbonSteel>(), Main.rand.Next(6, 13));
			}
		}
	}
}
