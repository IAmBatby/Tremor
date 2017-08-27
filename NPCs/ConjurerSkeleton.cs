using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.ZombieEvent.Items;

namespace Tremor.NPCs
{
	public class ConjurerSkeleton : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Conjurer Skeleton");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.width = 40;
			npc.height = 40;
			npc.damage = 16;
			npc.defense = 16;
			npc.lifeMax = 270;
			npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = Item.buyPrice(0, 1, 5, 7);
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 8;
			aiType = 29;
			animationType = 29;
			banner = npc.type;
			bannerItem = mod.ItemType("ConjurerSkeletonBanner");
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(6) == 0)
				npc.SpawnItem(ItemID.MagicHat);
			if (Main.rand.Next(20) == 0)
				npc.SpawnItem(mod.ItemType<TornPapyrus>());
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UndeadGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UndeadGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UndeadWarrior2Gore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UndeadGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UndeadGore2"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NoZoneAllowWater(spawnInfo) && NPC.downedBoss3 && spawnInfo.spawnTileY > Main.rockLayer ? 0.02f : 0f;
	}
}
