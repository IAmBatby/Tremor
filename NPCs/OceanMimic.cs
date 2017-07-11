using Microsoft.Xna.Framework;
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
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + npc.width / 2) / 16;
				int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
				int halfLength = npc.width / 2 / 16 + 1;
				Helper.DropItem(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), new Drop(mod.ItemType("TheTide"), 1, 1), new Drop(mod.ItemType("TrueTrident"), 1, 1), new Drop(mod.ItemType("SharkRage"), 1, 1), new Drop(mod.ItemType("OceanAmulet"), 1, 1), new Drop(mod.ItemType("SquidTentacle"), 1, 1));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 500, Main.rand.Next(10));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 499, Main.rand.Next(10));
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = Main.tile[x, y].type;
			return (Tremor.NormalSpawn(spawnInfo) && (tile == 53 || tile == 112 || tile == 116 || tile == 234) && Tremor.NoZoneAllowWater(spawnInfo) && spawnInfo.water) && Main.hardMode && y < Main.rockLayer && (x < 250 || x > Main.maxTilesX - 250) && !spawnInfo.playerSafe ? 0.01f : 0f;
		}
	}
}