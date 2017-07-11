using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Mobs {

public class Arsonist : ModNPC
{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Arsonist");
			Main.npcFrameCount[npc.type] = 3;
		}
 
    public override void SetDefaults()
    {
        npc.lifeMax = 115;
        npc.damage = 20;
        npc.defense = 16;
        npc.knockBackResist = 0.3f;
        npc.width = 34;
        npc.height = 46;
        animationType = 3;
        npc.aiStyle = 3;
        npc.npcSlots = 2f;
        npc.HitSound = SoundID.NPCHit1;
        npc.DeathSound = SoundID.NPCDeath2;
        npc.value = Item.buyPrice(0, 0, 1, 0);
        banner = npc.type;
        bannerItem = mod.ItemType("ArsonistBanner");
    }

    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        npc.lifeMax = (int)(npc.lifeMax * 1);
        npc.damage = (int)(npc.damage * 1);
    }

        public override void AI()
        {
if (Main.rand.Next(4) == 0)
							{
								int num706 = Dust.NewDust(npc.position, npc.width, npc.height, 6, 0f, 0f, 200, npc.color, 1f);
								Main.dust[num706].velocity *= 0.3f;
							}
        }

    public override void HitEffect(int hitDirection, double damage)
    {
        if(npc.life <= 0)
        {
            for(int k = 0; k < 20; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
            }
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DeadlingHead1"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DeadlingLeg"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DeadlingArm"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DeadlingLeg"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DeadlingArm"), 1f);
        }
}

    public override void OnHitPlayer(Player player, int damage, bool crit)
    {
        if(Main.rand.Next(1) == 0)
        {
            player.AddBuff(24, 60, true);
        }
    }

    public override void NPCLoot()
    {
        if (Main.netMode != 1)
        {
            int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
            int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
            int halfLength = npc.width / 2 / 16 + 1;
        if(Main.rand.Next(2) == 0)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 8, Main.rand.Next(1,2));
        };
        }
    }
}}