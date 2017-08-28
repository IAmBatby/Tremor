using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class MeteoriteGolem : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meteorite Golem");
			Main.npcFrameCount[npc.type] = 20;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 300;
			npc.damage = 30;
			npc.defense = 12;
			npc.knockBackResist = 0.1f;
			npc.width = 40;
			npc.height = 40;
			animationType = 482;
			npc.aiStyle = 3;
			aiType = 482;
			npc.npcSlots = 0.8f;
			npc.HitSound = SoundID.NPCHit41;
			npc.buffImmune[20] = true;
			npc.buffImmune[24] = true;
			npc.buffImmune[39] = true;
			npc.buffImmune[31] = false;
			npc.DeathSound = SoundID.NPCDeath44;
			npc.value = Item.buyPrice(0, 0, 5, 0);
			banner = npc.type;
			bannerItem = mod.ItemType("MeteoriteGolemBanner");
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool())
				this.NewItem(ItemID.Meteorite, 3);
			if (Main.rand.NextBool(2))
				this.NewItem(mod.ItemType<FireFragment>(), 3);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MGGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MGGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MGGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MGGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MGGore2"), 1f);

				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.6f);
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.player.ZoneMeteor ? 0.005f : 0f;
	}
}