using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Mobs  {

public class Cryptomage : ModNPC
{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cryptomage");
			Main.npcFrameCount[npc.type] = 9;
		}
 
    public override void SetDefaults()
    {
        npc.lifeMax = 1250;
        npc.damage = 90;
        npc.defense = 30;
        npc.knockBackResist = 0.3f;
        npc.width = 34;
        npc.height = 34;
        animationType = 462;
        aiType = 462;
        npc.aiStyle = 3;
        npc.npcSlots = 0.2f;
        npc.scale *= 1f;
        npc.HitSound = SoundID.NPCHit2;
        npc.DeathSound = SoundID.NPCDeath2;
        npc.value = Item.buyPrice(0, 1, 12, 7);
        banner = npc.type;
        bannerItem = mod.ItemType("CryptomageBanner");
    }

    public override void NPCLoot()
    {
        if (Main.netMode != 1)
        {
            int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
            int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
            int halfLength = npc.width / 2 / 16 + 1;
        if(Main.rand.Next(1) == 0)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CryptStone"), Main.rand.Next(5,15));
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CursedCloth"), Main.rand.Next(5,15));
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
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CryptomageGore1"), 0.8f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CryptomageGore2"), 0.8f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CryptomageGore2"), 0.8f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CryptomageGore3"), 0.8f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CryptomageGore3"), 0.8f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CryptomageGore4"), 0.8f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CryptomageGore4"), 0.8f);
            NPC.NewNPC((int)npc.Center.X+30, (int)npc.Center.Y, mod.NPCType("Corpse2"));
            NPC.NewNPC((int)npc.Center.X-30, (int)npc.Center.Y, mod.NPCType("Corpse2"));
        }
}

}}