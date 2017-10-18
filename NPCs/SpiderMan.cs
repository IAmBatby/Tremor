using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace Tremor.NPCs
{
	public class SpiderMan : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spider Man");
			Main.npcFrameCount[npc.type] = 15;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 400;
			npc.damage = 80;
			npc.defense = 25;
			npc.knockBackResist = 1f;
			npc.width = 46;
			npc.height = 50;
			animationType = 21;
			npc.aiStyle = 26;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit47;
			npc.DeathSound = SoundID.NPCDeath23;
			npc.value = Item.buyPrice(0, 0, 25, 0);
			banner = npc.type;
			bannerItem = mod.ItemType("SpiderManBanner");
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool(2))
				this.NewItem(ItemID.SpiderFang, Main.rand.Next(60, 150));
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SpiderManGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SpiderManGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SpiderManGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SpiderManGore2"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.spiderCave ? 0.08f : 0f;
	}
}