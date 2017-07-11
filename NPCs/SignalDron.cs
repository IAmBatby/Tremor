using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	public class SignalDron : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Signal Drone");
		}

		public override void SetDefaults()
		{
			npc.noTileCollide = true;
			npc.noGravity = true;
			npc.lifeMax = 1500;
			npc.damage = 75;
			npc.defense = 18;
			npc.knockBackResist = 0f;
			npc.width = 90;
			npc.height = 90;
			npc.aiStyle = 0;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath14;
		}

		public override void AI()
		{
			if (Main.npc[(int)npc.ai[3]].type != mod.NPCType("Motherboard") || !Main.npc[(int)npc.ai[3]].active)
			{
				npc.active = false;
				npc.netUpdate = true;
			}
			else if (npc.ai[0] == 0.0)
			{
				Vector2 vector2 = new Vector2(npc.Center.X, npc.Center.Y);
				float num1 = Main.npc[(int)npc.ai[3]].Center.X - vector2.X;
				float num2 = Main.npc[(int)npc.ai[3]].Center.Y - vector2.Y;
				float num3 = (float)Math.Sqrt(num1 * (double)num1 + num2 * (double)num2);
				if (num3 > 90.0)
				{
					float num4 = 8f / num3;
					float num5 = num1 * num4;
					float num6 = num2 * num4;
					npc.velocity.X = (float)((npc.velocity.X * 15.0 + num5) / 16.0);
					npc.velocity.Y = (float)((npc.velocity.Y * 15.0 + num6) / 16.0);
				}
				else
				{
					if (Math.Abs(npc.velocity.X) + (double)Math.Abs(npc.velocity.Y) < 8.0)
					{
						npc.velocity.Y *= 1.05f;
						npc.velocity.X *= 1.05f;
					}
					if (Main.netMode == 1 || (!Main.expertMode || Main.rand.Next(100) != 0) && Main.rand.Next(200) != 0)
						return;
					npc.TargetClosest(true);
					vector2 = new Vector2(npc.Center.X, npc.Center.Y);
					float num4 = Main.player[npc.target].Center.X - vector2.X;
					float num5 = Main.player[npc.target].Center.Y - vector2.Y;
					float num6 = 8f / (float)Math.Sqrt(num4 * (double)num4 + num5 * (double)num5);
					npc.velocity.X = num4 * num6;
					npc.velocity.Y = num5 * num6;
					npc.ai[0] = 1f;
					npc.netUpdate = true;
				}
			}
			else
			{
				if (Main.expertMode)
				{
					Vector2 vector2 = Main.player[npc.target].Center - npc.Center;
					vector2.Normalize();
					npc.velocity = (npc.velocity * 99f + vector2 * 9f) / 100f;
				}
				Vector2 vector2_1 = new Vector2(npc.Center.X, npc.Center.Y);
				float num1 = Main.npc[(int)npc.ai[3]].Center.X - vector2_1.X;
				float num2 = Main.npc[(int)npc.ai[3]].Center.Y - vector2_1.Y;
				if (Math.Sqrt(num1 * (double)num1 + num2 * (double)num2) <= 700.0 && !npc.justHit)
					return;
				npc.ai[0] = 0.0f;
			}
		}
	}
}