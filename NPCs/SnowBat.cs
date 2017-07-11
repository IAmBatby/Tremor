using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs {
  
public class SnowBat : ModNPC
{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Snow Bat");
			Main.npcFrameCount[npc.type] = 5;
		}
 

    public override void SetDefaults()
    {
        npc.lifeMax = 30;
        npc.damage = 16;
        npc.defense = 5;
        npc.knockBackResist = 0.3f;
        npc.width = 22;
        npc.height = 18;
        animationType = 49;
        npc.aiStyle = 14;
        npc.npcSlots = 0.2f;
        npc.HitSound = SoundID.NPCHit1;
        npc.noGravity = true;
        npc.DeathSound = SoundID.NPCDeath4;
        npc.value = Item.buyPrice(0, 0, 2, 9);
        banner = npc.type;
        bannerItem = mod.ItemType("SnowBatBanner");
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
        if(Main.rand.Next(1) == 0)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 593);
        }
        }
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        if(npc.life <= 0)
        {
            for(int k = 0; k < 20; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 76, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1f);
                Dust.NewDust(npc.position, npc.width, npc.height, 76, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1f);
            }
                Dust.NewDust(npc.position, npc.width, npc.height, 76, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 3f);
                Dust.NewDust(npc.position, npc.width, npc.height, 76, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 2f);
                Dust.NewDust(npc.position, npc.width, npc.height, 76, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 3f);
        }
}

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        int x = spawnInfo.spawnTileX;
        int y = spawnInfo.spawnTileY;
        int tile = (int)Main.tile[x, y].type;
        return (Tremor.NoZoneAllowWater(spawnInfo)) && Main.cloudAlpha > 0f && y < Main.worldSurface && spawnInfo.player.ZoneSnow ? 0.01f : 0f;
    }
}}