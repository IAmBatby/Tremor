using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	public class WallOfShadowEye : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wall of Shadows");
			NPCID.Sets.TechnicallyABoss[npc.type] = true;
		}

		public override void SetDefaults()
		{
			npc.width = 100;
			npc.height = 100;

			npc.damage = 78;
			npc.defense = 40;
			npc.lifeMax = 8000;
			npc.knockBackResist = 0f;

			//npc.boss = true;
			npc.noGravity = true;
			npc.lavaImmune = true;
			npc.behindTiles = true;
			npc.noTileCollide = true;

			npc.HitSound = SoundID.NPCHit8;
			npc.DeathSound = SoundID.NPCDeath10;

			music = MusicID.Boss2;
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}

		public override bool PreAI()
		{
			if (Main.wof < 0)
			{
				npc.active = false;
			}
			else
			{
				npc.realLife = Main.wof;
				if (Main.npc[Main.wof].life > 0)
					npc.life = Main.npc[Main.wof].life;
				npc.TargetClosest(true);
				npc.position.X = Main.npc[Main.wof].position.X;
				npc.direction = Main.npc[Main.wof].direction;
				npc.spriteDirection = npc.direction;
				float num1 = ((Main.wofB + Main.wofT) / 2);
				float num2 = (npc.ai[0] <= 0.0 ? ((num1 + Main.wofB) / 2) : ((num1 + Main.wofT) / 2)) - (npc.height / 2);
				if (npc.position.Y > num2 + 1)
					npc.velocity.Y = -1f;
				else if (npc.position.Y < num2 - 1)
				{
					npc.velocity.Y = 1f;
				}
				else
				{
					npc.velocity.Y = 0.0f;
					npc.position.Y = num2;
				}
				if (npc.velocity.Y > 5.0)
					npc.velocity.Y = 5f;
				if (npc.velocity.Y < -5.0)
					npc.velocity.Y = -5f;
				Vector2 vector2 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
				float num3 = Main.player[npc.target].position.X + (Main.player[npc.target].width / 2) - vector2.X;
				float num4 = Main.player[npc.target].position.Y + (Main.player[npc.target].height / 2) - vector2.Y;
				float num5 = (float)Math.Sqrt(num3 * num3 + num4 * num4);
				float num6 = num3 * num5;
				float num7 = num4 * num5;
				bool flag = true;
				if (npc.direction > 0)
				{
					if (Main.player[npc.target].position.X + (Main.player[npc.target].width / 2) > npc.position.X + (npc.width / 2))
					{
						npc.rotation = (float)Math.Atan2(-num7, -num6) + 3.14f;
					}
					else
					{
						npc.rotation = 0.0f;
						flag = false;
					}
				}
				else if (Main.player[npc.target].position.X + (Main.player[npc.target].width / 2) < npc.position.X + (npc.width / 2))
				{
					npc.rotation = (float)Math.Atan2(num7, num6) + 3.14f;
				}
				else
				{
					npc.rotation = 0.0f;
					flag = false;
				}
				if (Main.netMode == 1)
					return false;
				int num8 = 4;
				++npc.localAI[1];
				if (Main.npc[Main.wof].life < Main.npc[Main.wof].lifeMax * 0.75F)
				{
					++npc.localAI[1];
					++num8;
				}
				if (Main.npc[Main.wof].life < Main.npc[Main.wof].lifeMax * 0.5F)
				{
					++npc.localAI[1];
					++num8;
				}
				if (Main.npc[Main.wof].life < Main.npc[Main.wof].lifeMax * 0.25F)
				{
					++npc.localAI[1];
					num8 += 2;
				}
				if (Main.npc[Main.wof].life < Main.npc[Main.wof].lifeMax * 0.1F)
				{
					npc.localAI[1] += 2f;
					num8 += 3;
				}
				if (Main.expertMode)
				{
					npc.localAI[1] += 0.5f;
					++num8;
					if (Main.npc[Main.wof].life < Main.npc[Main.wof].lifeMax * 0.1F)
					{
						npc.localAI[1] += 2f;
						num8 += 3;
					}
				}
				if (npc.localAI[2] == 0)
				{
					if (npc.localAI[1] <= 600)
						return false;
					npc.localAI[2] = 1f;
					npc.localAI[1] = 0.0f;
				}
				else
				{
					if (npc.localAI[1] <= 45 || !Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
						return false;
					npc.localAI[1] = 0;
					++npc.localAI[2];
					if (npc.localAI[2] >= num8)
						npc.localAI[2] = 0;
					if (!flag)
						return false;
					float num9 = 9f;
					int Damage = 11;
					int Type = 83;
					if (Main.npc[Main.wof].life < Main.npc[Main.wof].lifeMax * 0.5F)
					{
						++Damage;
						++num9;
					}
					if (Main.npc[Main.wof].life < Main.npc[Main.wof].lifeMax * 0.25F)
					{
						++Damage;
						++num9;
					}
					if (Main.npc[Main.wof].life < Main.npc[Main.wof].lifeMax * 0.1F)
					{
						Damage += 2;
						num9 += 2f;
					}
					vector2 = new Vector2(npc.position.X + npc.width * 0.5F, npc.position.Y + npc.height * 0.5F);
					float num10 = Main.player[npc.target].position.X + Main.player[npc.target].width * 0.5F - vector2.X;
					float num11 = Main.player[npc.target].position.Y + Main.player[npc.target].height * 0.5F - vector2.Y;
					float num12 = (float)Math.Sqrt(num10 * num10 + num11 * num11);
					float num13 = num9 / num12;
					float SpeedX = num10 * num13;
					float SpeedY = num11 * num13;
					vector2.X += SpeedX;
					vector2.Y += SpeedY;
					Projectile.NewProjectile(vector2.X, vector2.Y, SpeedX, SpeedY, Type, Damage, 0.0f, Main.myPlayer, 0.0f, 0.0f);
				}
			}
			return false;
		}
	}
}
