using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class HeavyZombie : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heavy Zombie");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 300;
			npc.damage = 80;
			npc.defense = 30;
			npc.knockBackResist = 0.03f;
			npc.width = 34;
			npc.height = 40;
			animationType = 3;
			npc.aiStyle = 3;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = Item.buyPrice(0, 0, 11, 0);
			banner = npc.type;
			bannerItem = mod.ItemType("HeavyZombieBanner");
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool(3))
				npc.NewItem(mod.ItemType<UntreatedFlesh>());
			if (Main.rand.NextBool(4))
				npc.NewItem(ItemID.SilverBar, Main.rand.Next(2, 4));
			if (Main.rand.NextBool(4))
				npc.NewItem(ItemID.IronBar, Main.rand.Next(2, 4));
			if (Main.rand.NextBool(4))
				npc.NewItem(ItemID.LeadBar, Main.rand.Next(2, 4));
			if (Main.rand.NextBool(4))
				npc.NewItem(ItemID.TungstenBar, Main.rand.Next(2, 4));
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HeavyGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HeavyGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HeavyGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HeavyGore3"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> (Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo)) && Main.hardMode && !Main.dayTime && spawnInfo.spawnTileY < Main.worldSurface ? 0.03f : 0f;
	}
}