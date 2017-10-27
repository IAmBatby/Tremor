using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;
using Tremor.Items.Dark;

namespace Tremor.NPCs
{
	public class DarkServant : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Servant");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 1000;
			npc.damage = 140;
			npc.defense = 30;
			npc.knockBackResist = 0.3f;
			npc.width = 70;
			npc.height = 46;
			animationType = 244;
			npc.aiStyle = 41;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = Item.buyPrice(0, 0, 0, 0);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 191, 2.5f * hitDirection, -2.5f, 0, Color.Green, 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 191, 2.5f * hitDirection, -2.5f, 0, Color.Green, 0.7f);
				}

				Dust.NewDust(npc.position, npc.width, npc.height, 191, 2.5f * hitDirection, -2.5f, 0, Color.Green, 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 191, 2.5f * hitDirection, -2.5f, 0, Color.Green, 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 191, 2.5f * hitDirection, -2.5f, 0, Color.Green, 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 191, 2.5f * hitDirection, -2.5f, 0, Color.Green, 0.7f);
				Gore.NewGore(npc.position, npc.velocity, 99, 1f);
				Gore.NewGore(npc.position, npc.velocity, 99, 1f);
				Gore.NewGore(npc.position, npc.velocity, 99, 1f);
			}
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool(6))
				npc.NewItem(mod.ItemType<DarkGel>());
		}
	}
}