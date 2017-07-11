using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq; 
using System.Collections.Generic;

namespace Tremor.NPCs {

public class CometHead : ModNPC
{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Comet Head");
			Main.npcFrameCount[npc.type] = 3;
		}
 
    public override void SetDefaults()
    {
        npc.lifeMax = 600;
        npc.damage = 130;
        npc.defense = 65;
        npc.knockBackResist = 0.5f;
        npc.width = 20;
        npc.height = 20;
        animationType = 288;
        aiType = 288;
        npc.aiStyle = 56;
        npc.npcSlots = 15f;
        npc.noTileCollide = true;
        npc.noGravity = true;
        npc.HitSound = SoundID.NPCHit3;
        npc.noGravity = true;
        npc.DeathSound = SoundID.NPCDeath5;
        npc.value = Item.buyPrice(0, 0, 4, 9);
    }

    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        npc.lifeMax = (int)(npc.lifeMax * 1);
        npc.damage = (int)(npc.damage * 1);
    }


        public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
            int[] TileArray2 = { mod.TileType("CometiteOreTile"), mod.TileType("HardCometiteOreTile") };
            return TileArray2.Contains(Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY].type) ? 15f : 0f;        
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
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CometiteOre"), Main.rand.Next(1,2));
        }
        if(Main.rand.Next(5) == 0)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ChargedCrystal"), Main.rand.Next(1,2));
        }
        }
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        if(npc.life <= 0)
        {
                Dust.NewDust(npc.position, npc.width, npc.height, 59, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1.7f);
                Dust.NewDust(npc.position, npc.width, npc.height, 59, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 2.7f);
                Dust.NewDust(npc.position, npc.width, npc.height, 59, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
                Dust.NewDust(npc.position, npc.width, npc.height, 59, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 2.7f);
                Dust.NewDust(npc.position, npc.width, npc.height, 59, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
            for(int k = 0; k < 20; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 59, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1.7f);   
                Dust.NewDust(npc.position, npc.width, npc.height, 59, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.6f); 
                Dust.NewDust(npc.position, npc.width, npc.height, 59, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1.7f);   
                Dust.NewDust(npc.position, npc.width, npc.height, 59, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.6f);  
            }
        }
}

}}