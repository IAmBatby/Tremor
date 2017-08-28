using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class TikiWarrior : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tiki Warrior");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 120;
			npc.damage = 26;
			npc.defense = 5;
			npc.knockBackResist = 0.3f;
			npc.width = 56;
			npc.height = 48;
			animationType = 3;
			npc.aiStyle = 3;
			aiType = 73;
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
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TikiWarriorGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TikiWarriorGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TikIWarriorGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TikiWarriorGore3"), 1f);
			}
		}
	}
}