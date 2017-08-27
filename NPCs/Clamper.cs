using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	public class Clamper : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Clamper");
			Main.npcFrameCount[npc.type] = 3;
		}

		private const float MaxTargetDistance = 1200f; // maximum distance to target

		public override void SetDefaults()
		{
			npc.noTileCollide = true;
			npc.noGravity = true;
			npc.lifeMax = 5000;
			npc.damage = 100;
			npc.defense = 6;
			npc.knockBackResist = 0f;
			npc.width = 36;
			npc.height = 33;
			//aiType = 6;
			npc.aiStyle = -1; //5
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath14;
			animationType = 2;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("Clamper2"));
			}
		}

		public override bool CheckActive() => false;

		private NPC Motherboard => Main.npc[(int)npc.ai[3]];

		public override void AI()
		{
			if (npc.ai[2] == 1)
			{
				npc.velocity *= 0.999f;
				return;
			}

			CheckDead();

			// sp/server only, update ais
			if (Main.netMode != 1)
			{
				--npc.localAI[0];
				if (npc.localAI[0] <= 0.0)
				{
					npc.localAI[0] = Main.rand.Next(10, 26);
					npc.ai[0] = Main.rand.Next(-5, 14);
					npc.ai[1] = Main.rand.Next(-5, 14);
					npc.netUpdate = true;
				}
			}

			npc.TargetClosest();

			ControlVelocity();
			ControlRotation();

		}

		private new void CheckDead()
		{
			// turn to loose clamper when target is too far away?
			if (Main.player[Helper.GetNearestPlayer(npc.Center)].Distance(npc.position) > MaxTargetDistance)
			{
				int n = NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("Clamper2"));
				Main.npc[n].rotation = npc.rotation;
				Main.npc[n].velocity = npc.velocity;
				npc.active = false;
				npc.netUpdate = true;
			}
			// Motherboard has dead, kill ourselves
			if (Motherboard.type != mod.NPCType<Motherboard>() || !Motherboard.active)
			{
				npc.active = false;
				npc.netUpdate = true;
			}
		}

		private void ControlVelocity()
		{
			// random garbage from here, todo: refactor
			float num1 = 0.2f;
			float num2 = 10f;
			if (Motherboard.life < Motherboard.lifeMax * 0.25)
				num2 += 5f;
			if (Motherboard.life < Motherboard.lifeMax * 0.1)
				num2 += 5f;
			float x = Motherboard.position.X + Motherboard.width / 2;
			float y = Motherboard.position.Y + Motherboard.height / 2;
			Vector2 vector2 = new Vector2(x, y);
			float num3 = x + npc.ai[0];
			float num4 = y + npc.ai[1];
			float num5 = num3 - vector2.X;
			float num6 = num4 - vector2.Y;
			float num7 = (float)Math.Sqrt(num5 * (double)num5 + num6 * (double)num6);
			float num8 = num2 / num7;
			float num9 = num5 * num8;
			float num10 = num6 * num8;
			if (npc.position.X < x + (double)num9)
			{
				npc.velocity.X += num1;
				if (npc.velocity.X < 0.0 && num9 > 0.0)
					npc.velocity.X *= 0.5f;
			}
			else if (npc.position.X > x + (double)num9)
			{
				npc.velocity.X -= num1;
				if (npc.velocity.X > 0.0 && num9 < 0.0)
					npc.velocity.X *= 0.5f;
			}
			if (npc.position.Y < y + (double)num10)
			{
				npc.velocity.Y += num1;
				if (npc.velocity.Y < 0.0 && num10 > 0.0)
					npc.velocity.Y *= 0.5f;
			}
			else if (npc.position.Y > y + (double)num10)
			{
				npc.velocity.Y -= num1;
				if (npc.velocity.Y > 0.0 && num10 < 0.0)
					npc.velocity.Y *= 0.5f;
			}
			Lighting.AddLight(npc.Center, Color.White.ToVector3());
			// Limit velocity
			npc.velocity.X = MathHelper.Clamp(npc.velocity.X, -8.0f, 8.0f);
			npc.velocity.Y = MathHelper.Clamp(npc.velocity.Y, -8.0f, 8.0f);
		}

		private void ControlRotation()
		{
			npc.rotation = npc.AngleTo(npc.target != -1 ? Main.player[npc.target].Center : Motherboard.Center);
		}	
	}
}