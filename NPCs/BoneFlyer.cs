using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace Tremor.NPCs
{
	public class BoneFlyer : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flying Bones");
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 140;
			npc.damage = 26;
			npc.defense = 9;
			npc.knockBackResist = 0.3f;
			npc.width = 82;
			npc.height = 56;
			animationType = 62;
			npc.aiStyle = 14;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = Item.buyPrice(0, 0, 7, 0);
			banner = npc.type;
			bannerItem = mod.ItemType("BoneFlyerBanner");
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool())
				npc.NewItem(ItemID.Bone, Main.rand.Next(1, 3));
			if (Main.rand.NextBool(6))
				npc.NewItem(ItemID.HealingPotion, Main.rand.Next(1, 3));
			if (Main.rand.NextBool(6))
				npc.NewItem(ItemID.ManaPotion, Main.rand.Next(1, 3));
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FlyerGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FlyerGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FlyerGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FlyerGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FlyerGore3"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return (Helper.NoZoneAllowWater(spawnInfo)) && spawnInfo.player.ZoneDungeon && spawnInfo.spawnTileY > Main.rockLayer ? 0.01f : 0f;
		}
	}
}