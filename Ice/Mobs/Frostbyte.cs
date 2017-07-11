using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Ice.Mobs
{
	public class Frostbyte : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frostbyte");
			Main.npcFrameCount[npc.type] = 3;
		}


		public override void SetDefaults()
		{
			npc.lifeMax = 50;
			npc.damage = 13;
			npc.defense = 12;
			npc.knockBackResist = 0.6f;
			npc.width = 25;
			npc.height = 20;
			animationType = 3;
			npc.aiStyle = -1;
			npc.npcSlots = 1f;
			npc.value = Item.buyPrice(0, 0, 10, 5);
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 1);
			npc.damage = (int)(npc.damage * 1);
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int[] TileArray2 = { mod.TileType("IceOre"), mod.TileType("IceBlock"), mod.TileType("VeryVeryIce"), mod.TileType("DungeonBlock") };
			return TileArray2.Contains(Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY].type) && !NPC.AnyNPCs(422) && !NPC.AnyNPCs(493) && !NPC.AnyNPCs(507) && !NPC.AnyNPCs(517) ? 15f : 0f;
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(28) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, 12, 12, mod.ItemType("FrostbyteEye"), 1);
		}

		public override void AI()
		{
			int tileX = (int)(npc.Bottom.Y / 16f), tileY = (int)(npc.Bottom.Y / 16f);
			int height = (int)Math.Min(10, tileX);
			float velX = MathHelper.Lerp(5f, 3f, (float)height / 10f), velY = MathHelper.Lerp(-3f, -6f, (float)height / 10f);
			npc.aiStyle = 1;
			if (npc.target >= 0 && npc.target <= 255 && Main.player[npc.target].Bottom.Y < npc.Center.Y && npc.collideX && npc.velocity.Y != 0)
			{
				npc.netUpdate = true;
				if (Main.netMode != 2)
				{
					for (int m = 0; m < 2; m++)
					{
						float xPos = npc.velocity.X > 0 ? npc.Right.X : npc.Left.X;
						int dustID = Dust.NewDust(new Vector2(xPos, npc.Center.Y), 1, 1, 80, xPos < npc.Center.X ? -4f : 4f, (float)Math.Abs(npc.velocity.Y) * 0.2f, 100, Color.White, 1.5f);
						Main.dust[dustID].noGravity = true;
					}
				}
				npc.direction *= -1;
				npc.velocity.Y = -5f; npc.velocity.X = 5f * npc.direction;
			}
			else
			if (npc.velocity.Y == 0) npc.TargetClosest(true);
			if (npc.velocity.Y == 0 && npc.ai[0] < -20) npc.ai[0] = -20;
			if (npc.velocity.X != 0) npc.spriteDirection = npc.velocity.X > 0 ? 1 : -1;
		}

		public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
		{
			target.AddBuff(44, 60);
		}
	}
}