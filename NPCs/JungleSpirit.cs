using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Tremor.NPCs
{

    public class JungleSpirit : ModNPC
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Jungle Spirit");
			Main.npcFrameCount[npc.type] = 4;
		}
 
        public override void SetDefaults()
        {
            npc.lifeMax = 140;
            npc.damage = 15;
            npc.defense = 14;
            npc.knockBackResist = 0.3f;
            npc.width = 34;
            npc.height = 48;
            animationType = 316;
            npc.aiStyle = 22;
            npc.npcSlots = 0.4f;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit44;
            npc.noGravity = true;
            npc.DeathSound = SoundID.NPCDeath58;
            npc.value = Item.buyPrice(0, 0, 4, 15);
            banner = npc.type;
            bannerItem = mod.ItemType("JungleSpiritBanner");
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 1);
            npc.damage = (int)(npc.damage * 1);
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);

                }
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/JungleSpiritGore"), 1f);
            }

        }
     

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
            int y = spawnInfo.spawnTileY;
            int tile = (int)Main.tile[x, y].type;
            return (Tremor.NormalSpawn(spawnInfo) && Tremor.NoZoneAllowWater(spawnInfo)) && spawnInfo.player.ZoneJungle && y > Main.rockLayer ? 0.005f : 0f;
         }
      }
    }



