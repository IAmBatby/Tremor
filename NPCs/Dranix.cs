using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs {
  
public class Dranix : ModNPC
{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dranix");
			Main.npcFrameCount[npc.type] = 10;
		}
 

    public override void SetDefaults()
    {
        npc.lifeMax = 1600;
        npc.damage = 110;
        npc.defense = 20;
        npc.knockBackResist = 0.3f;
        npc.width = 56;
        npc.height = 48;
        aiType = 429;
        animationType = 429;
        npc.aiStyle = 3;
        npc.npcSlots = 0.2f;
        npc.HitSound = SoundID.NPCHit1;
        npc.DeathSound = SoundID.NPCDeath2;
        npc.value = Item.buyPrice(0, 0, 6, 9);
        banner = npc.type;
        bannerItem = mod.ItemType("DranixBanner");
    }

        public override void AI()
        {

if (Main.rand.Next(1000) == 0)
							{
								Main.PlaySound(22, (int)npc.position.X, (int)npc.position.Y, 1);
							}
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
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Doomstone"));
        }
        }
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        if(npc.life <= 0)
        {
            for(int k = 0; k < 20; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 74, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1f);
            }
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DranixGore1"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DranixGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DranixGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DranixGore3"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DranixGore3"), 1f);

        }
}

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        int x = spawnInfo.spawnTileX;
        int y = spawnInfo.spawnTileY;
        int tile = (int)Main.tile[x, y].type;
        return Main.hardMode && NPC.downedMoonlord && !spawnInfo.player.ZoneDungeon && y > Main.rockLayer ? 0.04f : 0f;
    }
}}