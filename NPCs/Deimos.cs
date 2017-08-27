using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{

	public class Deimos : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Deimos");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 10000;
			npc.damage = 180;
			npc.defense = 100;
			npc.knockBackResist = 0.0f;
			npc.width = 145;
			npc.height = 145;
			animationType = 82;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.aiStyle = 22;
			aiType = 226;
			npc.npcSlots = 5f;
			npc.HitSound = SoundID.NPCHit54;
			npc.DeathSound = SoundID.NPCDeath52;
			npc.value = Item.buyPrice(0, 10, 15, 12);
			banner = npc.type;
			bannerItem = mod.ItemType("DeimosBanner");
		}

		public override void AI()
		{
			if (Main.rand.Next(6) == 0)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, 27, 0f, 0f, 200, npc.color);
				Dust.NewDust(npc.position, npc.width, npc.height, 70, 0f, 0f, 200, npc.color);
			}
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool())
				npc.SpawnItem(mod.ItemType<EyeofOblivion>());
			if (Main.rand.NextBool())
				npc.SpawnItem(mod.ItemType<CarbonSteel>(), Main.rand.Next(2, 15));
			if (Main.rand.NextBool())
				npc.SpawnItem(mod.ItemType<ToothofAbraxas>(), Main.rand.Next(2, 16));
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 60; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 27, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 70, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 27, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
				}
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 27, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);

				Dust.NewDust(npc.position, npc.width, npc.height, 27, 2.5f * hitDirection, -2.5f, 0, default(Color), 3.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 70, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 27, 2.5f * hitDirection, -2.5f, 0, default(Color), 3.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DeimosGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DeimosGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DeimosGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DeimosGore3"), 1f);
			}
			else
			{
				for (int k = 0; k < damage / npc.lifeMax * 50; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 27, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = Main.tile[x, y].type;
			return (Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo)) && NPC.downedMoonlord && Main.hardMode && !Main.dayTime && y < Main.worldSurface ? 0.05f : 0f;
		}
	}
}