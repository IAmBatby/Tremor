using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs {
  
public class Polaris : ModNPC
{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Polaris");
			Main.npcFrameCount[npc.type] = 10;
		}

    public override void SetDefaults()
    {
        npc.lifeMax = 125;
        npc.damage = 20;
        npc.defense = 12;
        npc.knockBackResist = 0.4f;
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
        bannerItem = mod.ItemType("PolarisBanner");
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
        if(Main.rand.Next(20) == 0)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FrostFreshness"));
        };
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
                Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1f);
                Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.8f);
            }
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PolarisGore1"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PolarisGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PolarisGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PolarisGore3"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PolarisGore3"), 1f);
                Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1f);
                Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 2f);
                Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1f);

        }
}

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        int x = spawnInfo.spawnTileX;
        int y = spawnInfo.spawnTileY;
        int tile = (int)Main.tile[x, y].type;
        return (Tremor.NoZoneAllowWater(spawnInfo)) && Main.cloudAlpha > 0f && y < Main.worldSurface && spawnInfo.player.ZoneSnow ? 0.03f : 0f;
    }
}}