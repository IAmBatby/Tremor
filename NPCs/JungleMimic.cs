using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	public class JungleMimic : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Jungle Mimic");
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
			Helper.DropItems(npc.position, npc.Size, new Drop(mod.ItemType("SporeBlade"), 1, 1), new Drop(mod.ItemType("TechnologyofDionysus"), 1, 2), new Drop(mod.ItemType("LivingWoodThreepeater"), 1, 2), new Drop(mod.ItemType("UnfathomableFlower"), 1, 1));
			this.NewItem(ItemID.GreaterHealingPotion, Main.rand.Next(10));
			this.NewItem(ItemID.GreaterManaPotion, Main.rand.Next(10));
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> (Helper.NoZoneAllowWater(spawnInfo)) && Main.hardMode && spawnInfo.player.ZoneJungle && spawnInfo.spawnTileY > Main.rockLayer ? 0.003f : 0f;
	}
}