using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs {

public class GhostKnight : ModNPC
{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ghost Knight");
			Main.npcFrameCount[npc.type] = 4;
		}
 
    public override void SetDefaults()
    {
        npc.lifeMax =  500;
        npc.damage = 80;
        npc.defense = 26;
        npc.knockBackResist = 0.6f;
        npc.width = 38;
        npc.height = 44;
        animationType = 82;
npc.noGravity = true;
            npc.noTileCollide = true;
        npc.aiStyle = 22;
        aiType = 82;
        npc.npcSlots = 1f;
        npc.HitSound = SoundID.NPCHit54;
        npc.DeathSound = SoundID.NPCDeath52;
        npc.value = Item.buyPrice(0, 0, 8, 0);
        banner = npc.type;
        bannerItem = mod.ItemType("GhostKnightBanner");
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
        return (Tremor.NoZoneAllowWater(spawnInfo)) && NPC.downedPlantBoss && !Main.dayTime && y < Main.worldSurface ? 0.01f : 0f;
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        if(npc.life <= 0)
        {
            for(int k = 0; k < 60; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 54, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
            }
            for(int k = 0; k < 20; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
            }
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GhostGore1"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GhostGore2"), 1f);
        }
        else
        {
            for(int k = 0; k < damage / npc.lifeMax * 50.0; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 54, (float)hitDirection, -1f, 0, default(Color), 0.7f);
                Dust.NewDust(npc.position, npc.width, npc.height, 54, (float)hitDirection, -1f, 0, default(Color), 0.7f);
                Dust.NewDust(npc.position, npc.width, npc.height, 54, (float)hitDirection, -1f, 0, default(Color), 0.7f);
            }
        }
}
}}