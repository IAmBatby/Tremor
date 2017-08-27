using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	public class OceanMimic : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ocean Mimic");
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
			Helper.DropItems(npc.position, npc.Size, new Drop(mod.ItemType("TheTide"), 1, 1), new Drop(mod.ItemType("TrueTrident"), 1, 1), new Drop(mod.ItemType("SharkRage"), 1, 1), new Drop(mod.ItemType("OceanAmulet"), 1, 1), new Drop(mod.ItemType("SquidTentacle"), 1, 1));
			this.NewItem(ItemID.GreaterHealingPotion, Main.rand.Next(10));
			this.NewItem(ItemID.GreaterManaPotion, Main.rand.Next(10));
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && (spawnInfo.spawnTileType == 53 || spawnInfo.spawnTileType == 112 || spawnInfo.spawnTileType == 116 || spawnInfo.spawnTileType == 234) && Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.water && Main.hardMode && spawnInfo.spawnTileY < Main.rockLayer && (spawnInfo.spawnTileX < 250 || spawnInfo.spawnTileX > Main.maxTilesX - 250) && !spawnInfo.playerSafe ? 0.01f : 0f;
	}
}