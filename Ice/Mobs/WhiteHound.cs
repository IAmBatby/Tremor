using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
			npc.lifeMax = 150;
			npc.damage = 76;
			npc.defense = 35;
			npc.knockBackResist = 0.3f;
			npc.width = 62;
			npc.height = 32;
			animationType = 329;
			npc.aiStyle = 26;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit6;
			npc.DeathSound = SoundID.NPCDeath5;
			npc.value = Item.buyPrice(0, 0, 5, 3);
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

		public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
		{
			target.AddBuff(44, 60);
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int[] TileArray2 = { mod.TileType("IceOre"), mod.TileType("IceBlock"), mod.TileType("VeryVeryIce"), mod.TileType("DungeonBlock") };
			return TileArray2.Contains(Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY].type) && Main.hardMode && !NPC.AnyNPCs(422) && !NPC.AnyNPCs(493) && !NPC.AnyNPCs(507) && !NPC.AnyNPCs(517) ? 15f : 0f;
		}

	}
}