using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	public class PharaohCaster : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pharaoh Caster");
			Main.npcFrameCount[npc.type] = 3;
		}
 
		public override void SetDefaults()
		{
			npc.width = 40;
			npc.height = 40;
			npc.damage = 19;
			npc.defense = 16;
			npc.lifeMax = 210;
			npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath6;
                        npc.value = Item.buyPrice(0, 1, 5, 7);
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 8;
			aiType = 32;
			animationType = 32;
        banner = npc.type;
        bannerItem = mod.ItemType("PharaohCasterBanner");
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
        return (Tremor.NormalSpawn(spawnInfo) && Tremor.NoZoneAllowWater(spawnInfo)) && !Main.dayTime && NPC.downedBoss1 && Main.dayTime && y < Main.worldSurface ? 0.01f : 0f;
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        if(npc.life <= 0)
        {
            for(int k = 0; k < 20; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
            }
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PharaonGore1"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PharaonGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PharaonGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PharaonGore3"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PharaonGore3"), 1f);
        }
}

	}
}
