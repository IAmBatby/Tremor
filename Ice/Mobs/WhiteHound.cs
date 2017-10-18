using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Tremor.Ice.Items;

namespace Tremor.Ice.Mobs
{
	public class WhiteHound : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("White Hound");
			Main.npcFrameCount[npc.type] = 10;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 200;
			npc.damage = 45;
			npc.defense = 10;
			npc.knockBackResist = 0.1f;
			npc.width = 62;
			npc.height = 32;
			animationType = 329;
			npc.aiStyle = 26;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit6;
			npc.DeathSound = SoundID.NPCDeath5;
			npc.value = Item.buyPrice(silver: 5, copper: 3);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WhiteHoundGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WhiteHoundGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WhiteHoundGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WhiteHoundGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WhiteHoundGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WhiteHoundGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WhiteHoundGore3"), 1f);
			}
		}

		public override void NPCLoot()
		{
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
				&& Main.hardMode
				&& !NPC.AnyNPCs(NPCID.LunarTowerVortex)
			    && !NPC.AnyNPCs(NPCID.LunarTowerStardust)
			    && !NPC.AnyNPCs(NPCID.LunarTowerNebula)
			    && !NPC.AnyNPCs(NPCID.LunarTowerSolar) 
				? 15f : 0f;
		}

	}
}