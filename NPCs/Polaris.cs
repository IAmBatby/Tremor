using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class Polaris : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Polaris");
			Main.npcFrameCount[npc.type] = 10;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 125;
			npc.damage = 20;
			npc.defense = 12;
			npc.knockBackResist = 0.4f;
			npc.width = 56;
			npc.height = 48;
			aiType = 429;
			animationType = 429;
			npc.aiStyle = 3;
			npc.npcSlots = 0.2f;
			npc.HitSound = SoundID.NPCHit37;
			npc.DeathSound = SoundID.NPCDeath57;
			npc.value = Item.buyPrice(0, 0, 6, 9);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("PolarisBanner");
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(20) == 0)
				this.NewItem(mod.ItemType<FrostFreshness>());
			if (Main.rand.NextBool(2))
				this.NewItem(mod.ItemType<FrostCore>());
			if (NPC.downedMoonlord && Main.rand.Next(5) == 0)
				this.NewItem(mod.ItemType<IceSoul>());
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 1f);
					Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.8f);
				}

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PolarisGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PolarisGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PolarisGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PolarisGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PolarisGore3"), 1f);

				Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 1f);
				Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 2f);
				Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 1f);

			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NoZoneAllowWater(spawnInfo) && Main.cloudAlpha > 0f && spawnInfo.spawnTileY < Main.worldSurface && spawnInfo.player.ZoneSnow ? 0.03f : 0f;
	}
}