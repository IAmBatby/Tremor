using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	[AutoloadBossHead]
	public class Brutallisk : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brutallisk");
			Main.npcFrameCount[npc.type] = 4;
		}

		int timer = 0;
		int timer2 = 0;
		int timer3 = 0;
		int timer4 = 0;
		bool SpawnMinion = false;
		public static bool phase2 = false;
		public static bool phase3 = false;
		static bool expertMode = Main.expertMode;
		const int ShootRate = 170;
		const int ShootDamage = 20;
		const float ShootKN = 1.0f;
		const int ShootType = 55;
		const float ShootSpeed = 10;
		const int SpeedMulti = 2;

		int TimeToShoot = ShootRate;
		static int num1461 = 360;
		float num1453 = expertMode ? 15f : 14f; //сила рывка
		float num1463 = 6.28318548f / (float)(num1461 / 2);
		int num1450 = expertMode ? 160 : 240; //частота рывка
		int num1472 = 0;
		bool flag128;
		static float scaleFactor10 = expertMode ? 8.5f : 7.5f;
		//Vector2 value17 = Main.player[npc.target].Center + new Vector2(npc.ai[1], -200f) - npc.Center;
		//Vector2 vector170 = Vector2.Normalize(Main.player[npc.target].Center + new Vector2(npc.ai[1], -200f) - npc.Center - npc.velocity) * scaleFactor10;
		float num1451 = expertMode ? 0.55f : 0.45f;
		//int num1471 = Math.Sign(Main.player[npc.target].Center.X - npc.Center.X);
		public override void SetDefaults()
		{
			npc.lifeMax = 115000;
			npc.damage = 245;
			npc.defense = 105;
			npc.knockBackResist = 0f;
			npc.width = 276;
			npc.height = 366;
			animationType = 82;
			npc.aiStyle = 2;
			npc.npcSlots = 1f;
			//npc.soundHit = 7;
			//npc.soundKilled = 10;
			npc.boss = true;
			npc.noGravity = true;
			npc.noTileCollide = true;
			music = 17;
			npc.value = Item.buyPrice(3, 50, 0, 0);
			bossBag = mod.ItemType("BrutalliskBag");
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}


		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BrutalliskGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BrutalliskGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BrutalliskGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BrutalliskGore4"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BrutalliskGore4"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BrutalliskCrystal"), 1f);
			}
			else
			{
				for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 59, (float)hitDirection, -1f, 0, default(Color), 0.7f);
				}
			}
		}

		public override void AI()
		{

			npc.TargetClosest(true);
			npc.spriteDirection = npc.direction;
			Player player = Main.player[npc.target];
			if (!player.active || player.dead)
			{
				npc.TargetClosest(false);
				npc.velocity.Y = 50;
				timer = 0;
				timer2 = 0;
				timer3 = 0;
				timer4 = 0;
			}
			timer++;
			if (timer <= 1000)
			{
				timer2++;
			}
			if (timer <= 1000)
			{
				timer3++;
			}
			if (timer >= 1000)
			{
				timer4++;
			}
			if (timer == 1750)
			{
				timer = 0;
			}

			if (timer >= 200 && timer <= 650)
			{
				if (npc.ai[1] == 0f)
				{
					npc.ai[1] = (float)(300 * Math.Sign((npc.Center - Main.player[npc.target].Center).X));
				}
				//value17 = Main.player[npc.target].Center + new Vector2(npc.ai[1], -200f) - npc.Center;
				//vector170 = Vector2.Normalize(Main.player[npc.target].Center + new Vector2(npc.ai[1], -200f) - npc.Center - npc.velocity) * scaleFactor10;
				//num1471 = Math.Sign(Main.player[npc.target].Center.X - npc.Center.X);
				if (Math.Sign(Main.player[npc.target].Center.X - npc.Center.X) != 0)
				{
					if (npc.ai[2] == 0f && Math.Sign(Main.player[npc.target].Center.X - npc.Center.X) != npc.direction)
					{
						npc.rotation += 3.14159274f;
					}
					npc.direction = Math.Sign(Main.player[npc.target].Center.X - npc.Center.X);
					if (npc.spriteDirection != -npc.direction)
					{
						npc.rotation += 3.14159274f;
					}
					npc.spriteDirection = -npc.direction;
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= (float)num1450)
				{
					num1472 = 0;
					switch ((int)npc.ai[3])
					{
						case 0:
						case 1:
						case 2:
						case 3:
						case 4:
						case 5:
						case 6:
						case 7:
						case 8:
						case 9:
							num1472 = 1;
							break;
						case 10:
							npc.ai[3] = 1f;
							num1472 = 2;
							break;
						case 11:
							npc.ai[3] = 0f;
							num1472 = 3;
							break;
					}
					if (flag128)
					{
						num1472 = 4;
					}
					if (num1472 == 1)
					{
						npc.ai[0] = 1f;
						npc.ai[1] = 0f;
						npc.ai[2] = 0f;
						npc.velocity = Vector2.Normalize(Main.player[npc.target].Center - npc.Center) * num1453;
						npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X);
						if (Math.Sign(Main.player[npc.target].Center.X - npc.Center.X) != 0)
						{
							npc.direction = Math.Sign(Main.player[npc.target].Center.X - npc.Center.X);
							if (npc.spriteDirection == 1)
							{
								npc.rotation += 3.14159274f;
							}
							npc.spriteDirection = -npc.direction;
						}
					}
					else if (num1472 == 2)
					{
						npc.ai[0] = 2f;
						npc.ai[1] = 0f;
						npc.ai[2] = 0f;
					}
					else if (num1472 == 3)
					{
						npc.ai[0] = 3f;
						npc.ai[1] = 0f;
						npc.ai[2] = 0f;
					}
					else if (num1472 == 4)
					{
						npc.ai[0] = 4f;
						npc.ai[1] = 0f;
						npc.ai[2] = 0f;
					}
					npc.netUpdate = true;
					return;
				}
			}

			if (timer >= 650 && timer <= 1000)
			{
				npc.velocity.X *= 0.98f;
				npc.velocity.Y *= 0.98f;
				Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height * 0.5f));
				{
					float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
					npc.velocity.X = (float)(Math.Cos(rotation) * 8) * -1;
					npc.velocity.Y = (float)(Math.Sin(rotation) * 8) * -1;
				}
				return;
			}

			if (timer >= 1000 && timer <= 1250)
			{
				if ((Main.player[npc.target].position.X + 400 < npc.position.X || Main.player[npc.target].position.X - 400 > npc.position.X || Main.player[npc.target].position.Y + 400 < npc.position.Y || Main.player[npc.target].position.Y - 400 > npc.position.Y))
				{
					if (Main.player[npc.target].position.X + 400 < npc.position.X)
					{
						if (npc.velocity.X > -6) { npc.velocity.X -= 0.2f; }
					}
					else if (Main.player[npc.target].position.X - 400 > npc.position.X)
					{
						if (npc.velocity.X < 6) { npc.velocity.X += 0.2f; }
					}
					if (Main.player[npc.target].position.Y + 400 < npc.position.Y)
					{
						if (npc.velocity.Y > -6) npc.velocity.Y -= 0.2f;
					}
					else if (Main.player[npc.target].position.Y - 400 > npc.position.Y)
					{
						if (npc.velocity.Y < 6) npc.velocity.Y += 0.2f;
					}
				}
				else
				{
					npc.velocity.X *= 0.95f; npc.velocity.Y *= 0.95f;
					npc.ai[1]++;
					if (npc.ai[1] >= 30)
					{
						npc.velocity.X += Main.rand.Next(-4, 4);
						npc.velocity.Y += Main.rand.Next(-4, 4);
						npc.ai[1] = 0;
					}
				}

				Vector2 vector = npc.velocity;
				npc.velocity = Collision.TileCollision(npc.position, npc.velocity, npc.width, npc.height, false, false);
				if (npc.velocity.X != vector.X)
				{
					npc.velocity.X = -vector.X;
				}
				if (npc.velocity.Y != vector.Y)
				{
					npc.velocity.Y = -vector.Y;
				}

				if (npc.ai[0] >= 0)
				{
					if ((Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height)))
					{
						float num48 = 12f;
						int damage = 30;
						npc.ai[0] = -100 - Main.rand.Next(100);
					}
				}

				if (Main.time % 2 == 0 && Main.netMode == 2 && npc.whoAmI < 200)
				{
					//NetMessage.SendData(23, -1, -1, "", npc.whoAmI, 0f, 0f, 0f, 0);
				}
			}

			if (timer >= 1250 && timer <= 1500)
			{
				if (Main.player[npc.target].position.X < npc.position.X)
				{
					if (npc.velocity.X > -8) npc.velocity.X -= 0.22f;
				}

				if (Main.player[npc.target].position.X > npc.position.X)
				{
					if (npc.velocity.X < 8) npc.velocity.X += 0.22f;
				}

				if (Main.player[npc.target].position.Y < npc.position.Y + 300)
				{
					if (npc.velocity.Y < 0)
					{
						if (npc.velocity.Y > -4) npc.velocity.Y -= 0.8f;
					}
					else npc.velocity.Y -= 0.6f;
				}

				if (Main.player[npc.target].position.Y > npc.position.Y + 300)
				{
					if (npc.velocity.Y > 0)
					{
						if (npc.velocity.Y < 4) npc.velocity.Y += 0.8f;
					}
					else npc.velocity.Y += 0.6f;
				}
				npc.ai[0]++;
				if (npc.ai[0] >= 70)
				{
					float Speed = 12f;
					Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
					int damage = 45;
					//Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 33);
					float rotation = (float)Math.Atan2(vector8.Y - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), vector8.X - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
					//int num54 = npc.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * Speed)*-1),(float)((Math.Sin(rotation) * Speed)*-1), 100, damage, 0f, 0);
					npc.ai[0] = 0;
				}
				npc.ai[1]++;
				if (npc.ai[1] >= 300)
				{
					npc.velocity.X *= 0.98f;
					npc.velocity.Y *= 0.98f;
					Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
					if ((npc.velocity.X < 2f) && (npc.velocity.X > -2f) && (npc.velocity.Y < 2f) && (npc.velocity.Y > -2f))
					{
						float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
						npc.velocity.X = (float)(Math.Cos(rotation) * 25) * -1;
						npc.velocity.Y = (float)(Math.Sin(rotation) * 25) * -1;
					}
				}
			}

			if (timer >= 1500)
			{
				npc.netUpdate = true;
				npc.ai[1]++;
				npc.TargetClosest();
				Player tarP = Main.player[npc.target]; float num74 = 0.022f;
				float num75 = tarP.position.X + (float)(tarP.width / 2);
				float num76 = tarP.position.Y + (float)(tarP.height / 2);
				Vector2 vector11 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
				num75 = (float)((int)(num75 / 8f) * 8);
				num76 = (float)((int)(num76 / 8f) * 8);
				vector11.X = (float)((int)(vector11.X / 8f) * 8);
				vector11.Y = (float)((int)(vector11.Y / 8f) * 8);
				num75 -= vector11.X;
				num76 -= vector11.Y;
				if ((tarP.position.X + 300 < npc.position.X || tarP.position.X - 300 > npc.position.X || tarP.position.Y + 300 < npc.position.Y || tarP.position.Y - 300 > npc.position.Y))
				{
					if (tarP.position.X + 300 < npc.position.X)
					{
						if (npc.velocity.X > -6)
						{
							npc.velocity.X -= 0.2f;
						}
					}
					else if (tarP.position.X - 300 > npc.position.X)
					{
						if (npc.velocity.X < 6)
						{
							npc.velocity.X += 0.2f;
						}
					}
					if (tarP.position.Y + 300 < npc.position.Y)
					{
						if (npc.velocity.Y > -6)
						{
							npc.velocity.Y -= 0.2f;
						}
					}
					else if (tarP.position.Y - 300 > npc.position.Y)
					{
						if (npc.velocity.Y < 6)
						{
							npc.velocity.Y += 0.2f;
						}
					}
				}
				else
				{
					npc.velocity.X *= 0.95f; npc.velocity.Y *= 0.95f;
					npc.ai[2]++;
					if (npc.ai[2] == 60)
					{
						npc.ai[0] = Main.rand.Next(-7, 7);
						npc.velocity.X += npc.ai[0];
						npc.velocity.Y += npc.ai[0];
						npc.ai[2] = 0;
					}
				}
				Vector2 vector = npc.velocity;
				npc.velocity = Collision.TileCollision(npc.position, npc.velocity, npc.width, npc.height, false, false);
				if (npc.velocity.X != vector.X)
				{
					npc.velocity.X = -vector.X;
				}
				if (npc.velocity.Y != vector.Y)
				{
					npc.velocity.Y = -vector.Y;
				}
				npc.rotation = (float)Math.Atan2((double)num76, (double)num75) - 1.57f;
				float num83 = 0.7f;
				if (npc.collideX)
				{
					npc.netUpdate = true;
					npc.velocity.X = npc.oldVelocity.X * -num83;
					if (npc.direction == -1 && npc.velocity.X > 0f && npc.velocity.X < 2f)
					{
						npc.velocity.X = 2f;
					}
					if (npc.direction == 1 && npc.velocity.X < 0f && npc.velocity.X > -2f)
					{
						npc.velocity.X = -2f;
					}
				}
				if (npc.collideY)
				{
					npc.netUpdate = true;
					npc.velocity.Y = npc.oldVelocity.Y * -num83;
					if (npc.velocity.Y > 0f && (double)npc.velocity.Y < 1.5)
					{
						npc.velocity.Y = 2f;
					}
					if (npc.velocity.Y < 0f && (double)npc.velocity.Y > -1.5)
					{
						npc.velocity.Y = -2f;
					}
				}

				if ((int)(Main.time % 120) == 0)
				{
					Projectile.NewProjectile(npc.position.X + 40, npc.position.Y + 40, -7, 0, 686, npc.damage, 0, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(npc.position.X + 40, npc.position.Y + 40, 7, 0, 467, npc.damage, 0, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(npc.position.X + 40, npc.position.Y + 40, 0, 7, 467, npc.damage, 0, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(npc.position.X + 40, npc.position.Y + 40, 0, -7, 467, npc.damage, 0, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(npc.position.X + 40, npc.position.Y + 40, -7, -7, 686, npc.damage, 0, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(npc.position.X + 40, npc.position.Y + 40, 7, -7, 467, npc.damage, 0, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(npc.position.X + 40, npc.position.Y + 40, -7, 7, 467, npc.damage, 0, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(npc.position.X + 40, npc.position.Y + 40, 7, 7, 686, npc.damage, 0, Main.myPlayer, 0f, 0f);
				}

			}

			if (!Main.expertMode && Main.rand.Next(320) == 0)
			{
				Main.PlaySound(29, (int)npc.position.X, (int)npc.position.Y, 97);

				for (int i = 0; i < 255; ++i)
				{
					if (Main.player[i].active && !Main.player[i].dead)
					{
						//Main.player[i].Hurt(45, 1, false, false, "was roared to death.", false, -1);
					}
				}
			}

			if (Main.expertMode && Main.rand.Next(310) == 0)
			{
				Main.PlaySound(29, (int)npc.position.X, (int)npc.position.Y, 97);

				for (int i = 0; i < 255; ++i)
				{
					if (Main.player[i].active && !Main.player[i].dead)
					{
						//Main.player[i].Hurt(60, 1, false, false, "was roared to death.", false, -1);
					}
				}
			}

			if (Main.rand.Next(380) == 0)
			{
				NPC.NewNPC((int)npc.position.X - 50, (int)npc.position.Y, mod.NPCType("Naga"));
			}

			if (Main.rand.Next(380) == 0)
			{
				NPC.NewNPC((int)npc.position.Y + 100, (int)npc.position.Y, mod.NPCType("Quetzalcoatl"));
			}


		}

		Vector2 VelocityFPTP(Vector2 pos1, Vector2 pos2, float speed)
		{
			Vector2 move = pos2 - pos1;
			return move * (speed / (float)System.Math.Sqrt(move.X * move.X + move.Y * move.Y));
		}

		public override void NPCLoot()
		{

			if (Main.expertMode)
			{
				npc.DropBossBags();
			}

			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
				int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
				int halfLength = npc.width / 2 / 16 + 1;

				if (!Main.expertMode && Main.rand.Next(4) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SnakeDevourer"));
				}
				if (!Main.expertMode && Main.rand.Next(4) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Awakening"));
				}
				if (!Main.expertMode && Main.rand.Next(4) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LightningStaff"));
				}
				if (!Main.expertMode && Main.rand.Next(4) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("QuetzalcoatlStave"));
				}
				if (!Main.expertMode && Main.rand.Next(4) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TreasureGlaive"));
				}
				if (!Main.expertMode && Main.rand.Next(25) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FallenSnake"));
				}
				if (!Main.expertMode && Main.rand.Next(1) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Aquamarine"), Main.rand.Next(10, 18));
				}
				if (!Main.expertMode && Main.rand.Next(100) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StrangeEgg"));
				}
				if (Main.rand.Next(10) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrutalliskTrophy"));
				}
				if (!Main.expertMode && Main.rand.Next(7) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrutalliskMask"));
				}
				TremorWorld.downedBrutallisk = true;
			}
		}

	}
}