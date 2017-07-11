using Microsoft.Xna.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Ice.Mobs
{
	public class Dot : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Coldtrap");
		}


		public override void SetDefaults()
		{
			npc.lifeMax = 20;
			npc.damage = 0;
			//Main.npcFrameCount[npc.type] = 4;
			npc.defense = 0;
			npc.knockBackResist = 0f;
			npc.width = 78;
			npc.height = 54;
			//animationType = 3;
			npc.aiStyle = 0;
			npc.npcSlots = 1f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
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

		public override void AI()
		{
			if (npc.localAI[0] == 0f)
			{
				int damage = 15;

				for (int k = 1; k < 5; k++)
				{
					int proj = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 0f, mod.ProjectileType("ColdtrapChain"), damage, 0, Main.myPlayer);

					if (proj == 100)
					{
						npc.active = false;
						return;
					}
					ColdtrapChain arm = Main.projectile[proj].modProjectile as ColdtrapChain;
					arm.arm = npc.whoAmI;
					arm.width = 16f;
					arm.length = Ice.Mobs.ColdtrapChain.minLength;
					arm.minAngle = (k - 0.05f) * (float)Math.PI / 3f;
					arm.maxAngle = (k + 0.25f) * (float)Math.PI / 3f;
					Main.projectile[proj].rotation = (arm.minAngle + arm.maxAngle) / 3f;
					Main.projectile[proj].netUpdate = true;
				}
				npc.localAI[0] = 1f;
			}
			base.AI();
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(25) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, 12, 12, mod.ItemType("IceKey"), 1);
		}

		public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
		{
			target.AddBuff(44, 60);
		}
	}
}