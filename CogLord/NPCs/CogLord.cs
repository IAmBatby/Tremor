using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tremor.CogLord.NPCs
{
	[AutoloadBossHead]
	public class CogLord : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cog Lord");
			Main.npcFrameCount[npc.type] = 5;
		}

		//Framework
		public int[] cogHands = new int[2];

		//Bool variables
		//bool Ram => ((CogHands.X == -1 && CogHands.Y == -1) || npc.ai[1] == 1);
		bool Flag = true;
		bool Flag1 = true;
		bool Flag2 = true;
		bool Rockets = true;

		//Float variables
		float DistanseBlood = 150f;
		float RotationSpeed = 0.3f;
		float Rotation;
		float LaserRotation = MathHelper.PiOver2;
		float NewRotation = MathHelper.PiOver2;

		//Int variables
		int GetLaserDamage => 30;
		int AnimationRate = 6;
		int CurrentFrame;
		int TimeToAnimation = 6;
		int Timer;
		int Timer2 = 0;
		int ShootType = ProjectileID.HeatRay;
		int LaserPosition = 20;
		int ShootRate = 10;
		int TimeToShoot = 4;
		float PreviousRageRotation;

		//String variables
		string LeftHandName = "CogLordHand";
		string RightHandName = "CogLordGun";
		public override void SetDefaults()
		{
			npc.width = 86;
			npc.height = 124;

			npc.damage = 25;
			npc.defense = 5;
			npc.lifeMax = 45000;
			npc.knockBackResist = 0.0f;

			npc.aiStyle = -1;

			npc.boss = true;
			npc.noGravity = true;
			npc.noTileCollide = true;

			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath10;

			bossBag = mod.ItemType("CogLordBag");
			music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Boss6");
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}

		int t;
		public override bool PreAI()
		{
			if ((t++ % 100) == 0)
			{
				NPC.NewNPC((int)((Main.player[npc.target].position.X - 500) + Main.rand.Next(1000)), (int)((Main.player[npc.target].position.Y - 500) + Main.rand.Next(1000)), mod.NPCType("CogLordCog"));
			}

			npc.TargetClosest(true);

			npc.dontTakeDamage = NPC.AnyNPCs(mod.NPCType<CogLordProbe>());

			if (npc.life < npc.lifeMax * 0.6f && Flag)
			{
				Flag = false;
				if (Main.expertMode)
					CogMessage("Low health is detected. Launching support drones.");
				else
					CogMessage("Low health is detected. Launching support drone.");

				if (Main.netMode != 1)
				{
					if (Main.expertMode)
						Main.npc[NPC.NewNPC((int)npc.Center.X - 100, (int)npc.Center.Y - 100, mod.NPCType<CogLordProbe>(), 0, npc.whoAmI, 0, 200)].netUpdate = true;
					Main.npc[NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType<CogLordProbe>(), 0, npc.whoAmI, 0, 200)].netUpdate = true;
				}
			}
			if (npc.life < npc.lifeMax * 0.4f && Flag1)
			{
				Flag1 = false;
				if (Main.expertMode)
					CogMessage("Low health is detected. Launching support drones.");
				else
					CogMessage("Low health is detected. Launching support drone.");

				if (Main.netMode != 1)
				{
					if (Main.expertMode)
						Main.npc[NPC.NewNPC((int)npc.Center.X - 100, (int)npc.Center.Y - 100, mod.NPCType<CogLordProbe>(), 0, npc.whoAmI, 0, 200)].netUpdate = true;
					Main.npc[NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType<CogLordProbe>(), 0, npc.whoAmI, 0, 200)].netUpdate = true;
				}
			}
			if (npc.life < npc.lifeMax * 0.2f && Flag2)
			{
				Flag2 = false;
				if (Main.expertMode)
					CogMessage("Low health is detected. Launching support drones.");
				else
					CogMessage("Low health is detected. Launching support drone.");

				if (Main.netMode != 1)
				{
					if (Main.expertMode)
						Main.npc[NPC.NewNPC((int)npc.Center.X - 100, (int)npc.Center.Y - 100, mod.NPCType<CogLordProbe>(), 0, npc.whoAmI, 0, 200)].netUpdate = true;
					Main.npc[NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType<CogLordProbe>(), 0, npc.whoAmI, 0, 200)].netUpdate = true;
				}
			}

			// First update, spawn Arms.
			if(npc.ai[0] == 0)
			{
				if (Main.netMode != 1)
				{
					MakeHands();
					/*CheckHands();*/

					//if (CogHands.Y != -1)
					//	Main.npc[(int)CogHands.Y].ai[1] = 1;
				}
				npc.ai[0] = 1;
			}
			else if(npc.ai[0] == 1)
			{
				NormalMovement();
			}

			/*if(Ram)
			{
				if (Rockets)
				{
					Rockets = false;
					CogMessage("Protocol 10 is activated: Preparing for rocket storm.");
				}
				//Rotation += RotationSpeed;
				//npc.rotation = Rotation;
				if ((int)(Main.time % 120) == 0)
				{
					for (int k = 0; k < ((Main.expertMode) ? 2 : 1); k++)
					{
						Vector2 Velocity = Helper.VelocityToPoint(npc.Center, Helper.RandomPointInArea(new Vector2(Main.player[Main.myPlayer].Center.X - 10, Main.player[Main.myPlayer].Center.Y - 10), new Vector2(Main.player[Main.myPlayer].Center.X + 20, Main.player[Main.myPlayer].Center.Y + 20)), 20);
						int i = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Velocity.X, Velocity.Y, 134, GetLaserDamage * ((Main.expertMode) ? 3 : 2), 1f);
						Main.projectile[i].hostile = true;
						Main.projectile[i].tileCollide = true;
						Main.projectile[i].friendly = false;
					}
				}

				CheckHands();
				if (CogHands.Y != -1)
					Main.npc[(int)CogHands.Y].ai[1] = 0;
			}
			if (Timer == 400)
			{
				CogMessage("Protocol 11 is activated: Clockwork laser cutter is being enabled.");
			}
			if (Timer >= 500 && Timer < 800)
			{
				PreviousRageRotation = 0f;
				if (Main.netMode != 1)
				{
					LaserRotation += 0.01f;
					if (--TimeToShoot <= 0)
					{
						TimeToShoot = ShootRate;
						var ShootPos = npc.Center + new Vector2(0, 17);
						var ShootVel = new Vector2(0, 7).RotatedBy(LaserRotation);
						int[] i = {
							Projectile.NewProjectile(ShootPos, ShootVel, ShootType, GetLaserDamage, 1f),
							Projectile.NewProjectile(ShootPos, ShootVel.RotatedBy(MathHelper.PiOver2), ShootType, GetLaserDamage, 1f),
							Projectile.NewProjectile(ShootPos, ShootVel.RotatedBy(MathHelper.Pi), ShootType, GetLaserDamage, 1f),
							Projectile.NewProjectile(ShootPos, ShootVel.RotatedBy(-MathHelper.PiOver2), ShootType, GetLaserDamage, 1f)
						};
						for (int l = 0; l < i.Length; l++)
						{
							Main.projectile[i[l]].hostile = true;
							Main.projectile[i[l]].tileCollide = false;
						}
					}
				}
			}
			if (Timer >= 800 && Timer < 1200)
			{
				npc.velocity.X *= 2.00f;
				npc.velocity.Y *= 2.00f;
				Vector2 Vector = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height * 0.5f));
				{
					float CLRad = (float)Math.Atan2((Vector.Y) - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), (Vector.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
					npc.velocity.X = (float)(Math.Cos(CLRad) * 4) * -1;
					npc.velocity.Y = (float)(Math.Sin(CLRad) * 4) * -1;
				}
			}
			if (Timer == 1100)
			{
				CogMessage("Protocol 12 is activated: Summoning gears.");
			}
			if (Timer > 1200 && Timer < 1700)
			{
				if ((int)(Main.time % 15) == 0)
					NPC.NewNPC((int)((Main.player[npc.target].position.X - 500) + Main.rand.Next(1000)), (int)((Main.player[npc.target].position.Y - 500) + Main.rand.Next(1000)), mod.NPCType("GogLordGog"));
			}
			if (Timer == 1600)
			{
				CogMessage("Protocol 13 is activated: Rocket attack incoming.");
			}
			if (Timer >= 1700 && Timer < 1775)
			{
				if (Main.rand.NextBool(3))
				{
					var ShootPos = Main.player[npc.target].position + new Vector2(Main.rand.Next(-1000, 1000), -1000);
					var ShootVel = new Vector2(Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(15f, 20f));
					int i = Projectile.NewProjectile(ShootPos, ShootVel, 134, GetLaserDamage * ((Main.expertMode) ? 3 : 2), 1f);
					Main.projectile[i].hostile = true;
					Main.projectile[i].tileCollide = true;
					Main.projectile[i].friendly = false;
				}
			}
			if (Timer > 1775)
			{
				Rockets = true;
				Timer = 0;
			}*/

			return false;
		}

		protected void NormalMovement()
		{
			Player player = Main.player[npc.target];

			npc.rotation = npc.velocity.X / 15f;

			int maxYSpeed = 4;
			float yAcceleration = 0.02F;
			int maxXSpeed = 10;
			float xAcceleration = 0.05F;

			if (npc.position.Y > player.position.Y - 250f)
			{
				if (npc.velocity.Y > 0f)
					npc.velocity.Y = npc.velocity.Y * 0.98f;
				npc.velocity.Y = npc.velocity.Y - yAcceleration;
			}
			else if (npc.position.Y < player.position.Y - 250f)
			{
				if (npc.velocity.Y < 0f)
					npc.velocity.Y = npc.velocity.Y * 0.98f;
				npc.velocity.Y = npc.velocity.Y + yAcceleration;
			}
			if (npc.position.X + (npc.width / 2) > player.position.X + (player.width / 2))
			{
				if (npc.velocity.X > 0f)
					npc.velocity.X = npc.velocity.X * 0.98f;
				npc.velocity.X = npc.velocity.X - xAcceleration;
			}
			if (npc.position.X + (npc.width / 2) < player.position.X + (player.width / 2))
			{
				if (npc.velocity.X < 0f)
					npc.velocity.X = npc.velocity.X * 0.98f;
				npc.velocity.X = npc.velocity.X + xAcceleration;
			}

			npc.velocity.X = MathHelper.Clamp(npc.velocity.X, -maxXSpeed, maxXSpeed);
			npc.velocity.Y = MathHelper.Clamp(npc.velocity.Y, -maxYSpeed, maxYSpeed);
			/*
							this.ai[2] += 1f;
							if (this.ai[2] >= 800f)
							{
								this.ai[2] = 0f;
								this.ai[1] = 1f;
								this.TargetClosest(true);
								this.netUpdate = true;
							}
							this.rotation = this.velocity.X / 15f;
							float num167 = 0.02f;
							float num168 = 2f;
							float num169 = 0.05f;
							float num170 = 8f;
							if (Main.expertMode)
							{
								num167 = 0.03f;
								num168 = 4f;
								num169 = 0.07f;
								num170 = 9.5f;
							}*/
		}

		public override void FindFrame(int frameHeight)
		{
			if(npc.ai[0] == 2)
				npc.frame.Y = 4 * frameHeight;
			else if(npc.frameCounter++ >= 8)
			{
				npc.frame.Y = (npc.frame.Y + frameHeight) % ((Main.npcFrameCount[npc.type]-1) * frameHeight);
				npc.frameCounter = 0;
			}
		}

		public void MakeHands()
		{
			// Create the Left Hand.
			cogHands[0] = NPC.NewNPC((int)npc.Center.X - 50, (int)npc.Center.Y, mod.NPCType(LeftHandName), 0, npc.whoAmI);
			// Create the Left Arm parts.
			int upperLeftArm = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType<CogLordArm>());
			int lowerLeftArm = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType<CogLordArmSecond>());

			// Set the targets of the Upper Left Arm.
			Main.npc[upperLeftArm].ai[0] = npc.whoAmI;
			Main.npc[upperLeftArm].ai[1] = lowerLeftArm;
			// Set the targets of the Lower Left Arm.
			Main.npc[lowerLeftArm].ai[0] = cogHands[0];
			Main.npc[lowerLeftArm].ai[1] = upperLeftArm;

			// Create the Right Hand.
			cogHands[1] = NPC.NewNPC((int)npc.Center.X + 50, (int)npc.Center.Y, mod.NPCType(RightHandName), 0, npc.whoAmI);
			// Create the Right Arm parts.
			int upperRightArm = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType<CogLordArm>());
			int lowerRightArm = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType<CogLordArmSecond>());

			// Set the targets of the Upper Right Arm.
			Main.npc[upperRightArm].ai[0] = npc.whoAmI;
			Main.npc[upperRightArm].ai[1] = lowerRightArm;
			// Set the targets of the Lower Right Arm.
			Main.npc[lowerRightArm].ai[0] = cogHands[1];
			Main.npc[lowerRightArm].ai[1] = upperRightArm;

			// Make sure everything is correctly updated over the net.
			Main.npc[upperLeftArm].netUpdate = true;
			Main.npc[lowerLeftArm].netUpdate = true;

			Main.npc[upperRightArm].netUpdate = true;
			Main.npc[lowerRightArm].netUpdate = true;

			Main.npc[cogHands[0]].netUpdate = true;
			Main.npc[cogHands[1]].netUpdate = true;
		}
		/*public void CheckHands()
		{
			if (CogHands.X != -1)
				if (Main.npc[(int)CogHands.X].type != mod.NPCType(LeftHandName) || Main.npc[(int)CogHands.X].ai[0] != npc.whoAmI || !Main.npc[(int)CogHands.X].active)
					CogHands.X = -1;

			if (CogHands.Y != -1)
				if (Main.npc[(int)CogHands.Y].type != mod.NPCType(RightHandName) || Main.npc[(int)CogHands.Y].ai[0] != npc.whoAmI || !Main.npc[(int)CogHands.Y].active)
					CogHands.Y = -1;
		}*/

		public void CogMessage(string Message)
		{
			string Text = "[CL-AI]: " + Message;
			if (Main.netMode != 2)
			{
				Main.NewText("[CL-AI]: " + Message, 208, 137, 55);
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
	}
}
 
 