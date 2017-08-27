using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class Atis : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Atis");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 140;
			npc.damage = 15;
			npc.defense = 10;
			npc.knockBackResist = 0.6f;
			npc.width = 34;
			npc.height = 48;
			animationType = 82;
			npc.aiStyle = 22;
			npc.npcSlots = 0.4f;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit31;
			npc.noGravity = true;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = Item.buyPrice(0, 0, 4, 15);
			banner = npc.type;
			bannerItem = mod.ItemType("AtisBanner");
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AtisGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AtisGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AtisGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AtisGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AtisGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AtisGore2"), 1f);
			}
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(25) == 0)
				npc.SpawnItem((short)mod.ItemType<HeartofAtis>());
			if (Main.rand.Next(25) == 0)
				npc.SpawnItem((short)mod.ItemType<BoneMask>());
			//if (Main.hardMode && Main.rand.Next(2) == 0)
			//	npc.SpawnItem((short)mod.ItemType("RawMeat"));
			if (Main.rand.NextBool())
				npc.SpawnItem((short)mod.ItemType<AtisBlood>(), Main.rand.Next(1, 2));
			if (Main.rand.Next(30) == 0)
				npc.SpawnItem((short)ItemID.ChainKnife);
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.spawnTileY > Main.rockLayer ? 0.01f : 0f;
		}
	}
}