using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class Zootaloo : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zootaloo");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 120;
			npc.damage = 22;
			npc.defense = 8;
			npc.knockBackResist = 0.2f;
			npc.width = 34;
			npc.height = 48;
			animationType = 48;
			npc.aiStyle = 14;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit35;
			npc.noGravity = true;
			npc.DeathSound = SoundID.NPCDeath57;
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("ZootalooBanner");
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool(3))
				this.NewItem(mod.ItemType<LightBulb>(), Main.rand.Next(1, 3));
			if (Main.rand.NextBool(2))
				this.NewItem(mod.ItemType<Gloomstone>(), Main.rand.Next(5, 13));
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 44, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZootalooGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZootalooGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZootalooGore2"), 1f);
			}
			else
			{
				for (int k = 0; k < damage / npc.lifeMax * 50; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 44, hitDirection, -1f, 0, default(Color), 0.7f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo) && !Main.dayTime && spawnInfo.spawnTileY < Main.worldSurface ? 0.01f : 0f;
	}
}