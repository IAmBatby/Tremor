using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace Tremor.NPCs
{
	public class CrimsonBicholmere : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crimson Bicholmere");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 325;
			npc.damage = 28;
			npc.defense = 11;
			npc.knockBackResist = 0.3f;
			npc.width = 62;
			npc.height = 46;
			animationType = 244;
			npc.aiStyle = 1;
			npc.npcSlots = 0.6f;
			npc.HitSound = SoundID.NPCHit47;
			npc.DeathSound = SoundID.NPCDeath23;
			npc.value = Item.buyPrice(0, 0, 5, 25);
			banner = npc.type;
			bannerItem = mod.ItemType<Items.CrimsonBiholmerBanner>();
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CrimsonBicholmereGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CrimsonBicholmereGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CrimsonBicholmereGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CrimsonBicholmereGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CrimsonBicholmereGore3"), 1f);
			}
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool())
				npc.NewItem(ItemID.Vertebrae);
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.player.ZoneCrimson && spawnInfo.spawnTileY > Main.rockLayer ? 0.01f : 0f;
	}
}