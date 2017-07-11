using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace Tremor.NPCs {

public class LihzahrdWarrior : ModNPC
{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lihzahrd Warrior");
			Main.npcFrameCount[npc.type] = 16;
		}
 
    public override void SetDefaults()
    {
        npc.lifeMax = 1600;
        npc.damage = 160;
        npc.defense = 82;
        npc.knockBackResist = 0.05f;
        npc.width = 32;
        npc.height = 50;
        animationType = 198;
        npc.aiStyle = 3;
        aiType = 529;
        npc.npcSlots = 0.5f;
        npc.HitSound = SoundID.NPCHit4;
        npc.DeathSound = SoundID.NPCDeath2;
        npc.value = Item.buyPrice(0, 0, 8, 0);
        banner = npc.type;
        bannerItem = mod.ItemType("LihzahrdWarriorBanner");
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
        if(Main.rand.Next(6) == 0)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2766);
        }
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
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/LWGore1"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/LWGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/LWGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/LWGore3"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/LWGore3"), 1f);
        }
}

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        int x = spawnInfo.spawnTileX;
        int y = spawnInfo.spawnTileY;
        int tile = (int)Main.tile[x, y].type;
        return Main.hardMode && (tile == 226) && NPC.downedMoonlord && y > Main.rockLayer ? 0.01f : 0f;
    }
}}