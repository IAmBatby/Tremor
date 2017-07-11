using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Mobs
{

	public class FarmerZombie : ModNPC
{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Farmer Zombie");
			Main.npcFrameCount[npc.type] = 15;
		}
 
    public override void SetDefaults()
    {
        npc.lifeMax = 100;
        npc.damage = 26;
        npc.defense = 24;
        npc.knockBackResist = 0.3f;
        npc.width = 36;
        npc.height = 44;
        animationType = 21;
        npc.aiStyle = 3;
        npc.npcSlots = 0.5f;
        npc.HitSound = SoundID.NPCHit2;
        npc.DeathSound = SoundID.NPCDeath2;
        npc.value = Item.buyPrice(0, 0, 4, 7);
        banner = npc.type;
        bannerItem = mod.ItemType("FarmerZombieBanner");
    }

    public override void NPCLoot()
    {
        if (Main.netMode != 1)
        {
            int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
            int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
            int halfLength = npc.width / 2 / 16 + 1;
        if(Main.rand.Next(4) == 0)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Tomato"), Main.rand.Next(1,2));
        };
        if(Main.rand.Next(4) == 0)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Potato"), Main.rand.Next(1,2));
        };
        if(Main.rand.Next(6) == 0)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Carrot"), Main.rand.Next(1,6));
        };
        if(Main.rand.Next(6) == 0)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Wheat"), Main.rand.Next(1,6));
        };
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
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FarmForkGore"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FarmGore1"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FarmGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FarmGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FarmGore3"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FarmGore3"), 1f);
        }
}

}}