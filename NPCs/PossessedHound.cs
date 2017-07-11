using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs {
  
public class PossessedHound : ModNPC
{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Possessed Hound");
			Main.npcFrameCount[npc.type] = 10;
		}
 
    public override void SetDefaults()
    {
        npc.lifeMax = 3200;
        npc.damage = 180;
        npc.defense = 50;
        npc.knockBackResist = 0.1f;
				npc.width = 46;
				npc.height = 30;
        animationType = 329;
        npc.aiStyle = 26;
        npc.npcSlots = 0.3f;
        npc.HitSound = SoundID.NPCHit2;
        npc.DeathSound = SoundID.NPCDeath5;
        npc.value = Item.buyPrice(0, 0, 15, 0);
    }

    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        npc.lifeMax = (int)(npc.lifeMax * 1);
        npc.damage = (int)(npc.damage * 1);
    }

        public override void AI()
        {

if (Main.rand.Next(1000) == 0)
							{
								Main.PlaySound(22, (int)npc.position.X, (int)npc.position.Y, 1);
							}
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
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ConcentratedEther"));
        }
        }
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        if(npc.life <= 0)
        {
            for(int k = 0; k < 20; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
            }
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HoundGore3"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HoundGore1"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HoundGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HoundGore2"), 1f);
        }
}
    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        int x = spawnInfo.spawnTileX;
        int y = spawnInfo.spawnTileY;
        int tile = (int)Main.tile[x, y].type;
        return (Tremor.NormalSpawn(spawnInfo) && Tremor.NoZoneAllowWater(spawnInfo)) && NPC.downedMoonlord && Main.hardMode && Main.bloodMoon && y < Main.worldSurface ? 0.007f : 0f;
    }
    
}}