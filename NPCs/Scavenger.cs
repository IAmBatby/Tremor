using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class Scavenger : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scavenger");
			Main.npcFrameCount[npc.type] = 10;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 1000;
			npc.damage = 20;
			if (NPC.downedBoss2)
			{
				npc.lifeMax = 1500;
				npc.damage = 25;
			}
			if (NPC.downedBoss3)
			{
				npc.lifeMax = 2000;
				npc.damage = 30;
			}
			if (Main.hardMode)
			{
				npc.lifeMax = 5000;
				npc.damage = 70;
			}
			if (NPC.downedMechBossAny)
			{
				npc.lifeMax = 10000;
				npc.damage = 80;
			}
			if (NPC.downedPlantBoss)
			{
				npc.lifeMax = 12000;
				npc.damage = 100;
			}
			if (NPC.downedGolemBoss)
			{
				npc.lifeMax = 15000;
				npc.damage = 150;
			}
			npc.defense = 4;
			npc.knockBackResist = 0.3f;
			npc.width = 18;
			npc.height = 90;
			animationType = 351;
			npc.aiStyle = 3;
			aiType = 77;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = Item.buyPrice(0, 0, 8, 0);
			banner = npc.type;
			bannerItem = mod.ItemType("ScavengerBanner");
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ScavengerGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ScavengerGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ScavengerGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ScavengerGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ScavengerGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ScavengerGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ScavengerGore4"), 1f);
			}
		}

		public override void NPCLoot()
		{
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
				int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
				int halfLength = npc.width / 2 / 16 + 1;
				if (!Main.hardMode)
				{
					if (Main.rand.Next(2) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 29, Main.rand.Next(1, 2));
					};
					if (Main.rand.Next(1) == 0)
					{
						if (!WorldGen.crimson)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 57, Main.rand.Next(10, 25));
						}
						if (WorldGen.crimson)
						{
							Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1257, Main.rand.Next(10, 25));
						}
					};
					if (Main.rand.Next(1) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 188, Main.rand.Next(2, 10));
					};
					if (Main.rand.Next(1) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 189, Main.rand.Next(2, 10));
					};
					if (Main.rand.Next(1) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 178, Main.rand.Next(5, 15));
					};
					if (Main.rand.Next(1) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 182, Main.rand.Next(5, 15));
					};
					if (Main.rand.Next(5) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Opal"), Main.rand.Next(1, 3));
					};
					if (Main.rand.Next(1) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 227, Main.rand.Next(2, 10));
					};
					if (Main.rand.Next(1) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 175, Main.rand.Next(2, 10));
					};
					if (Main.rand.Next(1) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3532, Main.rand.Next(1, 2));
					};
				}
				if (Main.hardMode)
				{
					if (Main.rand.Next(5) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2161, Main.rand.Next(1, 2));
					};
					if (Main.rand.Next(3) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2351, Main.rand.Next(1, 6));
					};
					if (Main.rand.Next(10) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 723);
					};
					if (Main.rand.Next(50) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 855);
					};
					if (Main.rand.Next(3) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 499, Main.rand.Next(1, 6));
					};
					if (Main.rand.Next(3) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 500, Main.rand.Next(1, 6));
					};
					if (Main.rand.Next(15) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1242);
					};
					if (Main.rand.Next(3) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1291, Main.rand.Next(1, 3));
					};
					if (Main.rand.Next(50) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1321);
					};
					if (Main.rand.Next(100) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1326);
					};
					if (Main.rand.Next(25) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1324);
					};
					if (Main.rand.Next(80) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3368);
					};
					if (Main.rand.Next(80) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3260);
					};
					if (Main.rand.Next(80) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3262);
					};
					if (Main.rand.Next(80) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3212);
					};
					if (Main.rand.Next(80) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3099);
					};
					if (Main.rand.Next(80) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3095);
					};
					if (Main.rand.Next(80) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3096);
					};
					if (Main.rand.Next(80) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3091);
					};
					if (Main.rand.Next(80) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 3092);
					};
					if (Main.rand.Next(8) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2674, Main.rand.Next(1, 6));
					};
					if (Main.rand.Next(15) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2675, Main.rand.Next(1, 10));
					};
					if (Main.rand.Next(50) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2676, Main.rand.Next(1, 15));
					};
					if (Main.rand.Next(60) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2336);
					};
					if (Main.rand.Next(50) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2335);
					};
					if (Main.rand.Next(30) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2334);
					};
					if (Main.rand.Next(15) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 422, Main.rand.Next(1, 10));
					};
					if (Main.rand.Next(15) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 423, Main.rand.Next(1, 10));
					};
					if (Main.rand.Next(45) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 497);
					};
					if (Main.rand.Next(3) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 502, Main.rand.Next(1, 10));
					};
					if (Main.rand.Next(3) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 501, Main.rand.Next(1, 15));
					};
					if (Main.rand.Next(26) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 507);
					};
					if (Main.rand.Next(26) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 508);
					};
					if (Main.rand.Next(62) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 527);
					};
					if (Main.rand.Next(62) == 0)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 528);
					};
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return (Tremor.NormalSpawn(spawnInfo) && Tremor.NoZoneAllowWater(spawnInfo)) && !Main.dayTime && y < Main.worldSurface ? 0.0001f : 0f;
		}
	}
}