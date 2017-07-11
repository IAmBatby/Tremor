using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Mobs
{

	public class SpearZombie : ModNPC
{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zombie Spearman");
			Main.npcFrameCount[npc.type] = 15;
		}
 
    public override void SetDefaults()
    {
        npc.lifeMax = 150;
        npc.damage = 36;
        npc.defense = 24;
        npc.knockBackResist = 0.3f;
        npc.width = 36;
        npc.height = 44;
        animationType = 21;
        npc.aiStyle = 26;
        npc.npcSlots = 0.5f;
        npc.HitSound = SoundID.NPCHit2;
        npc.DeathSound = SoundID.NPCDeath2;
        npc.value = Item.buyPrice(0, 0, 4, 7);
        banner = npc.type;
        bannerItem = mod.ItemType("SpearZombieBanner");
    }

    public override void HitEffect(int hitDirection, double damage)
    {
        if(npc.life <= 0)
        {
            for(int k = 0; k < 20; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
            }
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZombieSpearHead"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DeadlingArm"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DeadlingArm"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DeadlingLeg"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DeadlingLeg"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZombieSpearGore"), 1f);
        }
}

}}