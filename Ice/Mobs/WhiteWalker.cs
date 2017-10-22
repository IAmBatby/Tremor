using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Tremor.Ice.Items;

namespace Tremor.Ice.Mobs
{
	public class WhiteWalker : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("White Walker");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = Main.hardMode ? 300 : 30;
			npc.damage = Main.hardMode ? 55 : 12;
			npc.defense = Main.hardMode ? 13 : 2;
			npc.knockBackResist = 0.3f;
			npc.width = 56;
			npc.height = 48;
			animationType = 3;
			npc.aiStyle = 3;
			npc.npcSlots = 1f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = Item.buyPrice(silver: 15, copper: 5);
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax += 10 * numPlayers;
			npc.damage += 3 * numPlayers;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int[] TileArray2 = { mod.TileType("IceOre"), mod.TileType("IceBlock"), mod.TileType("VeryVeryIce"), mod.TileType("DungeonBlock") };
			return TileArray2.Contains(Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY].type) 
				&& !NPC.AnyNPCs(NPCID.LunarTowerVortex) 
				&& !NPC.AnyNPCs(NPCID.LunarTowerStardust) 
				&& !NPC.AnyNPCs(NPCID.LunarTowerNebula) 
				&& !NPC.AnyNPCs(NPCID.LunarTowerSolar) 
				&& !Main.dayTime
				? 15f : 0f;
		}
		public override void AI()
		{
			npc.spriteDirection = npc.direction;
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(25) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, 12, 12, mod.ItemType("IceCross"), 1);

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

		public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
		{
			if (Main.hardMode || Main.expertMode)
			{
				target.AddBuff(BuffID.Frostburn, Main.rand.Next(1, 3) * 60);
			}
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WhiteWalkerGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WhiteWalkerGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WhiteWalkerGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WhiteWalkerGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WhiteWalkerGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WhiteWalkerGore3"), 1f);
			}
		}
	}
}