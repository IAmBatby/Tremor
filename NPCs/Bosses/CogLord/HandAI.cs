using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs.Bosses.CogLord
{
	public abstract class HandAI : ModNPC
	{
		protected enum HandAIState : byte
		{
			None,
			PostHAttack,
			PreVAttack,
			VAttack,
			PostVAttack,
			PreHAttack,
			HAttack
		}

		protected CogLord.CogLordAIState BossAIState => (CogLord.CogLordAIState)((int)Boss.ai[0] & 15);
		protected NPC Boss => Main.npc[(int)npc.ai[1]];
		protected int HandDirection => (int)npc.ai[0];

		protected HandAIState CurrentState
		{
			get { return (HandAIState)npc.ai[2]; }
			set { npc.ai[2] = (byte)value; }
		}

		public override void AI()
		{
			npc.spriteDirection = -HandDirection;

			if (CurrentState == HandAIState.None)
			{
				CurrentState = HandAIState.PostHAttack;
				MakeArms();
			}

			if (!Boss.active || Boss.type != mod.NPCType<CogLord>())
			{
				CurrentState += 10;
				if ((byte)CurrentState > 50 || Main.netMode != NetmodeID.Server)
				{
					npc.life = -1;
					npc.HitEffect(0, 10.0);
					npc.active = false;
				}
			}

			if (CurrentState == HandAIState.PostHAttack || CurrentState == HandAIState.PostVAttack)
			{
				if (BossAIState == CogLord.CogLordAIState.Leaving && npc.timeLeft > 10)
				{
					npc.timeLeft = 10;
				}
				if (BossAIState != CogLord.CogLordAIState.Idle)
				{
					if (npc.position.Y > Boss.position.Y - 100f)
					{
						if (npc.velocity.Y > 0f)
							npc.velocity.Y = npc.velocity.Y * 0.96f;
						npc.velocity.Y = npc.velocity.Y - 0.07f;
						if (npc.velocity.Y > 6f)
							npc.velocity.Y = 6f;
					}
					else if (npc.position.Y < Boss.position.Y - 100f)
					{
						if (npc.velocity.Y < 0f)
							npc.velocity.Y = npc.velocity.Y * 0.96f;
						npc.velocity.Y = npc.velocity.Y + 0.07f;
						if (npc.velocity.Y < -6f)
							npc.velocity.Y = -6f;
					}
					if (npc.Center.X > Boss.Center.X - 120f * HandDirection)
					{
						if (npc.velocity.X > 0f)
							npc.velocity.X = npc.velocity.X * 0.96f;
						npc.velocity.X = npc.velocity.X - 0.1f;
						if (npc.velocity.X > 8f)
							npc.velocity.X = 8f;
					}
					if (npc.Center.X < Boss.Center.X - 120f * HandDirection)
					{
						if (npc.velocity.X < 0f)
							npc.velocity.X = npc.velocity.X * 0.96f;
						npc.velocity.X = npc.velocity.X + 0.1f;
						if (npc.velocity.X < -8f)
							npc.velocity.X = -8f;
					}
				}
				else
				{
					npc.ai[3] += 1f;
					if (Main.expertMode)
					{
						npc.ai[3] += 0.5f;
					}
					if (npc.ai[3] >= 300f)
					{
						CurrentState = CurrentState == HandAIState.PostHAttack ? HandAIState.PreVAttack : HandAIState.PreHAttack;
						npc.ai[3] = 0f;
						npc.netUpdate = true;
					}
					if (Main.expertMode)
					{
						if (npc.position.Y > Boss.position.Y + 230f)
						{
							if (npc.velocity.Y > 0f)
								npc.velocity.Y = npc.velocity.Y * 0.96f;
							npc.velocity.Y = npc.velocity.Y - 0.04f;
							if (npc.velocity.Y > 3f)
								npc.velocity.Y = 3f;
						}
						else if (npc.position.Y < Boss.position.Y + 230f)
						{
							if (npc.velocity.Y < 0f)
								npc.velocity.Y = npc.velocity.Y * 0.96f;
							npc.velocity.Y = npc.velocity.Y + 0.04f;
							if (npc.velocity.Y < -3f)
								npc.velocity.Y = -3f;
						}
						if (npc.Center.X > Boss.Center.X - 200f * HandDirection)
						{
							if (npc.velocity.X > 0f)
								npc.velocity.X = npc.velocity.X * 0.96f;
							npc.velocity.X = npc.velocity.X - 0.07f;
							if (npc.velocity.X > 8f)
								npc.velocity.X = 8f;
						}
						if (npc.Center.X < Boss.Center.X - 200f * HandDirection)
						{
							if (npc.velocity.X < 0f)
								npc.velocity.X = npc.velocity.X * 0.96f;
							npc.velocity.X = npc.velocity.X + 0.07f;
							if (npc.velocity.X < -8f)
								npc.velocity.X = -8f;
						}
					}
					if (npc.position.Y > Boss.position.Y + 230f)
					{
						if (npc.velocity.Y > 0f)
							npc.velocity.Y = npc.velocity.Y * 0.96f;
						npc.velocity.Y = npc.velocity.Y - 0.04f;
						if (npc.velocity.Y > 3f)
							npc.velocity.Y = 3f;
					}
					else if (npc.position.Y < Boss.position.Y + 230f)
					{
						if (npc.velocity.Y < 0f)
							npc.velocity.Y = npc.velocity.Y * 0.96f;
						npc.velocity.Y = npc.velocity.Y + 0.04f;
						if (npc.velocity.Y < -3f)
							npc.velocity.Y = -3f;
					}
					if (npc.Center.X > Boss.Center.X - 200f * HandDirection)
					{
						if (npc.velocity.X > 0f)
							npc.velocity.X = npc.velocity.X * 0.96f;
						npc.velocity.X = npc.velocity.X - 0.07f;
						if (npc.velocity.X > 8f)
							npc.velocity.X = 8f;
					}
					if (npc.Center.X < Boss.Center.X - 200f * HandDirection)
					{
						if (npc.velocity.X < 0f)
							npc.velocity.X = npc.velocity.X * 0.96f;
						npc.velocity.X = npc.velocity.X + 0.07f;
						if (npc.velocity.X < -8f)
							npc.velocity.X = -8f;
					}
				}

				Vector2 direction = Boss.Center + new Vector2(-200 * HandDirection, 230) - npc.Center;
				npc.rotation = direction.ToRotation() + 1.57f;
				return;
			}
			if (CurrentState == HandAIState.PreVAttack)
			{
				Vector2 direction = Boss.Center + new Vector2(-200 * HandDirection, 230) - npc.Center;
				npc.rotation = direction.ToRotation() + 1.57f;

				npc.velocity.X *= 0.95f;
				npc.velocity.Y -= 0.1f;
				if (Main.expertMode)
				{
					npc.velocity.Y -= 0.06f;
					if (npc.velocity.Y < -13f)
						npc.velocity.Y = -13f;
				}
				else if (npc.velocity.Y < -8f)
					npc.velocity.Y = -8f;
				if (npc.position.Y < Boss.position.Y - 200f)
				{
					npc.TargetClosest(true);
					CurrentState = HandAIState.VAttack;
					direction = Main.player[npc.target].Center - npc.Center;
					float distance = direction.Length();
					float speedMult = Main.expertMode ? 21f : 18f;
					npc.velocity = direction * (speedMult / distance);
					npc.netUpdate = true;
					return;
				}
			}
			else if (CurrentState == HandAIState.VAttack)
			{
				if (npc.position.Y > Main.player[npc.target].position.Y || npc.velocity.Y < 0f)
				{
					CurrentState = HandAIState.PostVAttack;
					return;
				}
			}
			else if (CurrentState == HandAIState.PreHAttack)
			{
				Vector2 direction = Boss.Center + new Vector2(-200 * HandDirection, 230) - npc.Center;
				npc.rotation = direction.ToRotation() + 1.57f;
				npc.velocity.Y *= 0.95f;
				npc.velocity.X += 0.1f * -HandDirection;
				if (Main.expertMode)
				{
					npc.velocity.X = npc.velocity.X + 0.07f * -npc.ai[0];
					if (npc.velocity.X < -12f)
						npc.velocity.X = -12f;
					else if (npc.velocity.X > 12f)
						npc.velocity.X = 12f;
				}
				else if (npc.velocity.X < -8f)
					npc.velocity.X = -8f;
				else if (npc.velocity.X > 8f)
					npc.velocity.X = 8f;
				if (npc.Center.X < Boss.Center.X - 500f || npc.Center.X > Boss.Center.X + 500f)
				{
					npc.TargetClosest(true);
					CurrentState = HandAIState.HAttack;
					direction = Main.player[npc.target].Center - npc.Center;
					float distance = direction.Length();
					float speedMult = Main.expertMode ? 22f : 17f;
					npc.velocity = direction * (speedMult / distance);
					npc.netUpdate = true;
					return;
				}
			}
			else if (CurrentState == HandAIState.HAttack && (npc.velocity.X > 0f && npc.Center.X > Main.player[npc.target].Center.X || npc.velocity.X < 0f && npc.Center.X < Main.player[npc.target].Center.X))
			{
				CurrentState = HandAIState.PostHAttack;
				return;
			}
		}

		private void MakeArms()
		{
			if (Main.netMode == NetmodeID.MultiplayerClient)
				return;

			int arm = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("CogLordArm"), 0, 9999, 1, 1, npc.ai[1]);
			int arm2 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("CogLordArmSecond"), 0, npc.whoAmI, 0, 1, arm);
			Main.npc[arm].ai[0] = arm2;
		}
	}
}
