using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs {
  
public class OrcChampion : ModNPC
{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Orc Champion");
			Main.npcFrameCount[npc.type] = 20;
		}
 
    public override void SetDefaults()
    {
        npc.lifeMax = 500;
        npc.damage = 25;
        npc.defense = 32;
        npc.knockBackResist = 0.1f;
        npc.width = 40;
        npc.height = 40;
        animationType = 482;
        npc.aiStyle = 3;
        aiType = 482;
        npc.npcSlots = 0.8f;
        npc.HitSound = SoundID.NPCHit1;
	npc.buffImmune[20] = true;
	npc.buffImmune[24] = true;
	npc.buffImmune[39] = true;
	npc.buffImmune[31] = false;
        npc.DeathSound = SoundID.NPCDeath27;
        npc.value = Item.buyPrice(0, 0, 25, 0);
        banner = npc.type;
        bannerItem = mod.ItemType("OrcChampionBanner");
    }

    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        npc.lifeMax = (int)(npc.lifeMax * 1);
        npc.damage = (int)(npc.damage * 1);
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        if(npc.life <= 0)
        {
                Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1.7f);
                Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 2.7f);
                Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/OCGore1"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/OCGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/OCGore3"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/OCGore3"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/OCGore4"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/OCGore4"), 1f);
            for(int k = 0; k < 20; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1.7f);   
                Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.6f);   
            }
        }
}

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        int x = spawnInfo.spawnTileX;
        int y = spawnInfo.spawnTileY;
        int tile = (int)Main.tile[x, y].type;
        return (Tremor.NormalSpawn(spawnInfo) && Tremor.NoZoneAllowWater(spawnInfo)) && Main.hardMode && !Main.dayTime && y < Main.worldSurface ? 0.005f : 0f;
    }
}}