using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class Coretaur : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Coretaur");
			Main.npcFrameCount[npc.type] = 14;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 1500;
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
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("CoretaurBanner");
		}

		public override void AI()
		{
			if (Main.rand.Next(4) == 0)
				Main.dust[Dust.NewDust(npc.position, npc.width, npc.height, 6, 0f, 0f, 200, npc.color)].velocity *= 0.3f;
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool())
				npc.SpawnItem(mod.ItemType<MinotaurHorn>());
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CoretaurGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CoretaurGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CoretaurGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CoretaurGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CoretaurGore3"), 1f);
				for (int k = 0; k < 20; k++)
				{
					for (int i = 0; i < 3; ++i)
					{
						Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
						Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.6f);
					}
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NoZoneAllowWater(spawnInfo) && NPC.downedBoss3 && spawnInfo.spawnTileY > Main.maxTilesY - 200 ? 0.005f : 0f;
	}
}