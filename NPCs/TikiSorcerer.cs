using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class TikiSorcerer : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tiki Sorcerer");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 80;
			npc.damage = 25;
			npc.defense = 3;
			npc.knockBackResist = 0.6f;
			npc.width = 30;
			npc.height = 46;
			animationType = 29;
			npc.aiStyle = 8;
			npc.npcSlots = 15f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = Item.buyPrice(0, 0, 0, 0);
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(45) == 0)
				this.NewItem(mod.ItemType<WoodenFrame>());
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TSGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TSGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TSGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TSGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TSGore3"), 1f);
			}
		}
	}
}