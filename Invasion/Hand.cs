using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Tremor.Invasion
{
    public class Hand : ModNPC
    {
         //[1] id head

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paradox Titan Hand");
		}

        public override void SetDefaults()
        {
            npc.lifeMax = 40000;
            npc.damage = 100;
            npc.defense = 50;
            npc.knockBackResist = 0.5f;
            npc.width = 44;
            npc.height = 84;
            npc.aiStyle = 12;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.value = Item.buyPrice(0, 0, 5, 0);
        }

    public override void HitEffect(int hitDirection, double damage)
    {
        if(npc.life <= 0)
        {

        }
    }  
        public override bool PreNPCLoot()
        {
            npc.aiStyle = -1;
            npc.ai[1] = -1;
            return false;
        }
    }
}