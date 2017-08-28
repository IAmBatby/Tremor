using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class Grood : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Grood");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 1000;
			npc.damage = 70;
			npc.defense = 28;
			npc.knockBackResist = 0.3f;
			npc.width = 38;
			npc.height = 44;
			animationType = 141;
			npc.aiStyle = 41;
			npc.npcSlots = 1f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath17;
			npc.value = Item.buyPrice(0, 0, 5, 24);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("GroodBanner");
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(23) == 0)
				this.NewItem(mod.ItemType<YellowPuzzleFragment>());
			// No GiantRedFeather class in Tremor namespace.
			//if (Main.rand.Next(30) == 0)
			//	this.NewItem(mod.ItemType<GiantRedFeather>());
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 60; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GroodGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GroodGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GroodGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GroodGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GroodGore3"), 1f);
			}
			else
			{
				for (int k = 0; k < damage / npc.lifeMax * 50; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 5, hitDirection, -1f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 5, hitDirection, -1f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 5, hitDirection, -1f, 0, default(Color), 0.7f);
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> spawnInfo.spawnTileY < Main.rockLayer && Main.hardMode && Main.dayTime ? 0.001f : 0f;
	}
}