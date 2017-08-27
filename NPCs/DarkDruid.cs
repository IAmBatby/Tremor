using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class DarkDruid : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Druid");
			Main.npcFrameCount[npc.type] = 15;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 300;
			npc.damage = 25;
			npc.defense = 2;
			npc.knockBackResist = 0.3f;
			npc.width = 36;
			npc.height = 44;
			animationType = 21;
			npc.aiStyle = 3;
			npc.npcSlots = 1f;
			npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = Item.buyPrice(0, 0, 6, 50);
			banner = npc.type;
			bannerItem = mod.ItemType("DarkDruidBanner");
		}

		public override void AI()
		{
			if (Main.netMode != 1 && Main.rand.Next(160) == 0)
				NPC.NewNPC((int)npc.position.X - 50, (int)npc.position.Y, mod.NPCType("DarkDruidMinion"));

			if (Main.rand.Next(1000) == 0)
				Main.PlaySound(105, (int)npc.position.X, (int)npc.position.Y, 1);
			if (Main.rand.Next(1000) == 0)
				Main.PlaySound(91, (int)npc.position.X, (int)npc.position.Y, 1);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UndeadGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UndeadGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DarkDruidGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DarkDruidGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UndeadGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UndeadGore2"), 1f);
			}
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(20) == 0)
				npc.SpawnItem(mod.ItemType<DarkDruidMask>());
			if (Main.rand.Next(8) == 0)
				npc.SpawnItem(ItemID.Ruby);
			if (Main.rand.Next(8) == 0)
				npc.SpawnItem(ItemID.Topaz);
			if (Main.rand.Next(8) == 0)
				npc.SpawnItem(ItemID.Diamond);
			if (Main.rand.NextBool())
				npc.SpawnItem(mod.ItemType<TearsofDeath>(), Main.rand.Next(1, 5));
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> (Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo)) && Main.bloodMoon && spawnInfo.spawnTileY < Main.worldSurface ? 0.004f : 0f;
	}
}