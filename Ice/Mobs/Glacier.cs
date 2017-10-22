using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Tremor.Ice.Items;

namespace Tremor.Ice.Mobs
{

	public class Glacier : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glacier");
		}

		public override void SetDefaults()
		{
			npc.lifeMax = Main.hardMode ? 100 : 20;
			npc.damage = Main.hardMode ? 32 : 5;
			npc.defense = Main.hardMode ? 12 : 2;
			npc.knockBackResist = 0f;
			npc.width = 68;
			npc.height = 78;
			//animationType = 156;
			npc.aiStyle = 2;
			aiType = 180;
			npc.npcSlots = 15f;
			npc.noTileCollide = true;
			npc.noGravity = true;
			npc.HitSound = SoundID.NPCHit3;
			npc.noGravity = true;
			npc.DeathSound = SoundID.NPCDeath5;
			npc.value = Item.buyPrice(0, 0, 1, 0);
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax += 10 * numPlayers;
			npc.damage += 2 * numPlayers;
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(30) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, 12, 12, mod.ItemType("Frostex"), 1);

			// 10% chance to drop a few ice blocks
			if (Main.rand.NextBool(10))
			{
				this.NewItem(mod.ItemType<IceBlockB>(), 1 + Main.rand.Next(3) + (Main.hardMode ? 1 : 0));
			}
			// 5% chance to drop a few ice ores
			if (Main.rand.NextBool(20))
			{
				this.NewItem(mod.ItemType<Icicle>(), 1 + Main.rand.Next(2) + (Main.hardMode ? 1 : 0));
			}
		}

		public override void AI()
		{
			Dust.NewDust(npc.position, npc.width, npc.height, 80, 0, -1f, 0, default(Color), 0.7f);
		}

		public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
		{
			if (Main.hardMode || Main.expertMode)
			{
				target.AddBuff(BuffID.Frostburn, Main.rand.Next(1, 3) * 60);
			}
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

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GlacierGore"), 1f);
			}
		}
	}
}