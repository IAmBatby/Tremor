using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Mobs
{

	public class TheHaunt : ModNPC
{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Haunt");
			Main.npcFrameCount[npc.type] = 4;
		}
 
        const int SpeedMulti = 3; // �����⥫� ᪮���

    public override void SetDefaults()
    {
        npc.lifeMax = 200;
        npc.damage = 74;
        npc.defense = 36;
        npc.knockBackResist = 0.3f;
        npc.width = 42;
        npc.height = 82;
	npc.alpha = 100;
        animationType = 82;
        npc.aiStyle = 22;
        npc.npcSlots = 0.5f;
        npc.noTileCollide = true;
        npc.HitSound = SoundID.NPCHit52;
        npc.noGravity = true;
        npc.DeathSound = SoundID.NPCDeath6;
        npc.value = Item.buyPrice(0, 0, 4, 9);
        banner = npc.type;
        bannerItem = mod.ItemType("TheHauntBanner");
    }


        public override void AI()
        {
if (NPC.AnyNPCs(mod.NPCType("Cryptomage")))
{
npc.Transform(mod.NPCType("SuperTheHaunt"));
}
        }

    public override void NPCLoot()
    {
        if (Main.netMode != 1)
        {
            int centerX = (int)(npc.position.X + npc.width / 2) / 16;
            int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
            int halfLength = npc.width / 2 / 16 + 1;
        if(Main.rand.Next(4) == 0)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CursedInk"));
        }
        }
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
            Gore.NewGore(npc.position, npc.velocity, 61, 1f);
            Gore.NewGore(npc.position, npc.velocity, 61, 1f);
            Gore.NewGore(npc.position, npc.velocity, 62, 1f);
            Gore.NewGore(npc.position, npc.velocity, 62, 1f);
            Gore.NewGore(npc.position, npc.velocity, 63, 1f);
            Gore.NewGore(npc.position, npc.velocity, 63, 1f);
        }
}

}}