using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;
using Tremor.Items.Invar;
using Tremor.ZombieEvent.Items;

namespace Tremor.NPCs
{
	public class UndeadWarrior1 : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Savage Undead Warrior");
			Main.npcFrameCount[npc.type] = 15;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = Main.hardMode ? 75 : 60;
			npc.damage = Main.hardMode ? 12 : 24;
			npc.defense = 5;
			npc.knockBackResist = 0.4f;
			npc.width = 36;
			npc.height = 44;
			animationType = 21;
			npc.aiStyle = 3;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = Item.buyPrice(0, 0, 4, 7);
			banner = npc.type;
			bannerItem = mod.ItemType("UndeadWarriorBanner");
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax += 10 + 10 * numPlayers;
			npc.damage += 2 * numPlayers;
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool(15))
				this.NewItem(mod.ItemType<OldInvarPlate>());
			if (Main.rand.NextBool(30))
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
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UndeadWarrior1Gore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UndeadWarrior1Gore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UndeadGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UndeadGore2"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> (Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo)) && !Main.dayTime && spawnInfo.spawnTileY < Main.worldSurface ? 0.05f : 0f;
	}
}