using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Tremor.NPCs {
  
public class Zarprite : ModNPC
{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zarprite");
			Main.npcFrameCount[npc.type] = 4;
		}
 
    public override void SetDefaults()
    {
        npc.lifeMax = 150;
        npc.damage = 10;
        npc.defense = 12;
        npc.knockBackResist = 0.3f;
        npc.width = 34;
        npc.height = 48;
        animationType = 75;
        npc.aiStyle = 14;
        npc.npcSlots = 0.5f;
        npc.HitSound = SoundID.NPCHit35;
        npc.noGravity = true;
        npc.DeathSound = SoundID.NPCDeath57;
        npc.value = Item.buyPrice(0, 0, 15, 0);
        banner = npc.type;
        bannerItem = mod.ItemType("ZarpriteBanner");
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
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZarpriteGore"), 1f);
NPC.NewNPC((int)npc.position.X - 6, (int)npc.position.Y + 6, mod.NPCType("Parasprite"));
NPC.NewNPC((int)npc.position.X + 6, (int)npc.position.Y, mod.NPCType("Parasprite"));
NPC.NewNPC((int)npc.position.X, (int)npc.position.Y - 6, mod.NPCType("Parasprite"));
        }
    }    
    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        int x = spawnInfo.spawnTileX;
        int y = spawnInfo.spawnTileY;
        int tile = (int)Main.tile[x, y].type;
        return (Tremor.NoZoneAllowWater(spawnInfo)) &&  y > Main.rockLayer ? 0.01f : 0f;
    }
}}