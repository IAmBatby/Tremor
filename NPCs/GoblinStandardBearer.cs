using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	public class GoblinStandardBearer : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Goblin Standard Bearer");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 75;
			npc.damage = 34;
			npc.defense = 14;
			npc.knockBackResist = 0.1f;
			npc.width = 34;
			npc.height = 70;
			npc.aiStyle = 3;
			aiType = 77;
			npc.npcSlots = 3f;
			npc.noGravity = true;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = Item.buyPrice(0, 0, 0, 0);
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

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return (NPC.AnyNPCs(26) || NPC.AnyNPCs(27) || NPC.AnyNPCs(28) || NPC.AnyNPCs(29)) && NPC.downedBoss3 && y < Main.worldSurface ? 0.3f : 0f;
		}

		public override void NPCLoot()
		{
			NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("GoblinStandardBearer_Balloon"));
		}

	}
}