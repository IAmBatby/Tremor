using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Tremor.Ice.Items;

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
			npc.lifeMax = Main.hardMode ? 300 : 30;
			npc.damage = Main.hardMode ? 65 : 25;
			//Main.npcFrameCount[npc.type] = 4;
			npc.defense = 0;
			npc.knockBackResist = 0.3f;
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
			npc.lifeMax = npc.lifeMax * 1;
			npc.damage = npc.damage * 1;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int[] TileArray2 = { mod.TileType("IceOre"), mod.TileType("IceBlock"), mod.TileType("VeryVeryIce"), mod.TileType("DungeonBlock") };
			return TileArray2.Contains(Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY].type)
				&& !NPC.AnyNPCs(NPCID.LunarTowerVortex)
			    && !NPC.AnyNPCs(NPCID.LunarTowerStardust)
			    && !NPC.AnyNPCs(NPCID.LunarTowerNebula)
			    && !NPC.AnyNPCs(NPCID.LunarTowerSolar) 
				? 15f : 0f;
		}

		public override void AI()
		{
			if (npc.localAI[0] == 0f)
			{
				int damage = Main.hardMode ? 40 : 15;

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
					arm.length = ColdtrapChain.minLength;
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

			// 20% chance to drop a few ice blocks
			if (Main.rand.NextBool(5))
			{
				this.NewItem(mod.ItemType<IceBlockB>(), 2 + Main.rand.Next(4) + (Main.hardMode ? 1 : 0));
			}
			// 10% chance to drop a few ice ores
			if (Main.rand.NextBool(10))
			{
				this.NewItem(mod.ItemType<Icicle>(), 2 + Main.rand.Next(3) + (Main.hardMode ? 1 : 0));
			}

			// Explode into a few glaciers
			int num = 2 + Main.rand.Next(2);
			for (int i = 0; i < num; i++)
			{
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType<Glacier>());
			}
		}

		public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
		{
			if (Main.hardMode || Main.expertMode)
			{
				target.AddBuff(BuffID.Frostburn, Main.rand.Next(1, 3) * 60);
			}
		}
	}
}