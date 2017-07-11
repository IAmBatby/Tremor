using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Mobs
{

	public class Zombat : ModNPC
{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zombat");
			Main.npcFrameCount[npc.type] = 4;
		}
 
    public override void SetDefaults()
    {
        npc.lifeMax = 50;
        npc.damage = 10;
        npc.defense = 22;
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
        bannerItem = mod.ItemType("ZombatBanner");
    }

    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
    {
        npc.lifeMax = npc.lifeMax * 1;
        npc.damage = npc.damage * 1;
    }    

public override void HitEffect(int hitDirection, double damage)
    {
        if(npc.life <= 0)
        {
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZombatGore1"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZombatGore2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZombatGore3"), 1f);
        }
    }    

    public override void NPCLoot()
    {
        if (Main.netMode != 1)
        {
            int centerX = (int)(npc.position.X + npc.width / 2) / 16;
            int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
            int halfLength = npc.width / 2 / 16 + 1;
        if(Main.rand.Next(25) == 0)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornWings"));
        };
        }
    }
}}