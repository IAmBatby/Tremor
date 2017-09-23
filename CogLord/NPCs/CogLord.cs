using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.CogLord.NPCs
{
	// todo: redo
	[AutoloadBossHead]
	public class CogLord : ModNPC
	{
		//Framework
		private Vector2 _cogHands = new Vector2(-1, -1);

		//Bool variables
		private bool Ram => ((_cogHands.X == -1 && _cogHands.Y == -1) || npc.ai[1] == 1);

		private bool _firstAi = true;
		private bool _secondAi = true;
		private bool _needCheck;
		private bool _flag = true;
		private bool _flag1 = true;
		private bool _flag2 = true;
		private bool _rockets = true;

		//Float variables
		private float _distanseBlood = 150f;

		private float _rotationSpeed = 0.3f;
		private float _rotation;
		private float _laserRotation = MathHelper.PiOver2;
		private float _newRotation = MathHelper.PiOver2;

		//Int variables
		private int GetLaserDamage => 30;

		private int _animationRate = 6;
		private int _currentFrame;
		private int _timeToAnimation = 6;
		private int _timer;
		private int _timer2 = 0;
		private int _shootType = ProjectileID.HeatRay;
		private int _laserPosition = 20;
		private int _shootRate = 10;
		private int _timeToShoot = 4;
		private float _previousRageRotation;

		//String variables
		private string _leftHandName = "CogLordHand";
		private string _rightHandName = "CogLordGun";

		public override void SetDefaults()
		{
			npc.lifeMax = 45000;
			npc.damage = 25;
			npc.defense = 5;
			npc.knockBackResist = 0.0f;
			npc.width = 86;
			npc.height = 124;
			npc.aiStyle = 11;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath10;
			npc.boss = true;
			music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Boss6");
			bossBag = mod.ItemType("CogLordBag");
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
			spriteBatch.Draw(mod.GetTexture("CogLord/NPCs/CogLordBody"), npc.Center - Main.screenPosition, null, Color.White, 0f, new Vector2(44, -18), 1f, SpriteEffects.None, 0f);
			Texture2D drawTexture = Main.npcTexture[npc.type];
			Vector2 origin = new Vector2((drawTexture.Width / 2) * 0.5F, (drawTexture.Height / Main.npcFrameCount[npc.type]) * 0.5F);
			Vector2 drawPos = new Vector2(
				npc.position.X - Main.screenPosition.X + (npc.width / 2) - (Main.npcTexture[npc.type].Width / 2) * npc.scale / 2f + origin.X * npc.scale,
				npc.position.Y - Main.screenPosition.Y + npc.height - Main.npcTexture[npc.type].Height * npc.scale / Main.npcFrameCount[npc.type] + 4f + origin.Y * npc.scale + npc.gfxOffY);
			SpriteEffects effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(drawTexture, drawPos, npc.frame, Color.White, npc.rotation, origin, npc.scale, effects, 0);
			return false;
		}

		public override void AI()
		{
			npc.TargetClosest();
			if (Main.dayTime)
			{
				_timer = 0;
			}
			if (NPC.AnyNPCs(mod.NPCType("CogLordProbe")))
			{
				npc.dontTakeDamage = true;
			}
			else
				npc.dontTakeDamage = false;
			if (!Main.expertMode)
				npc.position += npc.velocity * 1.7f;
			else
				npc.position += npc.velocity * 1.02f;
			_timer++;
			Animation();
			for (int i = 0; i < Main.dust.Length; i++)
			{
				if (Main.dust[i].type == DustID.Blood && npc.Distance(Main.dust[i].position) < _distanseBlood)
				{
					Main.dust[i].scale /= 1000000f;
					Main.dust[i].active = false;
				}
			}
			foreach (NPC npc2 in Main.npc)
			{
				if (npc2.type == 36)
				{
					npc2.active = false;
					npc2.life = 0;
					npc2.checkDead();
				}
			}
			foreach (var proj in Main.projectile)
			{
				if (proj.type == ProjectileID.Skull && Vector2.Distance(proj.Center, npc.Center) < 100f)
				{
					proj.active = false;
				}
			}
			if (npc.life < npc.lifeMax * 0.6f && _flag)
			{
				_flag = false;
				if (Main.expertMode)
					CogMessage("Low health is detected. Launching support drones.");
				else
					CogMessage("Low health is detected. Launching support drone.");
				if (Main.expertMode)
					NPC.NewNPC((int)npc.Center.X - 100, (int)npc.Center.Y - 100, mod.NPCType("CogLordProbe"), 0, npc.whoAmI, 0, 200);
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("CogLordProbe"), 0, npc.whoAmI, 0, 200);
			}
			if (npc.life < npc.lifeMax * 0.4f && _flag1)
			{
				_flag1 = false;
				if (Main.expertMode)
					CogMessage("Low health is detected. Launching support drones.");
				else
					CogMessage("Low health is detected. Launching support drone.");
				if (Main.expertMode)
					NPC.NewNPC((int)npc.Center.X - 100, (int)npc.Center.Y - 100, mod.NPCType("CogLordProbe"), 0, npc.whoAmI, 0, 200);
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("CogLordProbe"), 0, npc.whoAmI, 0, 200);
			}
			if (npc.life < npc.lifeMax * 0.2f && _flag2)
			{
				_flag2 = false;
				if (Main.expertMode)
					CogMessage("Low health is detected. Launching support drones.");
				else
					CogMessage("Low health is detected. Launching support drone.");
				if (Main.expertMode)
					NPC.NewNPC((int)npc.Center.X - 100, (int)npc.Center.Y - 100, mod.NPCType("CogLordProbe"), 0, npc.whoAmI, 0, 200);
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("CogLordProbe"), 0, npc.whoAmI, 0, 200);
			}
			if (_firstAi)
			{
				_firstAi = false;
			}
			else
			{
				if (_secondAi)
				{
					MakeHands();
					_secondAi = false;
					_needCheck = true;
				}
			}
			if (!Ram)
			{
				if (_needCheck)
					CheckHands();
				if (_cogHands.Y != -1 && _needCheck)
				{
					Main.npc[(int)_cogHands.Y].localAI[3] = 0;
				}
			}
			else
			{
				if (_rockets)
				{
					_rockets = false;
					CogMessage("Protocol 10 is activated: Preparing for rocket storm.");
				}
				npc.frame = GetFrame(5);
				_rotation += _rotationSpeed;
				npc.rotation = _rotation;
				if ((int)(Main.time % 120) == 0)
				{
					for (int k = 0; k < ((Main.expertMode) ? 2 : 1); k++)
					{
						Vector2 velocity = Helper.VelocityToPoint(npc.Center, Helper.RandomPointInArea(new Vector2(Main.player[Main.myPlayer].Center.X - 10, Main.player[Main.myPlayer].Center.Y - 10), new Vector2(Main.player[Main.myPlayer].Center.X + 20, Main.player[Main.myPlayer].Center.Y + 20)), 20);
						int i = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, velocity.X, velocity.Y, 134, GetLaserDamage * ((Main.expertMode) ? 3 : 2), 1f);
						Main.projectile[i].hostile = true;
						Main.projectile[i].tileCollide = true;
						Main.projectile[i].friendly = false;
					}
				}
				if (_needCheck)
					CheckHands();
				if (_cogHands.Y != -1 && _needCheck)
				{
					Main.npc[(int)_cogHands.Y].localAI[3] = 1;
				}
			}
			if (_timer == 400)
			{
				CogMessage("Protocol 11 is activated: Clockwork laser cutter is being enabled.");
			}
			if (_timer >= 500 && _timer < 800)
			{
				_previousRageRotation = 0f;
				if (Main.netMode != 1)
				{
					_laserRotation += 0.01f;
					if (--_timeToShoot <= 0)
					{
						_timeToShoot = _shootRate;
						var shootPos = npc.Center + new Vector2(0, 17);
						var shootVel = new Vector2(0, 7).RotatedBy(_laserRotation);
						int[] i = {
							Projectile.NewProjectile(shootPos, shootVel, _shootType, GetLaserDamage, 1f),
							Projectile.NewProjectile(shootPos, shootVel.RotatedBy(MathHelper.PiOver2), _shootType, GetLaserDamage, 1f),
							Projectile.NewProjectile(shootPos, shootVel.RotatedBy(MathHelper.Pi), _shootType, GetLaserDamage, 1f),
							Projectile.NewProjectile(shootPos, shootVel.RotatedBy(-MathHelper.PiOver2), _shootType, GetLaserDamage, 1f)
						};
						for (int l = 0; l < i.Length; l++)
						{
							Main.projectile[i[l]].hostile = true;
							Main.projectile[i[l]].tileCollide = false;
						}
					}
				}
			}
			if (_timer >= 800 && _timer < 1200)
			{
				npc.velocity.X *= 2.00f;
				npc.velocity.Y *= 2.00f;
				Vector2 vector = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height * 0.5f));
				{
					float clRad = (float)Math.Atan2((vector.Y) - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), (vector.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
					npc.velocity.X = (float)(Math.Cos(clRad) * 4) * -1;
					npc.velocity.Y = (float)(Math.Sin(clRad) * 4) * -1;
				}
			}
			if (_timer == 1100)
			{
				CogMessage("Protocol 12 is activated: Summoning gears.");
			}
			if (_timer > 1200 && _timer < 1700)
			{
				if ((int)(Main.time % 15) == 0)
					NPC.NewNPC((int)((Main.player[npc.target].position.X - 500) + Main.rand.Next(1000)), (int)((Main.player[npc.target].position.Y - 500) + Main.rand.Next(1000)), mod.NPCType("GogLordGog"));
			}
			if (_timer == 1600)
			{
				CogMessage("Protocol 13 is activated: Rocket attack incoming.");
			}
			if (_timer >= 1700 && _timer < 1775)
			{
				if (Main.rand.NextBool(3))
				{
					var shootPos = Main.player[npc.target].position + new Vector2(Main.rand.Next(-1000, 1000), -1000);
					var shootVel = new Vector2(Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(15f, 20f));
					int i = Projectile.NewProjectile(shootPos, shootVel, 134, GetLaserDamage * ((Main.expertMode) ? 3 : 2), 1f);
					Main.projectile[i].hostile = true;
					Main.projectile[i].tileCollide = true;
					Main.projectile[i].friendly = false;
				}
			}
			if (_timer > 1775)
			{
				_rockets = true;
				_timer = 0;
			}
			_rotation = 0;
		}

		public void CheckHands()
		{
			if (_cogHands.X != -1)
				if (!((Main.npc[(int)_cogHands.X].type == mod.NPCType(_leftHandName) && Main.npc[(int)_cogHands.X].ai[1] == npc.whoAmI) && Main.npc[(int)_cogHands.X].active))
					_cogHands.X = -1;
			if (_cogHands.Y != -1)
				if (!((Main.npc[(int)_cogHands.Y].type == mod.NPCType(_rightHandName) && Main.npc[(int)_cogHands.Y].ai[1] == npc.whoAmI) && Main.npc[(int)_cogHands.Y].active))
					_cogHands.Y = -1;
		}

		public void MakeHands()
		{
			_cogHands.X = NPC.NewNPC((int)npc.Center.X - 50, (int)npc.Center.Y, mod.NPCType(_leftHandName), 0, 1, npc.whoAmI);
			_cogHands.Y = NPC.NewNPC((int)npc.Center.X + 50, (int)npc.Center.Y, mod.NPCType(_rightHandName), 0, -1, npc.whoAmI);
		}

		public void Animation()
		{
			if (--_timeToAnimation <= 0)
			{
				if (++_currentFrame > 4)
					_currentFrame = 1;
				_timeToAnimation = _animationRate;
				npc.frame = GetFrame(_currentFrame);
			}
		}

		private Rectangle GetFrame(int number)
		{
			return new Rectangle(0, npc.frame.Height * (number - 1), npc.frame.Width, npc.frame.Height);
		}

		public void CogMessage(string message)
		{
			string text = "[CL-AI]: " + message;
			if (Main.netMode != 2)
			{
				Main.NewText("[CL-AI]: " + message, 208, 137, 55);
			}
		}
		public override void NPCLoot()
		{
			TremorWorld.Boss.CogLord.Downed();
			if (Main.netMode != 1)
			{
				if (Main.expertMode)
				{
					npc.DropBossBags();
				}
				if (!Main.expertMode && Main.rand.Next(10) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrassChip"));
				}
				if (!Main.expertMode && Main.rand.Next(7) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CogLordMask"));
				}
				if (!Main.expertMode && Main.rand.Next(3) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrassRapier"));
				}
				if (!Main.expertMode && Main.rand.Next(3) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrassChainRepeater"));
				}
				if (!Main.expertMode && Main.rand.Next(3) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrassStave"));
				}
				if (Main.rand.Next(10) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CogLordTrophy"));
				}
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 499, Main.rand.Next(6, 25));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 500, Main.rand.Next(6, 25));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrassNugget"), Main.rand.Next(18, 32));
			}
		}
	}
}