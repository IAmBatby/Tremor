using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace Tremor.NPCs
{
	public class Naga : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Naga");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 2000;
			npc.damage = 130;
			npc.defense = 30;
			npc.knockBackResist = 1f;
			npc.width = 46;
			npc.height = 44;
			animationType = 3;
			npc.aiStyle = 26;
			npc.npcSlots = 1f;
			//npc.soundHit = 7;
			//npc.soundKilled = 10;
			npc.value = Item.buyPrice(0, 5, 3, 2);
		}

		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			player.AddBuff(BuffID.Venom, 300, true);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/NagaGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/NagaGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/NagaGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/NagaGore3"), 1f);
			}
			else
			{
				for (int k = 0; k < damage / npc.lifeMax * 50; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 59, hitDirection, -1f, 0, default(Color), 0.7f);
			}
		}
	}
}