using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class GiantCrab : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Giant Crab");
			Main.npcFrameCount[npc.type] = 8;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 300;
			npc.damage = 70;
			npc.defense = 25;
			npc.knockBackResist = 0.3f;
			npc.width = 35;
			npc.height = 28;
			animationType = 67;
			npc.aiStyle = 26;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = Item.buyPrice(0, 0, 9, 0);
			banner = npc.type;
			bannerItem = mod.ItemType("GiantCrabBanner");
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CrabGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CrabGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CrabGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CrabGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CrabGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CrabGore3"), 1f);
			}
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(25) == 0)
				npc.NewItem(mod.ItemType<CrabClaw>());
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && (spawnInfo.spawnTileType == 53 || spawnInfo.spawnTileType == 112 || spawnInfo.spawnTileType == 116 || spawnInfo.spawnTileType == 234) && spawnInfo.water && spawnInfo.spawnTileY < Main.rockLayer && (spawnInfo.spawnTileX < 250 || spawnInfo.spawnTileX > Main.maxTilesX - 250) && !spawnInfo.playerSafe && Main.hardMode ? 0.01f : 0f;
	}
}