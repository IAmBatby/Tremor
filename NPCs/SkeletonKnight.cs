using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.ZombieEvent.Items;

namespace Tremor.NPCs
{
	public class SkeletonKnight : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Skeleton Knight");
			Main.npcFrameCount[npc.type] = 7;
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
			npc.value = Item.buyPrice(0, 0, 5, 7);
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 3;
			aiType = 434;
			animationType = 434;
			banner = npc.type;
			bannerItem = mod.ItemType("SkeletonKnightBanner");
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool(3))
				this.NewItem(ItemID.Cobweb, Main.rand.Next(3, 6));
			if (Main.rand.NextBool(3))
				this.NewItem(ItemID.Bone, Main.rand.Next(1, 3));

			if (Main.rand.Next(20) == 0)
				this.NewItem(mod.ItemType<TornPapyrus>());
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SkelKnightGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SkelKnightGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SkelKnightGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SkelKnightGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SkelKnightGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SkelKnightGore4"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NoZoneAllowWater(spawnInfo) && NPC.downedBoss3 && spawnInfo.spawnTileY > Main.rockLayer ? 0.02f : 0f;
	}
}
