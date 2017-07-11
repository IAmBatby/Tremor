using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs {
  
public class WoodlingWarrior : ModNPC
{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Woodling Warrior");
			Main.npcFrameCount[npc.type] = 10;
		}
 

    public override void SetDefaults()
    {
        npc.lifeMax = 160;
        npc.damage = 27;
        npc.defense = 14;
        npc.knockBackResist = 0.3f;
        npc.width = 56;
        npc.height = 48;
        aiType = 429;
        animationType = 429;
        npc.aiStyle = 3;
        npc.npcSlots = 0.2f;
        npc.HitSound = SoundID.NPCHit37;
        npc.DeathSound = SoundID.NPCDeath57;
        npc.value = Item.buyPrice(0, 0, 6, 9);
        banner = npc.type;
        bannerItem = mod.ItemType("WoodlingWarriorBanner");
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
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 9);
        }
        if(Main.rand.Next(3) == 0)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ManaFruit"), Main.rand.Next(1,2));
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
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WoodlingGore4"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WoodlingGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WoodlingGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WoodlingGore3"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WoodlingGore3"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WoodlingGore5"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WoodlingGore5"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WoodlingGore5"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WoodlingGore5"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WoodlingGore5"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WoodlingGore5"), 1f);

        }
}

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        int x = spawnInfo.spawnTileX;
        int y = spawnInfo.spawnTileY;
        int tile = (int)Main.tile[x, y].type;
        return (Tremor.NormalSpawn(spawnInfo) && Tremor.NoZoneAllowWater(spawnInfo)) && !Main.dayTime && NPC.downedBoss2 && y < Main.worldSurface ? 0.001f : 0f;
    }
}}