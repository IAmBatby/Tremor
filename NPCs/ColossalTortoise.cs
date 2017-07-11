using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs {
  
public class ColossalTortoise : ModNPC
{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Colossal Tortoise");
			Main.npcFrameCount[npc.type] = 16;
		}
 
    public override void SetDefaults()
    {
        npc.lifeMax = 25000;
        npc.damage = 200;
        npc.defense = 300;
        npc.knockBackResist = 0.0f;
				npc.width = 146;
				npc.height = 86;
        animationType = 21;
        npc.aiStyle = 3;
        aiType = 28;
        npc.npcSlots = 0.3f;
        npc.HitSound = SoundID.NPCHit24;
        npc.DeathSound = SoundID.NPCDeath10;
        npc.value = Item.buyPrice(0, 4, 15, 0);
    }

    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        npc.lifeMax = (int)(npc.lifeMax * 1);
        npc.damage = (int)(npc.damage * 1);
    }

        public override void AI()
        {

Lighting.AddLight(npc.position, 1f, 0.3f, 0.3f);

        if(Main.rand.Next(750) == 0)
        {
            NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, 153);
        }

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
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GiantShell"), Main.rand.Next(1,3));
        }
        if(Main.rand.Next(3) == 0)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LostTurtleKnife"), Main.rand.Next(10,55));
        }
        }
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        if(npc.life <= 0)
        {
            for(int k = 0; k < 60; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 3, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
                Dust.NewDust(npc.position, npc.width, npc.height, 3, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
                Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
            }
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ColossusTortoiseGore1"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ColossusTortoiseGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ColossusTortoiseGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ColossusTortoiseGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ColossusTortoiseGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ColossusTortoiseGore3"), 1f);
        }
        else
        {

            for(int k = 0; k < damage / npc.lifeMax * 50.0; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 3, (float)hitDirection, -2f, 0, default(Color), 0.7f);
                Dust.NewDust(npc.position, npc.width, npc.height, 5, (float)hitDirection, -1f, 0, default(Color), 0.7f);
            }
        }
    }  

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        int x = spawnInfo.spawnTileX;
        int y = spawnInfo.spawnTileY;
        int tile = (int)Main.tile[x, y].type;
        return (Tremor.NormalSpawn(spawnInfo) && Tremor.NoZoneAllowWater(spawnInfo)) && spawnInfo.player.ZoneJungle && NPC.downedMoonlord && Main.hardMode && y < Main.worldSurface ? 0.0002f : 0f;
    }
    
}}