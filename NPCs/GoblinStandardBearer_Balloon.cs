using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	public class GoblinStandardBearer_Balloon : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Goblin Standard Bearer");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 50;
			npc.damage = 34;
			npc.defense = 14;
			npc.knockBackResist = 0.1f;
			npc.width = 34;
			npc.height = 70;
			npc.aiStyle = 3;
			aiType = 77;
			npc.npcSlots = 3f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = Item.buyPrice(0, 0, 1, 64);
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 1);
			npc.damage = (int)(npc.damage * 1);
		}

		public override void AI()
		{
			PlayAnimation();
			if (Main.player[npc.target].position.X > npc.position.X)
				npc.spriteDirection = 1;
			else
				npc.spriteDirection = -1;

			if (npc.direction == -1 && npc.velocity.X > -2f)
			{
				npc.velocity.X = npc.velocity.X - 0.1f;
				if (npc.velocity.X > 2f)
				{
					npc.velocity.X = npc.velocity.X - 0.1f;
				}
				else
				{
					if (npc.velocity.X > 0f)
					{
						npc.velocity.X = npc.velocity.X + 0.05f;
					}
				}
				if (npc.velocity.X < -2f)
				{
					npc.velocity.X = -2f;
				}
			}
			else
			{
				if (npc.direction == 1 && npc.velocity.X < 2f)
				{
					npc.velocity.X = npc.velocity.X + 0.1f;
					if (npc.velocity.X < -2f)
					{
						npc.velocity.X = npc.velocity.X + 0.1f;
					}
					else
					{
						if (npc.velocity.X < 0f)
						{
							npc.velocity.X = npc.velocity.X - 0.05f;
						}
					}
					if (npc.velocity.X > 2f)
					{
						npc.velocity.X = 2f;
					}
				}
			}
			if (npc.directionY == -1 && (double)npc.velocity.Y > -1.5)
			{
				npc.velocity.Y = npc.velocity.Y - 0.05f;

				if ((double)npc.velocity.Y < -1.5)
				{
					npc.velocity.Y = -1.5f;
				}
			}
			else
			{
				if (npc.directionY == 1 && (double)npc.velocity.Y < 1.5)
				{
					npc.velocity.Y = npc.velocity.Y + 0.05f;
					if ((double)npc.velocity.Y > 1.5)
					{
						npc.velocity.Y = 1.5f;
					}
				}
			}
		}

		int Frame = 0;
		int TimeToAnimation = 6;
		public void PlayAnimation()
		{
			if (--TimeToAnimation <= 0)
			{
				if (++Frame > 3)
					Frame = 1;
				TimeToAnimation = 6;
				npc.frame = GetFrame(Frame);
			}
		}

		Rectangle GetFrame(int Num)
		{
			return new Rectangle(0, npc.frame.Height * (Num - 1), npc.frame.Width, npc.frame.Height);
		}

		public override void NPCLoot()
		{
			if (Main.invasionType == Terraria.ID.InvasionID.GoblinArmy)
			{
				Main.invasionProgress++;
			}
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
				int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
				int halfLength = npc.width / 2 / 16 + 1;

				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 161, Main.rand.Next(1, 15));
				}

				if (Main.rand.Next(200) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 160);
				}
			}
		}
	}
}