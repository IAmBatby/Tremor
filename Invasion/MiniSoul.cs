using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Invasion
{
	public class MiniSoul : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paradox Soul");
			Main.npcFrameCount[npc.type] = 3;
		}

		int num;
		public readonly IList<int> targets = new List<int>();
		public static readonly int arenaWidth = (int)(1.3f * NPC.sWidth);
		public static readonly int arenaHeight = (int)(1.3f * NPC.sHeight);
		public override void SetDefaults()
		{
			npc.lifeMax = 450;
			npc.damage = 150;
			npc.defense = 30;
			npc.knockBackResist = 0f;
			npc.width = 28;
			npc.height = 30;
			npc.aiStyle = 87;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath42;
			npc.value = Item.buyPrice(0, 3, 0, 0);
			animationType = 3;
		}


		public override void NPCLoot()
		{

		}

		private void SettingNumber()
		{
			if (Main.rand.Next(2) == 1)
			{
				num++;
			}

			else
			{
				num--;
			}
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 10; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType<CyberDust>(), 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}

				CyberWrathInvasion modPlayer = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>(mod);
				if (InvasionWorld.CyberWrath && Main.rand.Next(4) == 1)
				{
					InvasionWorld.CyberWrathPoints1 += 1;
					//Main.NewText(("Wave 1: Complete " + TremorWorld.CyberWrathPoints + "%"), 39, 86, 134);
				}
			}

			for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType<CyberDust>(), hitDirection, -1f, 0, default(Color), 0.7f);
			}
		}
	}
}