using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class Gurd : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gurd");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 100;
			npc.damage = 20;
			npc.defense = 14;
			npc.knockBackResist = 0.3f;
			npc.width = 38;
			npc.height = 44;
			animationType = 141;
			npc.aiStyle = 1;
			npc.npcSlots = 1f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath17;
			npc.value = Item.buyPrice(0, 0, 1, 24);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("GurdBanner");
		}

		public override void NPCLoot()
		{
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + npc.width / 2) / 16;
				int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
				int halfLength = npc.width / 2 / 16 + 1;
				if (Main.rand.Next(27) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RedPuzzleFragment"));
				}
			}
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = npc.lifeMax * 1;
			npc.damage = npc.damage * 1;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.spawnTileY < Main.rockLayer && NPC.downedBoss1 && Main.dayTime ? 0.005f : 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 60; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GrudGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GrudGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GrudGore2"), 1f);
			}
			else
			{
				for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 5, hitDirection, -1f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 5, hitDirection, -1f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 5, hitDirection, -1f, 0, default(Color), 0.7f);
				}
			}
		}
	}
}