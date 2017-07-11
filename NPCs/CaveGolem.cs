using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Tremor.NPCs {

public class CaveGolem : ModNPC
{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cave Golem");
			Main.npcFrameCount[npc.type] = 20;
		}
 
    public override void SetDefaults()
    {
        npc.lifeMax = 80;
        npc.damage = 20;
        npc.defense = 17;
        npc.knockBackResist = 0.3f;
        aiType = 77;
        npc.width = 36;
        npc.height = 44;
        animationType = 482;
        npc.aiStyle = 3;
        npc.npcSlots = 0.9f;
        npc.HitSound = SoundID.NPCHit4;
        npc.DeathSound = SoundID.NPCDeath6;
        npc.value = Item.buyPrice(0, 0, 4, 9);
        banner = npc.type;
        bannerItem = mod.ItemType("CaveGolemBanner");
    }

    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        npc.lifeMax = (int)(npc.lifeMax * 1);
        npc.damage = (int)(npc.damage * 1);
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        if(npc.life <= 0)
        {
            for(int k = 0; k < 20; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
            }
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CaveGolemGore1"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CaveGolemGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CaveGolemGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CaveGolemGore3"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CaveGolemGore3"), 1f);
        }
}

    public override void NPCLoot()
    {
        if (Main.netMode != 1)
        {
            int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
            int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
            int halfLength = npc.width / 2 / 16 + 1;

        if(Main.rand.Next(30) == 0)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ColossusSword"));
        }
        }
    }


    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        int x = spawnInfo.spawnTileX;
        int y = spawnInfo.spawnTileY;
        int tile = (int)Main.tile[x, y].type;
        return (Tremor.NoZoneAllowWater(spawnInfo)) && y > Main.rockLayer ? 0.01f : 0f;
    }

}}