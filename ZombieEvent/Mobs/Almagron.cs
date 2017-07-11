using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Mobs
{
	public class Almagron : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Almagron");
			Main.npcFrameCount[npc.type] = 10;
		}
 
		public override void SetDefaults()
		{
			npc.width = 85;
			npc.height = 85;
			npc.damage = 141;
			npc.defense = 30;
			npc.lifeMax = 2500;
		npc.HitSound = SoundID.NPCHit4;
		npc.DeathSound = SoundID.NPCDeath6;
                        npc.value = Item.buyPrice(0, 0, 28, 7);
			npc.knockBackResist = 0.3f;
			npc.aiStyle = 3;
			aiType = 343;
			animationType = 343;
				npc.buffImmune[20] = true;
				npc.buffImmune[31] = false;
				npc.buffImmune[24] = true;
        banner = npc.type;
        bannerItem = mod.ItemType("AlmagronBanner");
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
        if(Main.rand.Next(22) == 0)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ChargedLamp"));
        }
        if(Main.rand.Next(25) == 0)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DreadLance"));
        }
        if(Main.rand.Next(20) == 0)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DreadLance"));
        }
        }
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        if(npc.life <= 0)
        {
            for(int k = 0; k < 20; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 31, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
            }
            Gore.NewGore(npc.position, npc.velocity, 99, 1f);
            Gore.NewGore(npc.position, npc.velocity, 99, 1f);
            Gore.NewGore(npc.position, npc.velocity, 99, 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/IGGore1"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/IGGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/IGGore3"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/IGGore3"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/IGGore4"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/IGGore4"), 1f);
        }
}
	}
}
