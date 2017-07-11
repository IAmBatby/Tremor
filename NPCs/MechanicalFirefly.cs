using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs {

public class MechanicalFirefly : ModNPC
{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mechanical Firefly");
			Main.npcFrameCount[npc.type] = 9;
		}
 
    public override void SetDefaults()
    {
        npc.lifeMax = 3000;
        npc.damage = 115;
        npc.defense = 46;
        npc.knockBackResist = 0.1f;
        npc.width = 58;
        npc.height = 36;
        animationType = 509;
        npc.aiStyle = 44;
        npc.noGravity = true;
        aiType = 509;
        npc.npcSlots = 0.4f;
        npc.HitSound = SoundID.NPCHit4;
        npc.DeathSound = SoundID.NPCDeath6;
        npc.value = Item.buyPrice(0, 0, 40, 7);
        banner = npc.type;
        bannerItem = mod.ItemType("MechanicalFireflyBanner");
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
            for(int k = 0; k < 20; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
            }
            Gore.NewGore(npc.position, npc.velocity, 61, 1f);
            Gore.NewGore(npc.position, npc.velocity, 61, 1f);
            Gore.NewGore(npc.position, npc.velocity, 62, 1f);
            Gore.NewGore(npc.position, npc.velocity, 62, 1f);
            Gore.NewGore(npc.position, npc.velocity, 63, 1f);
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