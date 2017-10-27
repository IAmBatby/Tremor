using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	[AutoloadBossHead]
	public class SpaceWhale : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Space Whale");
			Main.npcFrameCount[npc.type] = 8;
		}

		public override void SetDefaults()
		{
			npc.width = 500;
			npc.height = 80;
			npc.damage = 120;
			npc.defense = 135;
			npc.lifeMax = 120000;
			npc.scale = 1.2f;
			npc.HitSound = SoundID.NPCHit1;
			npc.noTileCollide = true;
			npc.DeathSound = SoundID.NPCDeath10;
			npc.boss = true;
			npc.knockBackResist = 0f;
			npc.noGravity = true;
			music = 39;
			npc.aiStyle = -1;
			animationType = 370;
			bossBag = mod.ItemType("SpaceWhaleTreasureBag");
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 60; k++)
				{
					Dust.NewDust(npc.Center, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.Center, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.Center, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/SWGore1"), 1f);
				Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/SWGore2"), 1f);
				Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/SWGore2"), 1f);
				Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/SWGore3"), 1f);
				Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/SWGore3"), 1f);
				Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/SWGore4"), 1f);
			}
			else
			{

				for (int k = 0; k < damage / npc.lifeMax * 20.0; k++)
				{
					Dust.NewDust(npc.Center, npc.width, npc.height, 226, hitDirection, -2f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.Center, npc.width, npc.height, 27, hitDirection, -1f, 0, default(Color), 0.7f);
				}
			}
		}

		public override void AI()
		{

			if (NPC.AnyNPCs(mod.NPCType("SpaceWhaleMinion")))
			{
				npc.dontTakeDamage = true;
			}
			if (!NPC.AnyNPCs(mod.NPCType("SpaceWhaleMinion")))
			{
				npc.dontTakeDamage = false;
			}

			bool flag75 = npc.life <= 45000;
			if (flag75)
			{
				npc.damage = 150;
				npc.defense = 50;
			}
			int num1076 = 60;
			float num1077 = 0.45f;
			float scaleFactor = 7.5f;
			if (npc.ai[0] == 5f)
			{
				num1077 = 0.5f;
				scaleFactor = 8f;
			}
			int num1078 = 30;
			float scaleFactor2 = 16f;
			if (npc.ai[0] < 4f && npc.ai[3] < 10f)
			{
				num1076 = 30;
			}
			else if (npc.ai[0] > 4f && npc.ai[3] < 10f)
			{
				num1076 = 20;
				num1078 = 30;
			}
			int num1079 = 80;
			int num1080 = 4;
			float num1081 = 0.3f;
			float scaleFactor3 = 5f;
			int num1082 = 90;
			int num1083 = 180;
			int num1084 = 120;
			int num1085 = 4;
			float scaleFactor4 = 6f;
			float scaleFactor5 = 20f;
			float num1086 = 6.28318548f / (num1084 / 2);
			int num1087 = 75;
			Vector2 vector134 = npc.Center;
			Player player2 = Main.player[npc.target];
			if (npc.target < 0 || npc.target == 255 || player2.dead || !player2.active)
			{
				npc.TargetClosest(true);
				player2 = Main.player[npc.target];
				npc.netUpdate = true;
			}
			if (player2.dead || Vector2.Distance(player2.Center, vector134) > 2400f)
			{
				npc.velocity.Y = npc.velocity.Y - 0.4f;
				if (npc.timeLeft > 10)
				{
					npc.timeLeft = 10;
				}
				if (npc.ai[0] > 4f)
				{
					npc.ai[0] = 5f;
				}
				else
				{
					npc.ai[0] = 0f;
				}
				npc.ai[2] = 0f;
			}
			if (npc.localAI[0] == 0f)
			{
				npc.localAI[0] = 1f;
				npc.alpha = 255;
				npc.rotation = 0f;
				if (Main.netMode != 1)
				{
					npc.ai[0] = -1f;
					npc.netUpdate = true;
				}
			}
			float num1088 = (float)Math.Atan2(player2.Center.Y - vector134.Y, player2.Center.X - vector134.X);
			if (npc.spriteDirection == 1)
			{
				num1088 += 3.14159274f;
			}
			if (num1088 < 0f)
			{
				num1088 += 6.28318548f;
			}
			if (num1088 > 6.28318548f)
			{
				num1088 -= 6.28318548f;
			}
			if (npc.ai[0] == -1f)
			{
				num1088 = 0f;
			}
			if (npc.ai[0] == 3f)
			{
				num1088 = 0f;
			}
			if (npc.ai[0] == 4f)
			{
				num1088 = 0f;
			}
			if (npc.ai[0] == 8f)
			{
				num1088 = 0f;
			}
			float num1089 = 0.04f;
			if (npc.ai[0] == 1f || npc.ai[0] == 6f)
			{
				num1089 = 0f;
			}
			if (npc.ai[0] == 7f)
			{
				num1089 = 0f;
			}
			if (npc.ai[0] == 3f)
			{
				num1089 = 0.01f;
			}
			if (npc.ai[0] == 4f)
			{
				num1089 = 0.01f;
			}
			if (npc.ai[0] == 8f)
			{
				num1089 = 0.01f;
			}
			if (npc.rotation < num1088)
			{
				if (num1088 - npc.rotation > 3.1415926535897931)
				{
					npc.rotation -= num1089;
				}
				else
				{
					npc.rotation += num1089;
				}
			}
			if (npc.rotation > num1088)
			{
				if (npc.rotation - num1088 > 3.1415926535897931)
				{
					npc.rotation += num1089;
				}
				else
				{
					npc.rotation -= num1089;
				}
			}
			if (npc.rotation > num1088 - num1089 && npc.rotation < num1088 + num1089)
			{
				npc.rotation = num1088;
			}
			if (npc.rotation < 0f)
			{
				npc.rotation += 6.28318548f;
			}
			if (npc.rotation > 6.28318548f)
			{
				npc.rotation -= 6.28318548f;
			}
			if (npc.rotation > num1088 - num1089 && npc.rotation < num1088 + num1089)
			{
				npc.rotation = num1088;
			}
			if (npc.ai[0] != -1f)
			{
				bool flag76 = Collision.SolidCollision(npc.position, npc.width, npc.height);
				if (flag76)
				{
					npc.alpha += 15;
				}
				else
				{
					npc.alpha -= 15;
				}
				if (npc.alpha < 0)
				{
					npc.alpha = 0;
				}
				if (npc.alpha > 150)
				{
					npc.alpha = 150;
				}
			}
			if (npc.ai[0] == -1f)
			{
				npc.velocity *= 0.98f;
				int num1090 = Math.Sign(player2.Center.X - vector134.X);
				if (num1090 != 0)
				{
					npc.direction = num1090;
					npc.spriteDirection = -npc.direction;
				}
				if (npc.ai[2] > 20f)
				{
					npc.velocity.Y = -2f;
					npc.alpha -= 5;
					bool flag77 = Collision.SolidCollision(npc.position, npc.width, npc.height);
					if (flag77)
					{
						npc.alpha += 15;
					}
					if (npc.alpha < 0)
					{
						npc.alpha = 0;
					}
					if (npc.alpha > 150)
					{
						npc.alpha = 150;
					}
				}
				if (npc.ai[2] == num1082 - 30)
				{
					int num1091 = 36;
					for (int num1092 = 0; num1092 < num1091; num1092++)
					{
						Vector2 vector135 = Vector2.Normalize(npc.velocity) * new Vector2(npc.width / 2f, npc.height) * 0.75f * 0.5f;
						vector135 = vector135.RotatedBy((num1092 - (num1091 / 2 - 1)) * 6.28318548f / num1091, default(Vector2)) + npc.Center;
						Vector2 value2 = vector135 - npc.Center;
						int num1093 = Dust.NewDust(vector135 + value2, 0, 0, 172, value2.X * 2f, value2.Y * 2f, 100, default(Color), 1.4f);
						Main.dust[num1093].noGravity = true;
						Main.dust[num1093].noLight = true;
						Main.dust[num1093].velocity = Vector2.Normalize(value2) * 3f;
					}
					Main.PlaySound(29, (int)vector134.X, (int)vector134.Y, 96);
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= num1087)
				{
					npc.ai[0] = 0f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.netUpdate = true;
				}
			}
			else if (npc.ai[0] == 0f && !player2.dead)
			{
				if (npc.ai[1] == 0f)
				{
					npc.ai[1] = 300 * Math.Sign((vector134 - player2.Center).X);
				}
				Vector2 value3 = player2.Center + new Vector2(npc.ai[1], -200f) - vector134;
				Vector2 vector136 = Vector2.Normalize(value3 - npc.velocity) * scaleFactor;
				if (npc.velocity.X < vector136.X)
				{
					npc.velocity.X = npc.velocity.X + num1077;
					if (npc.velocity.X < 0f && vector136.X > 0f)
					{
						npc.velocity.X = npc.velocity.X + num1077;
					}
				}
				else if (npc.velocity.X > vector136.X)
				{
					npc.velocity.X = npc.velocity.X - num1077;
					if (npc.velocity.X > 0f && vector136.X < 0f)
					{
						npc.velocity.X = npc.velocity.X - num1077;
					}
				}
				if (npc.velocity.Y < vector136.Y)
				{
					npc.velocity.Y = npc.velocity.Y + num1077;
					if (npc.velocity.Y < 0f && vector136.Y > 0f)
					{
						npc.velocity.Y = npc.velocity.Y + num1077;
					}
				}
				else if (npc.velocity.Y > vector136.Y)
				{
					npc.velocity.Y = npc.velocity.Y - num1077;
					if (npc.velocity.Y > 0f && vector136.Y < 0f)
					{
						npc.velocity.Y = npc.velocity.Y - num1077;
					}
				}
				int num1094 = Math.Sign(player2.Center.X - vector134.X);
				if (num1094 != 0)
				{
					if (npc.ai[2] == 0f && num1094 != npc.direction)
					{
						npc.rotation += 3.14159274f;
					}
					npc.direction = num1094;
					if (npc.spriteDirection != -npc.direction)
					{
						npc.rotation += 3.14159274f;
					}
					npc.spriteDirection = -npc.direction;
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= num1076)
				{
					int num1095 = 0;
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
							num1095 = 1;
							break;
						case 10:
							npc.ai[3] = 1f;
							num1095 = 2;
							break;
						case 11:
							npc.ai[3] = 0f;
							num1095 = 3;
							break;
					}
					if (flag75)
					{
						num1095 = 4;
					}
					if (num1095 == 1)
					{
						npc.ai[0] = 1f;
						npc.ai[1] = 0f;
						npc.ai[2] = 0f;
						npc.velocity = Vector2.Normalize(player2.Center - vector134) * scaleFactor2;
						npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X);
						if (num1094 != 0)
						{
							npc.direction = num1094;
							if (npc.spriteDirection == 1)
							{
								npc.rotation += 3.14159274f;
							}
							npc.spriteDirection = -npc.direction;
						}
					}
					else if (num1095 == 2)
					{
						npc.ai[0] = 2f;
						npc.ai[1] = 0f;
						npc.ai[2] = 0f;
					}
					else if (num1095 == 3)
					{
						npc.ai[0] = 3f;
						npc.ai[1] = 0f;
						npc.ai[2] = 0f;
					}
					else if (num1095 == 4)
					{
						npc.ai[0] = 4f;
						npc.ai[1] = 0f;
						npc.ai[2] = 0f;
					}
					npc.netUpdate = true;
				}
			}
			else if (npc.ai[0] == 1f)
			{
				int num1096 = 7;
				for (int num1097 = 0; num1097 < num1096; num1097++)
				{
					Vector2 vector137 = Vector2.Normalize(npc.velocity) * new Vector2((npc.width + 50) / 2f, npc.height) * 0.75f;
					vector137 = vector137.RotatedBy((num1097 - (num1096 / 2 - 1)) * 3.1415926535897931 / num1096, default(Vector2)) + vector134;
					Vector2 value4 = ((float)(Main.rand.NextDouble() * 3.1415927410125732) - 1.57079637f).ToRotationVector2() * Main.rand.Next(3, 8);
					int num1098 = Dust.NewDust(vector137 + value4, 0, 0, 172, value4.X * 2f, value4.Y * 2f, 100, default(Color), 1.4f);
					Main.dust[num1098].noGravity = true;
					Main.dust[num1098].noLight = true;
					Main.dust[num1098].velocity /= 4f;
					Main.dust[num1098].velocity -= npc.velocity;
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= num1078)
				{
					npc.ai[0] = 0f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.ai[3] += 2f;
					npc.netUpdate = true;
				}
			}
			else if (npc.ai[0] == 2f)
			{
				if (npc.ai[1] == 0f)
				{
					npc.ai[1] = 300 * Math.Sign((vector134 - player2.Center).X);
				}
				Vector2 value5 = player2.Center + new Vector2(npc.ai[1], -200f) - vector134;
				Vector2 vector138 = Vector2.Normalize(value5 - npc.velocity) * scaleFactor3;
				if (npc.velocity.X < vector138.X)
				{
					npc.velocity.X = npc.velocity.X + num1081;
					if (npc.velocity.X < 0f && vector138.X > 0f)
					{
						npc.velocity.X = npc.velocity.X + num1081;
					}
				}
				else if (npc.velocity.X > vector138.X)
				{
					npc.velocity.X = npc.velocity.X - num1081;
					if (npc.velocity.X > 0f && vector138.X < 0f)
					{
						npc.velocity.X = npc.velocity.X - num1081;
					}
				}
				if (npc.velocity.Y < vector138.Y)
				{
					npc.velocity.Y = npc.velocity.Y + num1081;
					if (npc.velocity.Y < 0f && vector138.Y > 0f)
					{
						npc.velocity.Y = npc.velocity.Y + num1081;
					}
				}
				else if (npc.velocity.Y > vector138.Y)
				{
					npc.velocity.Y = npc.velocity.Y - num1081;
					if (npc.velocity.Y > 0f && vector138.Y < 0f)
					{
						npc.velocity.Y = npc.velocity.Y - num1081;
					}
				}
				if (npc.ai[2] == 0f)
				{
					Main.PlaySound(29, (int)vector134.X, (int)vector134.Y, 96);
				}
				if (npc.ai[2] % num1080 == 0f)
				{
					Main.PlaySound(4, (int)npc.Center.X, (int)npc.Center.Y, 19);
					if (Main.netMode != 1)
					{
						Vector2 vector139 = Vector2.Normalize(player2.Center - vector134) * (npc.width + 20) / 2f + vector134;
						NPC.NewNPC((int)vector139.X, (int)vector139.Y + 45, mod.NPCType("SpaceWhaleMinion"), 0);
					}
				}
				int num1099 = Math.Sign(player2.Center.X - vector134.X);
				if (num1099 != 0)
				{
					npc.direction = num1099;
					if (npc.spriteDirection != -npc.direction)
					{
						npc.rotation += 3.14159274f;
					}
					npc.spriteDirection = -npc.direction;
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= num1079)
				{
					npc.ai[0] = 0f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.netUpdate = true;
				}
			}
			else if (npc.ai[0] == 3f)
			{
				npc.velocity *= 0.98f;
				npc.velocity.Y = MathHelper.Lerp(npc.velocity.Y, 0f, 0.02f);
				if (npc.ai[2] == num1082 - 30)
				{
					Main.PlaySound(29, (int)vector134.X, (int)vector134.Y, 95);
				}
				if (Main.netMode != 1 && npc.ai[2] == num1082 - 30)
				{
					Vector2 vector140 = npc.rotation.ToRotationVector2() * (Vector2.UnitX * npc.direction) * (npc.width + 20) / 2f + vector134;
					Projectile.NewProjectile(vector140.X, vector140.Y, npc.direction * 2, 8f, 467, 0, 0f, Main.myPlayer, 0f, 0f); Projectile.NewProjectile(vector140.X, vector140.Y, npc.direction * 3, 8f, 467, 0, 0f, Main.myPlayer, 0f, 0f); Projectile.NewProjectile(vector140.X, vector140.Y, npc.direction * 4, 8f, 467, 0, 0f, Main.myPlayer, 0f, 0f); Projectile.NewProjectile(vector140.X, vector140.Y, npc.direction * 5, 8f, 467, 0, 0f, Main.myPlayer, 0f, 0f); Projectile.NewProjectile(vector140.X, vector140.Y, npc.direction * 6, 8f, 467, 0, 0f, Main.myPlayer, 0f, 0f); Projectile.NewProjectile(vector140.X, vector140.Y, npc.direction * 7, 8f, 467, 0, 0f, Main.myPlayer, 0f, 0f); Projectile.NewProjectile(vector140.X, vector140.Y, npc.direction * 8, 8f, 467, 0, 0f, Main.myPlayer, 0f, 0f); Projectile.NewProjectile(vector140.X, vector140.Y, npc.direction * 9, 8f, 467, 0, 0f, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(vector140.X, vector140.Y, -(float)npc.direction * 2, 8f, 467, 0, 0f, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(vector140.X, vector140.Y, -(float)npc.direction * 3, 8f, 467, 0, 0f, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(vector140.X, vector140.Y, -(float)npc.direction * 4, 8f, 467, 0, 0f, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(vector140.X, vector140.Y, -(float)npc.direction * 5, 8f, 467, 0, 0f, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(vector140.X, vector140.Y, -(float)npc.direction * 6, 8f, 467, 0, 0f, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(vector140.X, vector140.Y, -(float)npc.direction * 7, 8f, 467, 0, 0f, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(vector140.X, vector140.Y, -(float)npc.direction * 8, 8f, 467, 0, 0f, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(vector140.X, vector140.Y, -(float)npc.direction * 9, 8f, 467, 0, 0f, Main.myPlayer, 0f, 0f);
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= num1082)
				{
					npc.ai[0] = 0f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.netUpdate = true;
				}
			}
			else if (npc.ai[0] == 4f)
			{
				npc.velocity *= 0.98f;
				npc.velocity.Y = MathHelper.Lerp(npc.velocity.Y, 0f, 0.02f);
				if (npc.ai[2] == num1083 - 60)
				{
					Main.PlaySound(29, (int)vector134.X, (int)vector134.Y, 98);
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= num1083)
				{
					npc.ai[0] = 5f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.ai[3] = 0f;
					npc.netUpdate = true;
				}
			}
			else if (npc.ai[0] == 5f && !player2.dead)
			{
				if (npc.ai[1] == 0f)
				{
					npc.ai[1] = 300 * Math.Sign((vector134 - player2.Center).X);
				}
				Vector2 value6 = player2.Center + new Vector2(npc.ai[1], -200f) - vector134;
				Vector2 vector141 = Vector2.Normalize(value6 - npc.velocity) * scaleFactor;
				if (npc.velocity.X < vector141.X)
				{
					npc.velocity.X = npc.velocity.X + num1077;
					if (npc.velocity.X < 0f && vector141.X > 0f)
					{
						npc.velocity.X = npc.velocity.X + num1077;
					}
				}
				else if (npc.velocity.X > vector141.X)
				{
					npc.velocity.X = npc.velocity.X - num1077;
					if (npc.velocity.X > 0f && vector141.X < 0f)
					{
						npc.velocity.X = npc.velocity.X - num1077;
					}
				}
				if (npc.velocity.Y < vector141.Y)
				{
					npc.velocity.Y = npc.velocity.Y + num1077;
					if (npc.velocity.Y < 0f && vector141.Y > 0f)
					{
						npc.velocity.Y = npc.velocity.Y + num1077;
					}
				}
				else if (npc.velocity.Y > vector141.Y)
				{
					npc.velocity.Y = npc.velocity.Y - num1077;
					if (npc.velocity.Y > 0f && vector141.Y < 0f)
					{
						npc.velocity.Y = npc.velocity.Y - num1077;
					}
				}
				int num1100 = Math.Sign(player2.Center.X - vector134.X);
				if (num1100 != 0)
				{
					if (npc.ai[2] == 0f && num1100 != npc.direction)
					{
						npc.rotation += 3.14159274f;
					}
					npc.direction = num1100;
					if (npc.spriteDirection != -npc.direction)
					{
						npc.rotation += 3.14159274f;
					}
					npc.spriteDirection = -npc.direction;
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= num1076)
				{
					int num1101 = 0;
					switch ((int)npc.ai[3])
					{
						case 0:
						case 1:
						case 2:
						case 3:
						case 4:
						case 5:
							num1101 = 1;
							break;
						case 6:
							npc.ai[3] = 1f;
							num1101 = 2;
							break;
						case 7:
							npc.ai[3] = 0f;
							num1101 = 3;
							break;
					}
					if (num1101 == 1)
					{
						npc.ai[0] = 6f;
						npc.ai[1] = 0f;
						npc.ai[2] = 0f;
						npc.velocity = Vector2.Normalize(player2.Center - vector134) * scaleFactor2;
						npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X);
						if (num1100 != 0)
						{
							npc.direction = num1100;
							if (npc.spriteDirection == 1)
							{
								npc.rotation += 3.14159274f;
							}
							npc.spriteDirection = -npc.direction;
						}
					}
					else if (num1101 == 2)
					{
						npc.velocity = Vector2.Normalize(player2.Center - vector134) * scaleFactor5;
						npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X);
						if (num1100 != 0)
						{
							npc.direction = num1100;
							if (npc.spriteDirection == 1)
							{
								npc.rotation += 3.14159274f;
							}
							npc.spriteDirection = -npc.direction;
						}
						npc.ai[0] = 7f;
						npc.ai[1] = 0f;
						npc.ai[2] = 0f;
					}
					else if (num1101 == 3)
					{
						npc.ai[0] = 8f;
						npc.ai[1] = 0f;
						npc.ai[2] = 0f;
					}
					npc.netUpdate = true;
				}
			}
			else if (npc.ai[0] == 6f)
			{
				int num1102 = 7;
				for (int num1103 = 0; num1103 < num1102; num1103++)
				{
					Vector2 vector142 = Vector2.Normalize(npc.velocity) * new Vector2((npc.width + 50) / 2f, npc.height) * 0.75f;
					vector142 = vector142.RotatedBy((num1103 - (num1102 / 2 - 1)) * 3.1415926535897931 / num1102, default(Vector2)) + vector134;
					Vector2 value7 = ((float)(Main.rand.NextDouble() * 3.1415927410125732) - 1.57079637f).ToRotationVector2() * Main.rand.Next(3, 8);
					int num1104 = Dust.NewDust(vector142 + value7, 0, 0, 172, value7.X * 2f, value7.Y * 2f, 100, default(Color), 1.4f);
					Main.dust[num1104].noGravity = true;
					Main.dust[num1104].noLight = true;
					Main.dust[num1104].velocity /= 4f;
					Main.dust[num1104].velocity -= npc.velocity;
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= num1078)
				{
					npc.ai[0] = 5f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.ai[3] += 2f;
					npc.netUpdate = true;
				}
			}
			else if (npc.ai[0] == 7f)
			{
				if (npc.ai[2] == 0f)
				{
					Main.PlaySound(29, (int)vector134.X, (int)vector134.Y, 98);
				}
				if (npc.ai[2] % num1085 == 0f)
				{
					Main.PlaySound(4, (int)npc.Center.X, (int)npc.Center.Y, 19);
					if (Main.netMode != 1)
					{
						Vector2 vector143 = Vector2.Normalize(npc.velocity) * (npc.width + 20) / 2f + vector134;
						int num1105 = NPC.NewNPC((int)vector143.X, (int)vector143.Y + 45, mod.NPCType("SpaceWhaleMinion"), 0);
						Main.npc[num1105].target = npc.target;
						Main.npc[num1105].velocity = Vector2.Normalize(npc.velocity).RotatedBy(1.57079637f * npc.direction, default(Vector2)) * scaleFactor4;
						Main.npc[num1105].netUpdate = true;
						Main.npc[num1105].ai[3] = Main.rand.Next(80, 121) / 100f;
					}
				}
				npc.velocity = npc.velocity.RotatedBy(-(double)num1086 * npc.direction, default(Vector2));
				npc.rotation -= num1086 * npc.direction;
				npc.ai[2] += 1f;
				if (npc.ai[2] >= num1084)
				{
					npc.ai[0] = 5f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.netUpdate = true;
				}
			}
			else if (npc.ai[0] == 8f)
			{
				npc.velocity *= 0.98f;
				npc.velocity.Y = MathHelper.Lerp(npc.velocity.Y, 0f, 0.02f);
				if (npc.ai[2] == num1082 - 30)
				{
					Main.PlaySound(29, (int)vector134.X, (int)vector134.Y, 94);
				}
				if (Main.netMode != 1 && npc.ai[2] == num1082 - 30)
				{
					Projectile.NewProjectile(vector134.X, vector134.Y, 0f, 0f, mod.ProjectileType("SpaceMeteorPro"), 0, 0f, Main.myPlayer, 1f, npc.target + 1);
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= num1082)
				{
					npc.ai[0] = 5f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.netUpdate = true;
				}
			}

		}

		public override void NPCLoot()
		{

			if (Main.expertMode)
			{
				npc.DropBossBags();
			}

			if (Main.netMode != 1)
			{
				int CenterX = (int)(npc.Center.X + npc.width / 2) / 16;
				int CenterY = (int)(npc.Center.Y + npc.height / 2) / 16;
				int halfLength = npc.width / 2 / 16 + 1;

				if (!TremorWorld.Boss.SpaceWhale.IsDowned())
				{
					Main.NewText("A comet has struck the ground!", 117, 187, 253);
					TremorWorld.DropComet();
					//return;
				}
				if (TremorWorld.Boss.SpaceWhale.IsDowned() && Main.rand.NextBool(3))
				{
					Main.NewText("A comet has struck the ground!", 117, 187, 253);
					TremorWorld.DropComet();
					//return;
				}
				TremorWorld.Boss.SpaceWhale.Downed();

				if (!Main.expertMode && Main.rand.NextBool(7))
				{
					Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("SpaceWhaleMask"));
				}
				if (!Main.expertMode && Main.rand.NextBool(7))
				{
					Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("SpaceWhaleTrophy"));
				}

				if (!Main.expertMode && Main.rand.NextBool(3))
				{
					Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("SDL"));
				}

				if (!Main.expertMode && Main.rand.NextBool(3))
				{
					Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("BlackHoleCannon"));
				}

				if (!Main.expertMode && Main.rand.NextBool(3))
				{
					Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("HornedWarHammer"));
				}

				if (!Main.expertMode && Main.rand.NextBool(5))
				{
					Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("StarLantern"));
				}

				if (!Main.expertMode && Main.rand.NextBool(8))
				{
					Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("WhaleFlippers"));
				}
				if (Main.rand.NextBool())
				{
					Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("CosmicFuel"));
				}
			}
		}

	}
}