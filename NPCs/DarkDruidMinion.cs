using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace Tremor.NPCs
{
	public class DarkDruidMinion : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Druid Minion");
			Main.npcFrameCount[npc.type] = 15;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 30;
			npc.damage = 20;
			npc.defense = 5;
			npc.knockBackResist = 0.3f;
			npc.width = 36;
			npc.height = 44;
			animationType = 21;
			npc.aiStyle = 3;
			//npc.npcSlots = 1f;
			npc.HitSound = SoundID.NPCHit2;
			aiType = 77;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = Item.buyPrice(0, 0, 0, 0);
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool(2))
				npc.NewItem(ItemID.Heart);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				for (int i = 0; i < 2; ++i)
				{
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UndeadGore1"), 1f);
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UndeadGore2"), 1f);
				}
			}
		}
	}
}