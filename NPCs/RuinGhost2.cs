using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	public class RuinGhost2 : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ruin Ghost");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.width = 24;
			npc.height = 46;
			npc.damage = 6;
			npc.defense = 10;
			npc.npcSlots = 1;
			npc.lifeMax = 105;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = 100;
			npc.knockBackResist = 0.3f;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.aiStyle = 22;
			aiType = NPCID.Wraith;
			animationType = NPCID.Wraith;
			npc.stepSpeed = .5f;
			npc.lavaImmune = true;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int[] TileArray2 = { mod.TileType("RuinAltar"), mod.TileType("RuinChest"), 120 };
			return TileArray2.Contains(Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY].type) && TremorWorld.downedBoss[TremorWorld.Boss.TikiTotem] ? 45f : 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, 13);
				Gore.NewGore(npc.position, npc.velocity, 12);
				Gore.NewGore(npc.position, npc.velocity, 11);
			}
		}
		public override void AI()
		{
			if (Main.rand.Next(700) == 0)
			{
				Main.PlaySound(29, (int)npc.position.X, (int)npc.position.Y, Main.rand.Next(81, 84));
			}
		}
		public override void NPCLoot()
		{
			if (Main.rand.Next(6) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, 12, 12, mod.ItemType("RuinKey"), 1);
			if (Main.rand.Next(6) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, 12, 12, mod.ItemType("RustyLantern"), 1);
		}
	}
}