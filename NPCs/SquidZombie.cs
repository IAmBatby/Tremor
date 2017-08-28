using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class SquidZombie : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Squid Zombie");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 125;
			npc.damage = 25;
			npc.defense = 6;
			npc.knockBackResist = 0.6f;
			npc.width = 34;
			npc.height = 60;
			animationType = 3;
			npc.aiStyle = 3;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = Item.buyPrice(0, 0, 4, 0);
			banner = npc.type;
			bannerItem = mod.ItemType("SquidZombieBanner");
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(24) == 0)
				this.NewItem(mod.ItemType<SquidHat>());
			if (Main.rand.Next(3) == 0)
				this.NewItem(mod.ItemType<UntreatedFlesh>());
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZombieGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZombieGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SquidGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZombieGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZombieGore2"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && Main.tileSand[spawnInfo.spawnTileType] && Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.water && spawnInfo.spawnTileY < Main.rockLayer && (spawnInfo.spawnTileX < 250 || spawnInfo.spawnTileX > Main.maxTilesX - 250) && !spawnInfo.playerSafe ? 0.01f : 0f;
	}
}