using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class UndeadMusketeer : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Undead Musketeer");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 220;
			npc.damage = 50;
			npc.defense = 16;
			npc.knockBackResist = 0.3f;
			npc.width = 34;
			npc.height = 46;
			animationType = 3;
			npc.aiStyle = 3;
			npc.npcSlots = 2f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = Item.buyPrice(0, 0, 1, 0);
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(22) == 0)
				this.NewItem(mod.ItemType<MusketeerHat>());
			if (Main.rand.Next(25) == 0)
				this.NewItem(mod.ItemType<FencingRapier>());
			// Blunderbuss does not exist in the Tremor namespace.
			//if (Main.rand.Next(28) == 0)
			//	this.NewItem(mod.ItemType<BlunderBuss>());
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZombieGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZombieGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZombieGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZombieGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZombieMusketeerGore"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo) && NPC.downedBoss2 && !Main.dayTime && spawnInfo.spawnTileY < Main.worldSurface ? 0.02f : 0f;
	}
}