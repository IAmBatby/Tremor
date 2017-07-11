using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
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
if (Main.netMode != 1) 
{ 
int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16; 
int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16; 
int halfLength = npc.width / 2 / 16 + 1; 
Helper.DropItem(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), new Drop(mod.ItemType("AntlionFury"), 1, 1), new Drop(mod.ItemType("Hurricane"), 1, 2), new Drop(mod.ItemType("SandShuriken"), 1, 2), new Drop(mod.ItemType("CrawlerHook"), 1, 1), new Drop(0, 0, 0)); 
Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 500, Main.rand.Next(10));
Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 499, Main.rand.Next(10));
Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 327);
} 
}

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        int x = spawnInfo.spawnTileX;
        int y = spawnInfo.spawnTileY;
        int tile = (int)Main.tile[x, y].type;
        return (Tremor.NoZoneAllowWater(spawnInfo)) && Main.hardMode && spawnInfo.player.ZoneDesert &&  y > Main.rockLayer ? 0.01f : 0f;
    }
    }
}