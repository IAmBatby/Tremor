using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace Tremor.NPCs
{
	public class ExuberantHound : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Exuberant Hound");
			Main.npcFrameCount[npc.type] = 12;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 3000;
			npc.damage = 120;
			npc.defense = 60;
			npc.knockBackResist = 0.2f;
			npc.width = 50;
			npc.height = 44;
			animationType = 423;
			npc.aiStyle = 26;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit18;
			npc.DeathSound = SoundID.NPCDeath21;
			npc.value = Item.buyPrice(0, 0, 40, 0);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("ExuberantHoundBanner");
		}

		/*
		 * 
		 * 
		 * 
		 */

		public override void AI()
		{
			Vector2 npcCenter = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
			float targetX = Main.player[npc.target].position.X + Main.player[npc.target].width * 0.5f - npcCenter.X;
			float targetY = Main.player[npc.target].position.Y - npcCenter.Y;
			float targetLength = (float)Math.Sqrt(targetX * targetX + targetY * targetY);

			if (npc.ai[2] == 1f)
			{
				npc.ai[1]++;
				npc.velocity.X = npc.velocity.X * 0.7f;
				if (npc.ai[1] < 30f)
				{
					Vector2 newDustLocation = npc.Center + Vector2.UnitX * npc.spriteDirection * -20f;
					Dust newDust = Main.dust[Dust.NewDust(newDustLocation, 0, 0, 242, 0f, 0f, 0, default(Color), 1f)];
					Vector2 randomDirection = Vector2.UnitY.RotatedByRandom(Math.PI * 2);
					newDust.position = newDustLocation + randomDirection * 20f;
					newDust.velocity = -randomDirection * 2f;
					newDust.scale = 0.5f + randomDirection.X * -npc.spriteDirection;
					newDust.fadeIn = 1f;
					newDust.noGravity = true;
				}
				else if (npc.ai[1] == 30f)
				{
					for (int i = 0; i < 20; i++)
					{
						Vector2 newDustLocation = npc.Center + Vector2.UnitX * npc.spriteDirection * -20f;
						Dust newDust = Main.dust[Dust.NewDust(newDustLocation, 0, 0, 242, 0f, 0f, 0, default(Color), 1f)];
						Vector2 randomDirection = Vector2.UnitY.RotatedByRandom(Math.PI * 2);
						newDust.position = newDustLocation + randomDirection * 4f;
						newDust.velocity = randomDirection * 4f + Vector2.UnitX * Main.rand.NextFloat() * npc.spriteDirection * -5f;
						newDust.scale = 0.5f + randomDirection.X * -npc.spriteDirection;
						newDust.fadeIn = 1f;
						newDust.noGravity = true;
					}
				}
				
				if (npc.velocity.X > -0.5f && npc.velocity.X < 0.5f)
					npc.velocity.X = 0f;

				if (npc.ai[1] == 30f && Main.netMode != 1)
				{
					int projectileDamage = Main.expertMode ? 35 : 50;
					Projectile.NewProjectile(npc.Center.X + npc.spriteDirection * -20, npc.Center.Y, npc.spriteDirection * -7, 0f, ProjectileID.MartianTurretBolt, projectileDamage, 0f, Main.myPlayer, npc.target, 0f);
				}

				if (npc.ai[1] >= 60f)
				{
					npc.ai[1] = -Main.rand.Next(320, 601);
					npc.ai[2] = 0f;
				}
			}
			else
			{
				npc.ai[1]++;
				if (npc.ai[1] >= 180f && targetLength < 500f && npc.velocity.Y == 0f)
				{
					npc.ai[1] = 0f;
					npc.ai[2] = 1f;
					npc.netUpdate = true;
				}
				else if (npc.velocity.Y == 0f && targetLength < 100f && Math.Abs(npc.velocity.X) > 3f && ((npc.Center.X < Main.player[npc.target].Center.X && npc.velocity.X > 0f) || (npc.Center.X > Main.player[npc.target].Center.X && npc.velocity.X < 0f)))
				{
					npc.velocity.Y = npc.velocity.Y - 4f;
				}
			}
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool())
				npc.NewItem(mod.ItemType("ConcentratedEther"), Main.rand.Next(2, 4));
			if (Main.rand.NextBool(5))
				npc.NewItem(mod.ItemType("ToothofAbraxas"), Main.rand.Next(1, 3));
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 60; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 226, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 226, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 27, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ExuberantHoundGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ExuberantHoundGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ExuberantHoundGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ExuberantHoundGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ExuberantHoundGore3"), 1f);
			}
			else
			{
				for (int k = 0; k < damage / npc.lifeMax * 50; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 226, hitDirection, -2f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 27, hitDirection, -1f, 0, default(Color), 0.7f);
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> (Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo)) && NPC.downedMoonlord && Main.hardMode && !Main.dayTime && spawnInfo.spawnTileY < Main.worldSurface ? 0.001f : 0f;
	}
}