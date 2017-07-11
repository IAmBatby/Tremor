using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Tremor.NPCs {
  
public class NorthWind : ModNPC
{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("North Wind");
			Main.npcFrameCount[npc.type] = 4;
		}
 
    public override void SetDefaults()
    {
        npc.lifeMax = 80;
        npc.damage = 15;
        npc.defense = 8;
        npc.knockBackResist = 0.7f;
        npc.width = 24;
        npc.height = 44;
        animationType = 82;
        npc.aiStyle = 22;
        npc.npcSlots = 0.4f;
        npc.noTileCollide = true;
        npc.HitSound = SoundID.NPCHit1;
	npc.alpha = 100;
        npc.noGravity = true;
        npc.DeathSound = SoundID.NPCDeath6;
        npc.value = Item.buyPrice(0, 0, 7, 15);
        banner = npc.type;
        bannerItem = mod.ItemType("NorthWindBanner");
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
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FrostCore"));
        };
        if(NPC.downedMoonlord && Main.rand.Next(5) == 0)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IceSoul"));
        }
        }
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        if(npc.life <= 0)
        {
            for(int k = 0; k < 20; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
                Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1.7f);
                Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1.7f);
            }

                Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
                Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 2.7f);
                Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 2.7f);
                Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1.7f);
        }
}


    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        int x = spawnInfo.spawnTileX;
        int y = spawnInfo.spawnTileY;
        int tile = (int)Main.tile[x, y].type;
        return (Tremor.NoZoneAllowWater(spawnInfo)) && Main.cloudAlpha > 0f && y < Main.worldSurface && spawnInfo.player.ZoneSnow ? 0.06f : 0f;
    }
}}