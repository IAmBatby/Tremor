using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;
using Tremor.ZombieEvent.Items;

namespace Tremor.NPCs
{
	public class UndeadWarrior4 : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Undead Warrior");
			Main.npcFrameCount[npc.type] = 15;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 80;
			npc.damage = 16;
			npc.defense = 4;
			npc.knockBackResist = 0.3f;
			npc.width = 36;
			npc.height = 44;
			animationType = 21;
			npc.aiStyle = 3;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = Item.buyPrice(0, 0, 3, 7);
			banner = npc.type;
			bannerItem = mod.ItemType("UndeadWarriorBanner");
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(5) == 0)
				this.NewItem(mod.ItemType<MeltedInvarSword>());
			if (Main.rand.Next(5) == 0)
				this.NewItem(mod.ItemType<BrokenInvarShield>());
			if (Main.rand.Next(5) == 0)
				this.NewItem(mod.ItemType<OldInvarPlate>());
			if (Main.rand.Next(30) == 0)
				this.NewItem(mod.ItemType<TornPapyrus>());
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UndeadGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UndeadGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UndeadWarrior4Gore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UndeadWarrior4Gore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UndeadGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UndeadGore2"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo) && !Main.dayTime && spawnInfo.spawnTileY < Main.worldSurface ? 0.1f : 0f;
	}
}