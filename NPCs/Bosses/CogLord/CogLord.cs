﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Tremor.Items.Brass;
using Tremor.NPCs.Bosses.CogLord.Items;
using Tremor.NPCs.Bosses.CogLord.Projectiles;

namespace Tremor.NPCs.Bosses.CogLord
{
	// todo: redo
	[AutoloadBossHead]
	public class CogLord : ModNPC
	{
		public override void SetDefaults()
		{
			npc.lifeMax = 45000;
			npc.damage = 25;
			npc.defense = 5;
			npc.knockBackResist = 0.0f;
			npc.width = 86;
			npc.height = 124;
			npc.aiStyle = -1;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath10;
			npc.boss = true;
			music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Boss6");
			bossBag = mod.ItemType<CogLordBag>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cog Lord");
			Main.npcFrameCount[npc.type] = 5;
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			Texture2D texture = mod.GetTexture("NPCs/Bosses/CogLord/CogLordBody");
			spriteBatch.Draw(texture, npc.Center - new Vector2(texture.Width / 2, -12) - Main.screenPosition, npc.dontTakeDamage ? Color.Yellow : Color.White);
			return true;
		}

		int LeftHandType => mod.NPCType<CogLordHand>();
		int RightHandType => mod.NPCType<CogLordGun>();
		bool Ramming => ((LeftHandIndex == -1 && RightHandIndex == -1) || CurrentState == CogLordAIState.Ramming);
		
		int animationRate = 6;
		int GetLaserDamage = 30;

		CogLordAIState CurrentState
		{
			get { return (CogLordAIState)((int)npc.ai[0] & 15); }
			set { npc.ai[0] = (int)npc.ai[0] & 1048560 | (byte)value; }
		}

		int LeftHandIndex
		{
			get { return ((int)npc.ai[0] >> 4 & 255) - 1; }
			set { npc.ai[0] = (int)npc.ai[0] & 1044495 | value + 1 << 4; }
		}

		int RightHandIndex
		{
			get { return ((int)npc.ai[0] >> 12 & 255) - 1; }
			set { npc.ai[0] = (int)npc.ai[0] & 4095 | value + 1 << 12; }
		}

		float TimerA
		{
			get { return npc.ai[1]; }
			set { npc.ai[1] = value; }
		}

		float TimerB
		{
			get { return npc.ai[2]; }
			set { npc.ai[2] = value; }
		}

		float LaserRotation
		{
			get { return npc.ai[3]; }
			set { npc.ai[3] = value; }
		}

		float DroneLaunches
		{
			get { return npc.localAI[0]; }
			set { npc.localAI[0] = value; }
		}

		bool ShootRockets
		{
			get { return npc.localAI[1] != 0; }
			set { npc.localAI[1] = value ? 1 : 0; }
		}

		int AttackTimer
		{
			get { return (int)npc.localAI[2]; }
			set { npc.localAI[2] = value; }
		}

		bool ShootLasers
		{
			get { return npc.localAI[3] != 0; }
			set { npc.localAI[3] = value ? 1 : 0; }
		}

		public override void AI()
		{
			npc.defense = npc.defDefense;

			if (CurrentState == CogLordAIState.None)
			{
				CurrentState = CogLordAIState.Idle;
				MakeHands();
			}

			Player target = Main.player[npc.target];

			float deaccMult = 0.97f;
			float accMult = 1.3f;

			if (target.dead || Vector2.DistanceSquared(target.Center, npc.Center) > 2000 * 2000)
			{
				npc.TargetClosest(true);
				target = Main.player[npc.target];
				if (target.dead || Vector2.DistanceSquared(target.Center, npc.Center) > 2000 * 2000)
					CurrentState = CogLordAIState.Leaving;
			}

			if (Main.dayTime && CurrentState != CogLordAIState.Leaving && CurrentState != CogLordAIState.Enraged)
			{
				CurrentState = CogLordAIState.Enraged;
				Main.PlaySound(SoundID.Roar, npc.Center, 0);
			}

			int liveHands = 0;
			if (Main.expertMode)
			{
				if (Main.npc[LeftHandIndex].active && Main.npc[LeftHandIndex].type == LeftHandType && Main.npc[LeftHandIndex].ai[1] == npc.whoAmI)
					liveHands++;
				if (Main.npc[RightHandIndex].active && Main.npc[RightHandIndex].type == RightHandType && Main.npc[RightHandIndex].ai[1] == npc.whoAmI)
					liveHands++;
				npc.defense += liveHands * 25;
			}
			if (CurrentState == CogLordAIState.Idle)
			{
				npc.damage = npc.defDamage;
				TimerA++;
				if (TimerA++ >= 800)
				{
					TimerA = 0;
					CurrentState = CogLordAIState.Ramming;
					npc.TargetClosest(true);
					target = Main.player[npc.target];
					npc.netUpdate = true;
				}
				npc.rotation = npc.velocity.X / 12f / accMult;
				float accelerationY = 0.02f;
				float maxSpeedY = 2f;
				float accelerationX = 0.05f;
				float maxSpeedX = 8f;
				if (Main.expertMode)
				{
					accelerationY = 0.03f;
					maxSpeedY = 4f;
					accelerationX = 0.07f;
					maxSpeedX = 9.5f;
				}

				accelerationX *= accMult;
				accelerationY *= accMult;
				maxSpeedX *= accMult;
				maxSpeedY *= accMult;

				if (npc.position.Y > target.position.Y - 250f)
				{
					if (npc.velocity.Y > 0f)
						npc.velocity.Y *= deaccMult;
					npc.velocity.Y -= accelerationY;
					if (npc.velocity.Y > maxSpeedY)
						npc.velocity.Y = maxSpeedY;
				}
				else if (npc.position.Y < target.position.Y - 250f)
				{
					if (npc.velocity.Y < 0f)
						npc.velocity.Y *= deaccMult;
					npc.velocity.Y += accelerationY;
					if (npc.velocity.Y < -maxSpeedY)
						npc.velocity.Y = -maxSpeedY;
				}
				if (npc.Center.X > target.Center.X)
				{
					if (npc.velocity.X > 0f)
						npc.velocity.X *= deaccMult;
					npc.velocity.X -= accelerationX;
					if (npc.velocity.X > maxSpeedX)
						npc.velocity.X = maxSpeedX;
				}
				if (npc.Center.X < target.Center.X)
				{
					if (npc.velocity.X < 0f)
						npc.velocity.X *= deaccMult;
					npc.velocity.X += accelerationX;
					if (npc.velocity.X < -maxSpeedX)
						npc.velocity.X = -maxSpeedX;
				}
			}
			else if (CurrentState == CogLordAIState.Ramming)
			{
				npc.defense -= 10;
				TimerA++;
				if (TimerA == 2)
					Main.PlaySound(SoundID.Roar, npc.Center, 0);
				if (TimerA >= 400)
				{
					TimerA = 0;
					CurrentState = CogLordAIState.Idle;
				}

				npc.rotation = npc.velocity.X / 12f / accMult;

				Vector2 direction = target.Center - npc.Center;
				float distance = direction.Length();
				float speedMult = 2f;

				if (Main.expertMode)
				{
					npc.damage = (int)(npc.defDamage * 1.3f);
					speedMult = 5f;
					if (distance > 150f)
						speedMult *= 1.05f;

					for (int i = 0; i < 9; i++)
					{
						if (distance > 200 + i * 50)
							speedMult *= 1.1f;
					}
					
					if (liveHands == 0)
						speedMult *= 1.2f;
					else if (liveHands == 1)
						speedMult *= 1.1f;
				}
				distance = speedMult * accMult / distance;
				npc.velocity = direction * distance;
			}
			else if (CurrentState == CogLordAIState.Enraged)
			{
				npc.damage = 1000;
				npc.defense = 9999;
				npc.rotation = npc.velocity.X / 12f / accMult;
				Vector2 direction = target.Center - npc.Center;
				float distance = direction.Length();
				float speedMult = 8f;
				distance = speedMult * accMult / distance;
				npc.velocity = direction * distance;
			}
			else if (CurrentState == CogLordAIState.Leaving)
			{
				npc.velocity.Y = npc.velocity.Y + 0.1f;
				if (npc.velocity.Y < 0f)
					npc.velocity.Y = npc.velocity.Y * deaccMult;
				npc.velocity.X = npc.velocity.X * deaccMult;
				if (npc.timeLeft > 50)
					npc.timeLeft = 50;
			}
			
			npc.dontTakeDamage = NPC.AnyNPCs(mod.NPCType<CogLordProbe>());
			TimerB++;

			if (++AttackTimer >= 3000)
				AttackTimer = 0;

			LaunchDrones:

			if (npc.life < npc.lifeMax * 0.6f && DroneLaunches <= 0 ||
				npc.life < npc.lifeMax * 0.4f && DroneLaunches <= 1 ||
				npc.life < npc.lifeMax * 0.2f && DroneLaunches <= 2)
			{
				DroneLaunches++;
				CogMessage("Low health is detected. Launching support drone" + (Main.expertMode ? "s" : "") + ".");
				if (Main.expertMode)
					NPC.NewNPC((int)npc.Center.X - 100, (int)npc.Center.Y - 100, mod.NPCType<CogLordProbe>(), 0, npc.whoAmI, 0, 200);
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType<CogLordProbe>(), 0, npc.whoAmI, 0, 200);
				if (DroneLaunches <= 2)
					goto LaunchDrones;
			}
			
			if (Ramming)
			{
				if (ShootRockets)
				{
					ShootRockets = false;
					CogMessage("Protocol 10 is activated: Preparing for rocket storm.");
				}

				if (Main.netMode != NetmodeID.MultiplayerClient && AttackTimer % 120 == 0)
				{
					for (int i = 0; i < ((Main.expertMode) ? 2 : 1); i++)
					{
						Vector2 velocity = Helper.VelocityToPoint(npc.Center, Helper.RandomPointInArea(target.Center - new Vector2(20), target.Center + new Vector2(20)), 20);
						int index = Projectile.NewProjectile(npc.Center, velocity, ProjectileID.RocketSkeleton, GetLaserDamage * ((Main.expertMode) ? 3 : 2), 0f, Main.myPlayer);
					}
				}
			}

			CheckHands();
			if (RightHandIndex != -1)
				Main.npc[RightHandIndex].localAI[3] = 0;

			if (TimerB == 400)
			{
				CogMessage("Protocol 11 is activated: Clockwork laser cutter is being enabled.");
				ShootLasers = true;
			}
			if (TimerB >= 500 && TimerB < 800)
			{
				LaserRotation += 0.01f;
				if (Main.netMode != NetmodeID.MultiplayerClient && ShootLasers)
				{
					for (int i = 0; i < 4; i++)
						Projectile.NewProjectile(npc.Center, Vector2.Zero, mod.ProjectileType<ClockworkLaserCutter>(), GetLaserDamage, 0, Main.myPlayer, npc.whoAmI, i);
					ShootLasers = false;
				}
			}
			if (TimerB == 1100)
			{
				CogMessage("Protocol 12 is activated: Summoning gears.");
			}
			if (Main.netMode != NetmodeID.MultiplayerClient && TimerB > 1200 && TimerB < 1700 && AttackTimer % 15 == 0)
			{
				Projectile.NewProjectile(target.Center + new Vector2(Main.rand.Next(-500, 501), Main.rand.Next(-500, 501)), Vector2.Zero, mod.ProjectileType<CogLordCog>(), 50, 0, Main.myPlayer);
			}
			if (TimerB == 1600)
			{
				CogMessage("Protocol 13 is activated: Rocket attack incoming.");
			}
			if (Main.netMode != NetmodeID.MultiplayerClient && TimerB >= 1700 && TimerB < 1775 && Main.rand.NextBool(3))
			{
				var shootPos = target.Center + new Vector2(Main.rand.Next(-1000, 1001), -1000);
				var shootVel = new Vector2(Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(15f, 20f));
				Projectile.NewProjectile(shootPos, shootVel, ProjectileID.RocketSkeleton, GetLaserDamage * ((Main.expertMode) ? 3 : 2), 0, Main.myPlayer);
			}
			if (TimerB > 1775)
			{
				ShootRockets = true;
				TimerB = 0;
			}
		}

		public enum CogLordAIState : byte
		{
			None,
			Idle,
			Ramming,
			Enraged,
			Leaving
		}

		public void CheckHands()
		{
			if (LeftHandIndex != -1)
				if (!Main.npc[LeftHandIndex].active || Main.npc[LeftHandIndex].type != LeftHandType || Main.npc[LeftHandIndex].ai[1] != npc.whoAmI)
					LeftHandIndex = -1;
			if (RightHandIndex != -1)
				if (!Main.npc[RightHandIndex].active || Main.npc[RightHandIndex].type != RightHandType || Main.npc[RightHandIndex].ai[1] != npc.whoAmI)
					RightHandIndex = -1;
		}

		public void MakeHands()
		{
			if (Main.netMode == NetmodeID.MultiplayerClient)
				return;

			npc.TargetClosest();
			LeftHandIndex = NPC.NewNPC((int)npc.Center.X - 50, (int)npc.Center.Y, LeftHandType, npc.whoAmI, 1, npc.whoAmI, 0, 0, npc.target);
			RightHandIndex = NPC.NewNPC((int)npc.Center.X + 50, (int)npc.Center.Y, RightHandType, npc.whoAmI, -1, npc.whoAmI, 0, 0, npc.target);
			npc.netUpdate = true;
		}

		public override void FindFrame(int frameHeight)
		{
			if (Ramming)
			{
				npc.frameCounter = 0;
				npc.frame.Y = frameHeight * 4;
			}
			else if (++npc.frameCounter > animationRate)
			{
				npc.frameCounter = 0;
				npc.frame.Y += frameHeight;
				if (npc.frame.Y / frameHeight >= Main.npcFrameCount[npc.type])
					npc.frame.Y = 0;
			}
		}

		public void CogMessage(string message)
		{
			if (Main.netMode != NetmodeID.Server)
				Main.NewText("[CL-AI]: " + message, 208, 137, 55);
		}

		public override Color? GetAlpha(Color drawColor) => npc.dontTakeDamage ? Color.Yellow : Color.White;
		public override void BossLoot(ref string name, ref int potionType) => potionType = ItemID.GreaterHealingPotion;

		public override void NPCLoot()
		{
			TremorWorld.Boss.CogLord.Downed();
			if (Main.rand.NextBool(10))
			{
				Item.NewItem(npc.getRect(), mod.ItemType<CogLordTrophy>());
			}
			if (Main.expertMode)
			{
				npc.DropBossBags();
			}
			else
			{
				Item.NewItem(npc.getRect(), mod.ItemType<BrassNugget>(), Main.rand.Next(18, 33));
				if (Main.rand.NextBool(7))
				{
					Item.NewItem(npc.getRect(), mod.ItemType<CogLordMask>());
				}
				if (Main.rand.NextBool(10))
				{
					Item.NewItem(npc.getRect(), mod.ItemType<BrassChip>());
				}
				int[] choises = new int[] { mod.ItemType<BrassRapier>(), mod.ItemType<BrassChainRepeater>(), mod.ItemType<BrassStave>() };
				Item.NewItem(npc.getRect(), Main.rand.Next(choises));
			}
		}
	}
}