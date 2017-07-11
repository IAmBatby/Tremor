using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Mobs
{

	public class Zombomber : ModNPC
{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zombomber");
			Main.npcFrameCount[npc.type] = 17;
		}
 
    public override void SetDefaults()
    {
        npc.lifeMax = 200;
        npc.damage = 25;
        npc.defense = 14;
        npc.knockBackResist = 0.3f;
        npc.width = 36;
        npc.height = 44;
animationType = 555;
        npc.aiStyle = 107;
        npc.npcSlots = 0.5f;
        aiType = 555;
        npc.HitSound = SoundID.NPCHit1;
        npc.DeathSound = SoundID.NPCDeath2;
        npc.value = Item.buyPrice(0, 0, 4, 7);
        banner = npc.type;
        bannerItem = mod.ItemType("ZombomberBanner");
    }

    public override void NPCLoot()
    {
        if (Main.netMode != 1)
        {
            int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
            int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
            int halfLength = npc.width / 2 / 16 + 1;
        if(Main.rand.Next(5) == 0)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 168, Main.rand.Next(2,3));
        }
        if(Main.rand.Next(5) == 0)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 166, Main.rand.Next(2,3));
        }
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
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZombomberGore1"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZombomberGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZombomberGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FarmGore3"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FarmGore3"), 1f);
        }
}

}}