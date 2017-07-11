using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	[AutoloadBossHead]

	public class TheDarkEmperor : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Dark Emperor");
			Main.npcFrameCount[npc.type] = 14;
		}



		public override void SetDefaults()
		{
			npc.width = 126;
			npc.height = 106;
			npc.damage = 200;
			npc.defense = 170;
			npc.lifeMax = 100000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 80000f;
			npc.knockBackResist = 0.0f;
			music = 17;
			npc.aiStyle = 87;
			aiType = 475;
			animationType = 473;
			npc.npcSlots = 10f;
			npc.buffImmune[20] = true;
			npc.buffImmune[24] = true;
			npc.buffImmune[39] = true;
		}

		public override void AI()
		{
			if (Main.rand.Next(500) == 0)
			{
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("DarkServant"));
			}
			if (Main.rand.Next(150) == 0)
			{
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("DarkSlime"));
			}

		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = npc.lifeMax * 1;
			npc.damage = npc.damage * 1;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 60; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 191, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 191, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 191, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Main.PlaySound(15, 0);
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("TheDarkEmperorTwo"));
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("DarkServant"));
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("DarkServant"));
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("DarkServant"));
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("DarkServant"));
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("DarkServant"));
				Gore.NewGore(npc.position, npc.velocity, 99, 3f);
				Gore.NewGore(npc.position, npc.velocity, 99, 2f);
				Gore.NewGore(npc.position, npc.velocity, 99, 3f);
				Gore.NewGore(npc.position, npc.velocity, 99, 2f);
				Gore.NewGore(npc.position, npc.velocity, 99, 1f);
				Gore.NewGore(npc.position, npc.velocity, 99, 2f);
				Gore.NewGore(npc.position, npc.velocity, 99, 4f);
				Gore.NewGore(npc.position, npc.velocity, 99, 2f);
				Gore.NewGore(npc.position, npc.velocity, 99, 1f);
				Gore.NewGore(npc.position, npc.velocity, 99, 2f);
			}
			else
			{

				for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 191, hitDirection, -2f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 191, hitDirection, -1f, 0, default(Color), 0.7f);
				}
			}
		}

	}
}