using Terraria.ID;
using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	public class ShadowHand : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadow Hand");
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.width = 30;
			npc.height = 30;
			npc.damage = 60;
			npc.defense = 25;
			npc.lifeMax = 780;
			npc.knockBackResist = 1.1f;
			npc.noGravity = true;
			npc.behindTiles = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit9;
			npc.DeathSound = SoundID.NPCDeath11;
		}

		public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
		{
			if (Main.expertMode)
				target.AddBuff(153, 180);
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}


		public override bool PreAI()
		{
			if (npc.justHit)
				npc.ai[1] = 10f;
			if (Main.wof < 0)
			{
				npc.active = false;
			}
			else
			{
				npc.TargetClosest(true);
				float num1 = 0.1f;
				float num2 = 300f;
				if (Main.npc[Main.wof].life < Main.npc[Main.wof].lifeMax * 0.25F)
				{
					npc.damage = (int)(75 * Main.damageMultiplier);
					npc.defense = 40;
					if (!Main.expertMode)
						num2 = 900;
					else
						num1 += 0.1F;
				}
				else if (Main.npc[Main.wof].life < Main.npc[Main.wof].lifeMax * 0.5F)
				{
					npc.damage = (int)(60 * (double)Main.damageMultiplier);
					npc.defense = 30;
					if (!Main.expertMode)
						num2 = 700;
					else
						num1 += 0.066F;
				}
				else if (Main.npc[Main.wof].life < Main.npc[Main.wof].lifeMax * 0.75F)
				{
					npc.damage = (int)(45 * Main.damageMultiplier);
					npc.defense = 20;
					if (!Main.expertMode)
						num2 = 500;
					else
						num1 += 0.033F;
				}
				if (Main.expertMode)
				{
					npc.defense = npc.defDefense;
					if (npc.whoAmI % 4 == 0)
						num2 *= 1.75F;
					if (npc.whoAmI % 4 == 1)
						num2 *= 1.5F;
					if (npc.whoAmI % 4 == 2)
						num2 *= 1.25F;
					if (npc.whoAmI % 3 == 0)
						num2 *= 1.5F;
					if (npc.whoAmI % 3 == 1)
						num2 *= 1.25F;
					num2 *= 0.75F;
				}
				float x = Main.npc[Main.wof].position.X + (Main.npc[Main.wof].width / 2);
				float num3 = Main.npc[Main.wof].position.Y;
				float num4 = (Main.wofB - Main.wofT);
				float y = Main.wofT + num4 * npc.ai[0];
				++npc.ai[2];
				if (npc.ai[2] > 100)
				{
					num2 = (int)(num2 * 1.29999995231628F);
					if (npc.ai[2] > 200)
						npc.ai[2] = 0.0F;
				}
				Vector2 vector2 = new Vector2(x, y);
				float num5 = Main.player[npc.target].position.X + (Main.player[npc.target].width / 2) - (npc.width / 2) - vector2.X;
				float num6 = Main.player[npc.target].position.Y + (Main.player[npc.target].height / 2) - (npc.height / 2) - vector2.Y;
				float num7 = (float)Math.Sqrt(num5 * num5 + num6 * num6);
				if (npc.ai[1] == 0)
				{
					if (num7 > num2)
					{
						float num8 = num2 / num7;
						num5 *= num8;
						num6 *= num8;
					}
					if (npc.position.X < x + num5)
					{
						npc.velocity.X = npc.velocity.X + num1;
						if (npc.velocity.X < 0 && num5 > 0)
							npc.velocity.X = npc.velocity.X + num1 * 2.5F;
					}
					else if (npc.position.X > x + num5)
					{
						npc.velocity.X = npc.velocity.X - num1;
						if (npc.velocity.X > 0.0 && num5 < 0)
							npc.velocity.X = npc.velocity.X - num1 * 2.5F;
					}
					if (npc.position.Y < y + num6)
					{
						npc.velocity.Y = npc.velocity.Y + num1;
						if (npc.velocity.Y < 0.0 && num6 > 0)
							npc.velocity.Y = npc.velocity.Y + num1 * 2.5F;
					}
					else if (npc.position.Y > y + num6)
					{
						npc.velocity.Y = npc.velocity.Y - num1;
						if (npc.velocity.Y > 0.0 && num6 < 0.0)
							npc.velocity.Y = npc.velocity.Y - num1 * 2.5f;
					}
					float num9 = 4f;
					if (Main.expertMode && Main.wof >= 0)
					{
						float num8 = 1.5f;
						float num10 = (Main.npc[Main.wof].life / Main.npc[Main.wof].lifeMax);
						if (num10 < 0.75)
							num8 += 0.7f;
						if (num10 < 0.5)
							num8 += 0.7f;
						if (num10 < 0.25)
							num8 += 0.9f;
						if (num10 < 0.1)
							num8 += 0.9f;
						float num11 = num8 * 1.25f + 0.3f;
						num9 += num11 * 0.35f;
						if (npc.Center.X < Main.npc[Main.wof].Center.X && Main.npc[Main.wof].velocity.X > 0.0)
							num9 += 6f;
						if (npc.Center.X > Main.npc[Main.wof].Center.X && Main.npc[Main.wof].velocity.X < 0.0)
							num9 += 6f;
					}
					if (npc.velocity.X > num9)
						npc.velocity.X = num9;
					if (npc.velocity.X < -num9)
						npc.velocity.X = -num9;
					if (npc.velocity.Y > num9)
						npc.velocity.Y = num9;
					if (npc.velocity.Y < -num9)
						npc.velocity.Y = -num9;
				}
				else if (npc.ai[1] > 0)
					--npc.ai[1];
				else
					npc.ai[1] = 0;
				if (num5 > 0)
				{
					npc.spriteDirection = 1;
					npc.rotation = (float)Math.Atan2(num6, num5);
				}
				if (num5 < 0.0)
				{
					npc.spriteDirection = -1;
					npc.rotation = (float)Math.Atan2(num6, num5) + 3.14f;
				}
				Lighting.AddLight((int)(npc.position.X + (npc.width / 2)) / 16, (int)(npc.position.Y + (npc.height / 2)) / 16, 0.3f, 0.2f, 0.1f);
			}

			return false;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, 99, 1f);
				Gore.NewGore(npc.position, npc.velocity, 99, 1f);
				Gore.NewGore(npc.position, npc.velocity, 99, 1f);
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y,
				mod.NPCType("ShadowHandTwo"));
			}
		}


		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter++;
			if (npc.frameCounter >= 15)
			{
				npc.frame.Y = (npc.frame.Y + frameHeight) % (Main.npcFrameCount[npc.type] * frameHeight);
				npc.frameCounter = 0;
			}

			npc.spriteDirection = -npc.direction;
		}
	}
}
