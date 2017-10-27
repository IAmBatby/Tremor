using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace Tremor.NPCs
{
	public class GoblinStandardBearer_Balloon : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Goblin Standard Bearer");
			Main.npcFrameCount[npc.type] = 3;
		}

		const int maxXMoveSpeed = 4;

		public override void SetDefaults()
		{
			npc.lifeMax = 100;
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

		public override void AI()
		{
			npc.TargetClosest(true);

			if (npc.direction == -1 && npc.velocity.X > -maxXMoveSpeed)
			{
				npc.velocity.X = npc.velocity.X - 0.1f;
				if (npc.velocity.X > 2f)
					npc.velocity.X = npc.velocity.X - 0.1f;
				else if (npc.velocity.X > 0f)
					npc.velocity.X = npc.velocity.X + 0.05f;

				if (npc.velocity.X < -maxXMoveSpeed)
					npc.velocity.X = -maxXMoveSpeed;
			}
			else if(npc.direction == 1 && npc.velocity.X < maxXMoveSpeed)
			{
				npc.velocity.X = npc.velocity.X + 0.1f;
				if (npc.velocity.X < -2f)
					npc.velocity.X = npc.velocity.X + 0.1f;

				else if(npc.velocity.X < 0f)
					npc.velocity.X = npc.velocity.X - 0.05f;

				if (npc.velocity.X > maxXMoveSpeed)
					npc.velocity.X = maxXMoveSpeed;
			}

			if (npc.directionY == -1 && npc.velocity.Y > -1.5)
			{
				npc.velocity.Y = npc.velocity.Y - 0.05f;

				if (npc.velocity.Y < -1.5)
					npc.velocity.Y = -1.5f;
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

		public override void NPCLoot()
		{
			if (Main.invasionType == InvasionID.GoblinArmy)
			{
				Main.invasionSize -= 1;
				if (Main.invasionSize < 0)
					Main.invasionSize = 0;
				if (Main.netMode != 1)
					Main.ReportInvasionProgress(Main.invasionSizeStart - Main.invasionSize, Main.invasionSizeStart, InvasionID.GoblinArmy + 3, 0);
				if (Main.netMode == 2)
					NetMessage.SendData(78, -1, -1, null, Main.invasionProgress, Main.invasionProgressMax, Main.invasionProgressIcon, 0f, 0, 0, 0);
			}

			if (Main.rand.NextBool(2))
				npc.NewItem(ItemID.SpikyBall, Main.rand.Next(1, 16));
			if (Main.rand.Next(200) == 0)
				npc.NewItem(ItemID.Harpoon);
		}
	}
}