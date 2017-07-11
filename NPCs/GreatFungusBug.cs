using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class GreatFungusBug : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Great Fungus Bug");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 50;
			npc.damage = 25;
			npc.defense = 10;
			npc.knockBackResist = 0.2f;
			npc.width = 33;
			npc.height = 33;
			animationType = 34;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.aiStyle = 14;
			aiType = 34;
			npc.npcSlots = 5f;
			npc.HitSound = SoundID.NPCHit35;
			npc.DeathSound = SoundID.NPCDeath57;
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 1);
			npc.damage = (int)(npc.damage * 1);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FungalBugGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FungalBugGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FungalBugGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FungalBugGore3"), 1f);
				for (int k = 0; k < 60; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 67, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 67, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
			}
			else
			{
				for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 67, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
			}
		}
	}
}