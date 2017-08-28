using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	public class Lizard : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lizard");
			Main.npcFrameCount[npc.type] = 6;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 30;
			npc.damage = 18;
			npc.defense = 9;
			npc.knockBackResist = 0.6f;
			npc.width = 42;
			npc.height = 22;
			animationType = 102;
			npc.aiStyle = 26;
			npc.npcSlots = 15f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = Item.buyPrice(0, 0, 0, 0);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/LizardGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/LizardGore2"), 1f);
			}
		}
	}
}