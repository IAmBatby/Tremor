using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.ZombieEvent.Items;

namespace Tremor.NPCs
{
	public class BoneArcher : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bone Archer");
			Main.npcFrameCount[npc.type] = 21;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 200;
			npc.damage = 36;
			npc.defense = 13;
			npc.knockBackResist = 0.3f;
			npc.width = 36;
			npc.height = 44;
			npc.npcSlots = 0.2f;
			npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.aiStyle = 3;
			aiType = 111;
			animationType = 111;
			npc.value = Item.buyPrice(0, 0, 6, 9);
			banner = npc.type;
			bannerItem = mod.ItemType("BoneArcherBanner");
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(45) == 0)
				npc.NewItem(ItemID.Hook);
			if (Main.rand.NextBool())
				npc.NewItem(ItemID.WoodenArrow, Main.rand.Next(1, 3));
			if (Main.rand.NextBool(2))
				npc.NewItem(ItemID.FlamingArrow, Main.rand.Next(1, 3));
			if (Main.rand.Next(20) == 0)
				npc.NewItem((short)mod.ItemType<TornPapyrus>());
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UndeadGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UndeadGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BoneArcherGore"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UndeadGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UndeadGore2"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return Helper.NoZoneAllowWater(spawnInfo) && NPC.downedBoss3 && spawnInfo.spawnTileY > Main.rockLayer ? 0.02f : 0f;
		}
	}
}