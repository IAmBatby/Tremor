using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class Hellhound : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hellhound");
			Main.npcFrameCount[npc.type] = 12;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 10000;
			npc.damage = 160;
			npc.defense = 70;
			npc.knockBackResist = 0.2f;
			npc.width = 50;
			npc.height = 44;
			animationType = 423;
			npc.aiStyle = 26;
			npc.npcSlots = 0.5f;
			npc.lavaImmune = true;
			npc.buffImmune[24] = true;
			npc.buffImmune[67] = true;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath21;
			npc.value = Item.buyPrice(0, 0, 40, 0);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("HellhoundBanner");
		}

		public override void AI()
		{
			if (Main.rand.NextBool(4))
				Main.dust[Dust.NewDust(npc.position, npc.width, npc.height, 6, 0f, 0f, 200, npc.color)].velocity *= 0.3F;

			Vector2 vector72 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
			float num738 = Main.player[npc.target].position.X + Main.player[npc.target].width * 0.5f - vector72.X;
			float num739 = Main.player[npc.target].position.Y - vector72.Y;
			float num740 = (float)Math.Sqrt(num738 * num738 + num739 * num739);

			if (npc.ai[2] == 1f)
			{
				npc.ai[1] += 1f;
				npc.velocity.X = npc.velocity.X * 0.7f;
				if (npc.ai[1] < 30f)
				{
					Vector2 vector73 = npc.Center + Vector2.UnitX * npc.spriteDirection * -20f;
					Dust newDust = Main.dust[Dust.NewDust(vector73, 0, 0, 6, 0f, 0f, 0, default(Color), 1f)];
					Vector2 vector74 = Vector2.UnitY.RotatedByRandom(6.2831854820251465);
					newDust.position = vector73 + vector74 * 20f;
					newDust.velocity = -vector74 * 2f;
					newDust.scale = 0.5f + vector74.X * -(float)npc.spriteDirection;
					newDust.fadeIn = 1f;
					newDust.noGravity = true;
				}
				else if (npc.ai[1] == 30f)
				{
					for (int num743 = 0; num743 < 20; num743++)
					{
						Vector2 vector75 = npc.Center + Vector2.UnitX * npc.spriteDirection * -20f;
						Dust newDust = Main.dust[Dust.NewDust(vector75, 0, 0, 6, 0f, 0f, 0, default(Color), 1f)];
						Vector2 vector76 = Vector2.UnitY.RotatedByRandom(6.2831854820251465);
						newDust.position = vector75 + vector76 * 4f;
						newDust.velocity = vector76 * 4f + Vector2.UnitX * Main.rand.NextFloat() * npc.spriteDirection * -5f;
						newDust.scale = 0.5f + vector76.X * -(float)npc.spriteDirection;
						newDust.fadeIn = 1f;
						newDust.noGravity = true;
					}
				}
				if (npc.velocity.X > -0.5f && npc.velocity.X < 0.5f)
					npc.velocity.X = 0f;
				if (npc.ai[1] == 30f && Main.netMode != 1)
				{
					int num744 = Main.expertMode ? 35 : 50;
					Projectile.NewProjectile(npc.Center.X + npc.spriteDirection * -20, npc.Center.Y, npc.spriteDirection * -7, 0f, 467, num744, 0f, Main.myPlayer, npc.target, 0f);
				}
				if (npc.ai[1] >= 60f)
				{
					npc.ai[1] = -(float)Main.rand.Next(320, 601);
					npc.ai[2] = 0f;
				}
			}
			else
			{
				npc.ai[1] += 1f;
				if (npc.ai[1] >= 180f && num740 < 500f && npc.velocity.Y == 0f)
				{
					npc.ai[1] = 0f;
					npc.ai[2] = 1f;
					npc.netUpdate = true;
				}
				else if (npc.velocity.Y == 0f && num740 < 100f && Math.Abs(npc.velocity.X) > 3f && ((npc.Center.X < Main.player[npc.target].Center.X && npc.velocity.X > 0f) || (npc.Center.X > Main.player[npc.target].Center.X && npc.velocity.X < 0f)))
				{
					npc.velocity.Y = npc.velocity.Y - 4f;
				}
			}
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool())
				this.NewItem(mod.ItemType<FireFragment>(), Main.rand.Next(2, 4));
			if (Main.rand.Next(25) == 0)
				this.NewItem(mod.ItemType<FlamesofDespair>());
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 60; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HellhoundGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HellhoundGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HellhoundGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HellhoundGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HellhoundGore3"), 1f);
			}
			else
			{

				for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 6, hitDirection, -2f, 0, default(Color), 1.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 6, hitDirection, -1f, 0, default(Color), 0.7f);
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> (Helper.NoZoneAllowWater(spawnInfo)) && NPC.downedMoonlord && spawnInfo.spawnTileY > Main.maxTilesY - 200 ? 0.002f : 0f;
	}
}