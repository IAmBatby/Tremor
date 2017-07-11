using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs {
  
public class FireBeetle : ModNPC
{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fire Beetle");
			Main.npcFrameCount[npc.type] = 6;
		}
 
    public override void SetDefaults()
    {
        npc.lifeMax = 3000;
        npc.damage = 150;
        npc.defense = 72;
        npc.knockBackResist = 0.1f;
        npc.width = 40;
        npc.height = 40;
          animationType = 508;
        npc.aiStyle = 3;
        aiType = 508;
        npc.npcSlots = 0.5f;
        npc.HitSound = SoundID.NPCHit41;
	npc.buffImmune[20] = true;
	npc.buffImmune[24] = true;
	npc.buffImmune[39] = true;
	npc.buffImmune[31] = false;
        npc.DeathSound = SoundID.NPCDeath44;
        npc.value = Item.buyPrice(0, 0, 12, 0);
        banner = npc.type;
        bannerItem = mod.ItemType("FireBeetleBanner");
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
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 175, 3);
        }
        if(Main.rand.Next(2) == 0)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FireFragment"), 3);
        }
        }
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        if(npc.life <= 0)
        {
                Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1.7f);
                Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 2.7f);
                Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FBGore1"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FBGore3"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FBGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FBGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FBGore2"), 1f);
            for(int k = 0; k < 20; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1.7f);   
                Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.6f);   
            }
        }
}

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        int x = spawnInfo.spawnTileX;
        int y = spawnInfo.spawnTileY;
        int tile = (int)Main.tile[x, y].type;
        return (Tremor.NormalSpawn(spawnInfo) && NPC.downedMoonlord && Tremor.NoZoneAllowWater(spawnInfo)) && y > Main.rockLayer ? 0.01f : 0f;
    }
}}