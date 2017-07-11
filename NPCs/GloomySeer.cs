using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class GloomySeer : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gloomy Seer");
			Main.npcFrameCount[npc.type] = 5;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 250;
			npc.damage = 22;
			npc.defense = 10;
			npc.knockBackResist = 0.3f;
			npc.width = 40;
			npc.height = 40;
			animationType = 156;
			npc.aiStyle = 22;
			npc.npcSlots = 15f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.noGravity = true;
			npc.value = Item.buyPrice(0, 0, 2, 50);
			banner = npc.type;
			bannerItem = mod.ItemType("GloomySeerBanner");
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 1);
			npc.damage = (int)(npc.damage * 1);
		}

		public override void AI()
		{

			npc.ai[0] += 1f;
			if (npc.ai[0] == 20f || npc.ai[0] == 40f || npc.ai[0] == 60f || npc.ai[0] == 80f)
			{
				if (Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
				{
					float num630 = 2.2f;
					Vector2 vector64 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
					float num631 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector64.X + (float)Main.rand.Next(-100, 101);
					float num632 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector64.Y + (float)Main.rand.Next(-100, 101);
					float num633 = (float)Math.Sqrt((double)(num631 * num631 + num632 * num632));
					num633 = num630 / num633;
					num631 *= num633;
					num632 *= num633;
					int num634 = 21;
					int num635 = 83;
					int num636 = Projectile.NewProjectile(vector64.X, vector64.Y, num631, num632, num635, num634, 0f, Main.myPlayer, 0f, 0f);
					Main.projectile[num636].timeLeft = 3000;
				}
			}
			else if (npc.ai[0] >= (float)(150 + Main.rand.Next(150)))
			{
				npc.ai[0] = 0f;
			}

		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return (Tremor.NormalSpawn(spawnInfo) && Tremor.NoZoneAllowWater(spawnInfo)) && Main.bloodMoon && y < Main.worldSurface ? 0.001f : 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1.2f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GSGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GSGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GSGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GSGore3"), 1f);
			}
		}

	}
}