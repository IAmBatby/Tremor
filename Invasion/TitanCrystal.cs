using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Invasion
{
	public class TitanCrystal : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paradox Crystal");
			Main.npcFrameCount[npc.type] = 5;
		}

		public override void SetDefaults()
		{
			animationType = 523;
			npc.npcSlots = 0.3f;
			npc.damage = 150;
			npc.width = 36;
			npc.height = 38;
			npc.scale = 0.8f;
			npc.defense = 45;
			npc.lifeMax = 9500;
			npc.knockBackResist = 0f;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.value = Item.buyPrice(0, 0, 0, 0);
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
		}

		public override bool PreAI()
		{
			bool expertMode = Main.expertMode;
			npc.TargetClosest(true);
			Vector2 direction = Main.player[npc.target].Center - npc.Center;
			direction.Normalize();
			direction *= 9f;
			npc.rotation = 0f;
			Player player = Main.player[npc.target];
			NPC parent = Main.npc[NPC.FindFirstNPC(mod.NPCType("Titan"))];
			double deg = (double)npc.ai[1] / 2;
			double rad = deg * (Math.PI / 180);
			double dist = 250;
			npc.position.X = parent.Center.X - (int)(Math.Cos(rad) * dist) - npc.width / 2;
			npc.position.Y = parent.Center.Y - (int)(Math.Sin(rad) * dist) - npc.height / 2;
			npc.ai[1] += 2f;
			return false;
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.55f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.75f);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			for (int k = 0; k < 5; k++)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType<CyberDust>(), hitDirection, -1f, 0, default(Color), 1f);
			}
		}

		public override bool CheckActive()
		{
			return false;
		}
	}
}