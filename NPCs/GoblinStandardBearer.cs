using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

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
			npc.lifeMax = 175;
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

		public override void AI()
		{
			npc.TargetClosest(true);

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
			if (npc.directionY == -1 && npc.velocity.Y > -1.5)
			{
				npc.velocity.Y = npc.velocity.Y - 0.05f;

				if (npc.velocity.Y < -1.5)
				{
					npc.velocity.Y = -1.5f;
				}
			}
			else
			{
				if (npc.directionY == 1 && npc.velocity.Y < 1.5)
				{
					npc.velocity.Y = npc.velocity.Y + 0.05f;
					if (npc.velocity.Y > 1.5)
					{
						npc.velocity.Y = 1.5f;
					}
				}
			}
		}
		
		public override void FindFrame(int frameHeight)
		{
			if ((npc.frameCounter += Math.Abs(npc.velocity.X)) >= 20)
			{
				npc.frame.Y = (npc.frame.Y + frameHeight) % (Main.npcFrameCount[npc.type] * frameHeight);
				npc.frameCounter = 0;
			}

			npc.spriteDirection = npc.direction;
		}

		public override bool CheckDead()
		{
			npc.SetDefaults(mod.NPCType<GoblinStandardBearer_Balloon>());
			return false;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Main.invasionType == InvasionID.GoblinArmy && NPC.downedBoss3 && spawnInfo.spawnTileY < Main.worldSurface ? 0.3f : 0f;
	}
}