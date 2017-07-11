using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs {

public class Shnoot : ModNPC
{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shnoot");
			Main.npcFrameCount[npc.type] = 3;
		}
 
    public override void SetDefaults()
    {
        npc.lifeMax = 300;
        npc.damage = 23;
        npc.defense = 34;
        npc.knockBackResist = 0.3f;
        npc.width = 130;
        npc.height = 140;
        animationType = 141;
        npc.aiStyle = 1;
        npc.npcSlots = 1f;
        npc.HitSound = SoundID.NPCHit1;
        npc.DeathSound = SoundID.NPCDeath17;
        npc.value = Item.buyPrice(0, 0, 1, 24);
        banner = npc.type;
        bannerItem = mod.ItemType("ShnootBanner");
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
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Gloomstone"), Main.rand.Next(6,15));
        }
        if(Main.rand.Next(2) == 0)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RockHorn"), Main.rand.Next(1,3));
        }
        }
    }

    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        npc.lifeMax = (int)(npc.lifeMax * 1);
        npc.damage = (int)(npc.damage * 1);
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        int x = spawnInfo.spawnTileX;
        int y = spawnInfo.spawnTileY;
        int tile = (int)Main.tile[x, y].type;
        return (Tremor.NoZoneAllowWater(spawnInfo)) && y > Main.rockLayer ? 0.005f : 0f;
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        if(npc.life <= 0)
        {
            for(int k = 0; k < 60; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
            }
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ShnootGore1"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ShnootGore1"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ShnootGore1"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ShnootGore1"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ShnootGore2"), 1f);
        }
        else
        {
            for(int k = 0; k < damage / npc.lifeMax * 50.0; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 5, (float)hitDirection, -1f, 0, default(Color), 0.7f);
                Dust.NewDust(npc.position, npc.width, npc.height, 5, (float)hitDirection, -1f, 0, default(Color), 0.7f);
                Dust.NewDust(npc.position, npc.width, npc.height, 5, (float)hitDirection, -1f, 0, default(Color), 0.7f);
            }
        }
}
}}