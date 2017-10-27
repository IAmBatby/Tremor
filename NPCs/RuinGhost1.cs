using System.Linq;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class RuinGhost1 : ModNPC
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
			npc.damage = 4;
			npc.defense = 12;
			npc.npcSlots = 1;
			npc.lifeMax = 90;
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

		public override void NPCLoot()
		{
			if (Main.rand.Next(33) == 0)
				this.NewItem(mod.ItemType<RuinKey>());
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

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int[] TileArray2 = { mod.TileType("RuinAltar"), mod.TileType("RuinChest"), TileID.Mudstone };
			return TileArray2.Contains(Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY].type) && TremorWorld.Boss.TikiTotem.IsDowned() ? 45f : 0f;
		}
	}
}