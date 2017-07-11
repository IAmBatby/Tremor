using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


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
					Dust.NewDust(npc.position, npc.width, npc.height, 191, 2.5f * (float)hitDirection, -2.5f, 0, Color.Green, 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 191, 2.5f * (float)hitDirection, -2.5f, 0, Color.Green, 0.7f);
				}
				Dust.NewDust(npc.position, npc.width, npc.height, 191, 2.5f * (float)hitDirection, -2.5f, 0, Color.Green, 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 191, 2.5f * (float)hitDirection, -2.5f, 0, Color.Green, 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 191, 2.5f * (float)hitDirection, -2.5f, 0, Color.Green, 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 191, 2.5f * (float)hitDirection, -2.5f, 0, Color.Green, 0.7f);
				Gore.NewGore(npc.position, npc.velocity, 99, 1f);
				Gore.NewGore(npc.position, npc.velocity, 99, 1f);
				Gore.NewGore(npc.position, npc.velocity, 99, 1f);
			}
		}

		public override void NPCLoot()
		{
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
				int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
				int halfLength = npc.width / 2 / 16 + 1;

				if (Main.rand.Next(6) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkGel"));
				}
			}
		}
	}
}