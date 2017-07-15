using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Mobs
{

	public class Zombeast : ModNPC
{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zombeast");
			Main.npcFrameCount[npc.type] = 10;
		}
 

    public override void SetDefaults()
    {
        npc.lifeMax = 500;
        npc.damage = 30;
        npc.defense = 12;
        npc.knockBackResist = 0.4f;
        npc.width = 56;
        npc.height = 48;
        aiType = 429;
        animationType = 429;
        npc.aiStyle = 3;
        npc.npcSlots = 0.2f;
        npc.HitSound = SoundID.NPCHit37;
        npc.DeathSound = SoundID.NPCDeath57;
        npc.value = Item.buyPrice(0, 0, 6, 9);
        banner = npc.type;
        bannerItem = mod.ItemType("ZombeastBanner");
    }

    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        npc.lifeMax = npc.lifeMax * 1;
        npc.damage = npc.damage * 1;
    }

    public override void NPCLoot()
    {
        if (Main.netMode != 1)
        {
            int centerX = (int)(npc.position.X + npc.width / 2) / 16;
            int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
            int halfLength = npc.width / 2 / 16 + 1;
        if(Main.rand.NextBool())
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WickedHeart"));
        }
        if(Main.rand.Next(30) == 0)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Zombeast"));
        }
        }
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        if(npc.life <= 0)
        {
            for(int k = 0; k < 20; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 1f);
                Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.8f);
            }
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZombeastGore1"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZombeastGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZombeastGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZombeastGore3"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZombeastGore3"), 1f);
                Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 1f);
                Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 2f);
                Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 1f);

        }
}
}}