using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs {
  
public class BetaWolf : ModNPC
{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Beta Wolf");
			Main.npcFrameCount[npc.type] = 9;
		}
 
    public override void SetDefaults()
    {
        npc.lifeMax = 62;
        npc.damage = 25;
        npc.defense = 6;
        npc.knockBackResist = 0.6f;
        npc.width = 68;
        npc.height = 33;
        animationType = 155;
        npc.aiStyle = 26;
        npc.npcSlots = 0.4f;
        npc.HitSound = SoundID.NPCHit6;
        npc.DeathSound = SoundID.NPCDeath5;
        npc.value = Item.buyPrice(0, 0, 4, 0);
    }

    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        npc.lifeMax = (int)(npc.lifeMax * 1);
        npc.damage = (int)(npc.damage * 1);
    }

    public override void NPCLoot()
    {
        if (Main.netMode != 1)
        {
            int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
            int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
            int halfLength = npc.width / 2 / 16 + 1;
        if(Main.rand.Next(2) == 0)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WolfPelt"), Main.rand.Next(1,2));
        }
        if(Main.rand.Next(25) == 0)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FurCoat"));
        };
        }
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        if(npc.life <= 0)
        {
            for(int k = 0; k < 20; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
            }
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BetaWolfGore1"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BetaWolfGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WolfGore1"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WolfGore1"), 1f);
        }
}

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        int x = spawnInfo.spawnTileX;
        int y = spawnInfo.spawnTileY;
        int tile = (int)Main.tile[x, y].type;
        return (Tremor.NormalSpawn(spawnInfo) && Tremor.NoZoneAllowWater(spawnInfo)) &&  spawnInfo.player.ZoneSnow && y < Main.worldSurface ? 0.01f : 0f;
    }
}}