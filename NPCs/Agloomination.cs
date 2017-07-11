using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs {

public class Agloomination : ModNPC
{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Agloomination");
			Main.npcFrameCount[npc.type] = 3;
		}
 
    public override void SetDefaults()
    {
        npc.lifeMax =  600;
        npc.damage = 90;
        npc.defense = 24;
        npc.knockBackResist = 0.6f;
        npc.width = 38;
        npc.height = 44;
        animationType = 141;
        npc.aiStyle = 1;
        npc.npcSlots = 1f;
        npc.HitSound = SoundID.NPCHit1;
        npc.DeathSound = SoundID.NPCDeath1;
        npc.value = Item.buyPrice(0, 0, 12, 24);
        banner = npc.type;
        bannerItem = mod.ItemType("AgloominationBanner");
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
        return (Tremor.NoZoneAllowWater(spawnInfo)) && NPC.downedPlantBoss &&  y > Main.rockLayer ? 0.01f : 0f;
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