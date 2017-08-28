using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class Shroot : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shroot");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 275;
			npc.damage = 28;
			npc.defense = 34;
			npc.knockBackResist = 0.3f;
			npc.width = 130;
			npc.height = 140;
			animationType = 141;
			npc.aiStyle = 1;
			npc.npcSlots = 1f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath17;
			npc.scale = 0.7f;
			npc.value = Item.buyPrice(0, 0, 1, 24);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("ShrootBanner");
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool(2))
				this.NewItem(mod.ItemType<Gloomstone>(), Main.rand.Next(6, 16));
			if (Main.rand.NextBool(2))
				this.NewItem(mod.ItemType<RockHorn>(), Main.rand.Next(1, 3));
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 60; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ShnootGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ShnootGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ShnootGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ShnootGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ShnootGore2"), 1f);
			}
			else
			{
				for (int k = 0; k < damage / npc.lifeMax * 50; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 5, hitDirection, -1f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 5, hitDirection, -1f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 5, hitDirection, -1f, 0, default(Color), 0.7f);
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.spawnTileY > Main.rockLayer ? 0.003f : 0f;
	}
}