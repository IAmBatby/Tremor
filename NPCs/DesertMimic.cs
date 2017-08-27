using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	public class DesertMimic : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Desert Mimic");
			Main.npcFrameCount[npc.type] = 14;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 3500;
			npc.damage = 90;
			npc.defense = 34;
			npc.knockBackResist = 0f;
			npc.width = 48;
			npc.height = 40;
			npc.aiStyle = 87;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = Item.buyPrice(0, 3, 0, 0);
			animationType = NPCID.BigMimicHallow;
		}

		public override void NPCLoot()
		{
			// Don't know what to do with this loot table.
			Helper.DropItems(npc.position, npc.Size, new Drop(mod.ItemType("AntlionFury"), 1, 1), new Drop(mod.ItemType("Hurricane"), 1, 2), new Drop(mod.ItemType("SandShuriken"), 1, 2), new Drop(mod.ItemType("CrawlerHook"), 1, 1));
			npc.SpawnItem(ItemID.GreaterHealingPotion, Main.rand.Next(10));
			npc.SpawnItem(ItemID.GreaterManaPotion, Main.rand.Next(10));
			npc.SpawnItem(ItemID.GoldenKey);
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NoZoneAllowWater(spawnInfo) && Main.hardMode && spawnInfo.player.ZoneDesert && spawnInfo.spawnTileY > Main.rockLayer ? 0.01f : 0f;
	}
}