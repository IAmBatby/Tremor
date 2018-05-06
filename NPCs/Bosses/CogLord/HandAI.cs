using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

		Vector2 MoveExtendDist => new Vector2(-120f * HandDirection, -100f);
		Vector2 IdleExtendDist => new Vector2(-200f * HandDirection, 230f);
		Vector2 ArmAttachOffset => new Vector2(-60f * HandDirection, 50);
		float maxExtendDistY = 100;
		float maxExtendDistX = 300;

		protected virtual bool CanMeleeAttack => true;
		protected virtual float ArmDrawOffset => 84f;

		protected HandAIState CurrentState
		{
			get { return (HandAIState)npc.ai[2]; }
			set { npc.ai[2] = (byte)value; }
		}

		public override void AI()
		{
			float deaccMult = 0.96f;
			float accMult = 2f;
			
			if (CurrentState == HandAIState.None)
			{
				CurrentState = HandAIState.PostHAttack;
			}

			if (!Boss.active || Boss.type != mod.NPCType<CogLord>())
			{
				CurrentState += 10;
				if ((byte)CurrentState > 50 || Main.netMode != NetmodeID.Server)
				{
					npc.life = -1;
					npc.HitEffect();
					npc.active = false;
				}
			}

			if (CurrentState == HandAIState.PostHAttack || CurrentState == HandAIState.PostVAttack)
			{
				if (BossAIState == CogLord.CogLordAIState.Leaving && npc.timeLeft > 10)
				{
					npc.timeLeft = 10;
				}

				bool idleSpeed = BossAIState == CogLord.CogLordAIState.Idle;
				float accelY = idleSpeed ? 0.04f : 0.07f;
				float accelX = idleSpeed ? 0.07f : 0.1f;
				float maxSpeedY = idleSpeed ? 3f : 6f;
				float maxSpeedX = 8f;
				Vector2 extendDist = idleSpeed ? IdleExtendDist : MoveExtendDist;

				if (idleSpeed & CanMeleeAttack)
				{
					npc.localAI[0] += 1f;
					if (Main.expertMode)
					{
						npc.localAI[0] += 0.5f;
					}
					if (npc.localAI[0] >= 300f)
					{
						CurrentState = CurrentState == HandAIState.PostHAttack ? HandAIState.PreVAttack : HandAIState.PreHAttack;
						npc.localAI[0] = 0f;
						npc.netUpdate = true;
					}
				}

				for (int i = 0; i < (idleSpeed && Main.expertMode ? 2 : 1); i++)
				{
					if (npc.position.Y > Boss.position.Y + extendDist.Y)
					{
						if (npc.velocity.Y > 0f)
							npc.velocity.Y *= deaccMult;
						npc.velocity.Y -= accelY * accMult;
						if (npc.velocity.Y > maxSpeedY * accMult)
							npc.velocity.Y = maxSpeedY * accMult;
					}
					else if (npc.position.Y < Boss.position.Y + extendDist.Y)
					{
						if (npc.velocity.Y < 0f)
							npc.velocity.Y *= deaccMult;
						npc.velocity.Y += accelY * accMult;
						if (npc.velocity.Y < -maxSpeedY * accMult)
							npc.velocity.Y = -maxSpeedY * accMult;
					}
					if (npc.Center.X > Boss.Center.X + extendDist.X)
					{
						if (npc.velocity.X > 0f)
							npc.velocity.X *= deaccMult;
						npc.velocity.X -= accelX * accMult;
						if (npc.velocity.X > maxSpeedX * accMult)
							npc.velocity.X = maxSpeedX * accMult;
					}
					if (npc.Center.X < Boss.Center.X + extendDist.X)
					{
						if (npc.velocity.X < 0f)
							npc.velocity.X *= deaccMult;
						npc.velocity.X += accelX * accMult;
						if (npc.velocity.X < -maxSpeedX * accMult)
							npc.velocity.X = -maxSpeedX * accMult;
					}
				}

				Vector2 direction = new Vector2(Boss.Center.X, Boss.position.Y) + IdleExtendDist - npc.Center;
				npc.rotation = direction.ToRotation() + MathHelper.PiOver2;
				return;
			}
			if (CurrentState == HandAIState.PreVAttack)
			{
				Vector2 direction = new Vector2(Boss.Center.X, Boss.position.Y) + IdleExtendDist - npc.Center;
				npc.rotation = direction.ToRotation() + MathHelper.PiOver2;

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
				if (npc.position.Y < Boss.position.Y - maxExtendDistY)
				{
					npc.TargetClosest(true);
					CurrentState = HandAIState.VAttack;
					direction = Main.player[npc.target].Center - npc.Center;
					float distance = direction.Length();
					float speedMult = Main.expertMode ? 21f : 18f;
					npc.velocity = direction * (speedMult * accMult / distance);
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
				Vector2 direction = new Vector2(Boss.Center.X, Boss.position.Y) + IdleExtendDist - npc.Center;
				npc.rotation = direction.ToRotation() + MathHelper.PiOver2;

				npc.velocity.Y *= 0.95f;
				npc.velocity.X += 0.1f * -HandDirection;
				if (Main.expertMode)
				{
					npc.velocity.X += 0.07f * -HandDirection;
					if (npc.velocity.X < -12f)
						npc.velocity.X = -12f;
					else if (npc.velocity.X > 12f)
						npc.velocity.X = 12f;
				}
				else if (npc.velocity.X < -8f)
					npc.velocity.X = -8f;
				else if (npc.velocity.X > 8f)
					npc.velocity.X = 8f;
				if (npc.Center.X < Boss.Center.X - maxExtendDistX || npc.Center.X > Boss.Center.X + maxExtendDistX)
				{
					npc.TargetClosest(true);
					CurrentState = HandAIState.HAttack;
					direction = Main.player[npc.target].Center - npc.Center;
					float distance = direction.Length();
					float speedMult = Main.expertMode ? 22f : 17f;
					npc.velocity = direction * (speedMult * accMult / distance);
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

		public override void FindFrame(int frameHeight)
		{
			npc.spriteDirection = -HandDirection;
			if (++npc.frameCounter >= 12)
				npc.frameCounter = 0;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			Vector2 drawPosition = npc.Center;
			for (int i = 0; i < 2; i++)
			{
				Vector2 toBoss = Boss.Center + ArmAttachOffset - drawPosition;
				float posOffset = 60f;
				if (i == 0)
				{
					toBoss.X += -100f * HandDirection;
					toBoss.Y += 40f;
					posOffset = ArmDrawOffset;
				}
				float distance = toBoss.Length();
				distance = posOffset / distance;
				drawPosition += toBoss * distance;

				float rotation = toBoss.ToRotation();
				Texture2D texture = mod.GetTexture("NPCs/Bosses/CogLord/" + (i == 0 ? "CogLordArmSecond" : "CogLordArm"));
				Rectangle frame = texture.Frame(1, 2, 0, (int)(npc.frameCounter / 6));
				spriteBatch.Draw(texture, drawPosition - Main.screenPosition, frame, npc.dontTakeDamage ? Color.Yellow : Color.White, rotation, frame.Size() * 0.5f, 1f, SpriteEffects.None, 0f);
				if (i == 0)
					drawPosition += toBoss * distance * 0.6f;
			}
			return true;
		}
		
		public override bool PreNPCLoot() => false;
	}
}
