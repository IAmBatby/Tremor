using Microsoft.Xna.Framework;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
			npc.lifeMax = 50;
			npc.damage = 10;
			npc.defense = 8;
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
			npc.lifeMax = (int)(npc.lifeMax * 1);
			npc.damage = (int)(npc.damage * 1);
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(30) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, 12, 12, mod.ItemType("Frostex"), 1);
		}

		public override void AI()
		{
			Dust.NewDust(npc.position, npc.width, npc.height, 80, 0, -1f, 0, default(Color), 0.7f);
		}

		public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
		{
			target.AddBuff(44, 60);
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int[] TileArray2 = { mod.TileType("IceOre"), mod.TileType("IceBlock"), mod.TileType("VeryVeryIce"), mod.TileType("DungeonBlock") };
			return TileArray2.Contains(Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY].type) && !NPC.AnyNPCs(422) && !NPC.AnyNPCs(493) && !NPC.AnyNPCs(507) && !NPC.AnyNPCs(517) ? 15f : 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GlacierGore"), 1f);
			}
		}
	}
}