using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs {
  
public class FlyingLeech : ModNPC
{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flying Leech");
			Main.npcFrameCount[npc.type] = 2;
		}
 
    public override void SetDefaults()
    {
        npc.lifeMax = 80;
        npc.damage = 20;
        npc.defense = 10;
        npc.knockBackResist = 0.5f;
        npc.width = 74;
        npc.height = 42;
        animationType = 2;
        npc.aiStyle = 2;
        npc.noGravity = true;
        npc.npcSlots = 1f;
        npc.HitSound = SoundID.NPCHit1;
        npc.DeathSound = SoundID.NPCDeath1;
        npc.value = Item.buyPrice(0, 0, 32, 20);
        banner = npc.type;
        bannerItem = mod.ItemType("FlyingLeechBanner");
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
        return (Tremor.NormalSpawn(spawnInfo) && Tremor.NoZoneAllowWater(spawnInfo)) && NPC.downedBoss2 && spawnInfo.player.ZoneCrimson && y < Main.worldSurface ? 0.02f : 0;
    }
}}