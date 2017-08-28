using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class Minotaur : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Minotaur");
			Main.npcFrameCount[npc.type] = 14;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 1000;
			npc.damage = 20;
			npc.defense = 14;
			npc.knockBackResist = 0f;
			npc.width = 48;
			npc.height = 40;
			npc.aiStyle = 87;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath42;
			npc.value = Item.buyPrice(0, 3, 0, 0);
			animationType = NPCID.BigMimicHallow;
			banner = npc.type;
			bannerItem = mod.ItemType("MinotaurBanner");
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool())
				this.NewItem(mod.ItemType<MinotaurHorn>());
			if (Main.rand.Next(6) == 0)
				this.NewItem(mod.ItemType<NecroShield>());
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MinotaurGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MinotaurGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MinotaurGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MinotaurGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MinotaurGore3"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.player.ZoneDungeon && spawnInfo.spawnTileY > Main.rockLayer ? 0.005f : 0f;
	}
}