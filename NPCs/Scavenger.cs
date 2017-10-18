using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Tremor.Items;

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
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("ScavengerBanner");
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
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
			if (!Main.hardMode)
			{
				if (Main.rand.NextBool(2))
					this.NewItem(29, Main.rand.Next(1, 3));

				if (Main.rand.NextBool())
				{						
					if (WorldGen.crimson)
						this.NewItem(1257, Main.rand.Next(10, 26));
						else
							this.NewItem(57, Main.rand.Next(10, 26));
				}

				if (Main.rand.NextBool())
					this.NewItem(188, Main.rand.Next(2, 11));
				if (Main.rand.NextBool())
					this.NewItem(189, Main.rand.Next(2, 11));
				if (Main.rand.NextBool())
					this.NewItem(178, Main.rand.Next(5, 16));
				if (Main.rand.NextBool())
					this.NewItem(182, Main.rand.Next(5, 16));
				if (Main.rand.NextBool(5))
					this.NewItem(mod.ItemType<Opal>(), Main.rand.Next(1, 3));
				if (Main.rand.NextBool())
					this.NewItem(227, Main.rand.Next(2, 11));
				if (Main.rand.NextBool())
					this.NewItem(175, Main.rand.Next(2, 11));
				if (Main.rand.NextBool())
					this.NewItem(3532, Main.rand.Next(1, 3));
			}
			else
			{
				if (Main.rand.NextBool(5))
					this.NewItem(2161, Main.rand.Next(1, 3));
				if (Main.rand.NextBool(3))
					this.NewItem(2351, Main.rand.Next(1, 6));
				if (Main.rand.Next(10) == 0)
					this.NewItem(723);
				if (Main.rand.Next(50) == 0)
					this.NewItem(855);
				if (Main.rand.NextBool(3))
					this.NewItem(499, Main.rand.Next(1, 6));
				if (Main.rand.NextBool(3))
					this.NewItem(500, Main.rand.Next(1, 6));
				if (Main.rand.Next(15) == 0)
					this.NewItem(1242);
				if (Main.rand.NextBool(3))
					this.NewItem(1291, Main.rand.Next(1, 3));
				if (Main.rand.Next(50) == 0)
					this.NewItem(1321);
				if (Main.rand.Next(100) == 0)
					this.NewItem(1326);
				if (Main.rand.Next(25) == 0)
					this.NewItem(1324);
				if (Main.rand.Next(80) == 0)
					this.NewItem(3368);
				if (Main.rand.Next(80) == 0)
					this.NewItem(3260);
				if (Main.rand.Next(80) == 0)
					this.NewItem(3262);
				if (Main.rand.Next(80) == 0)
					this.NewItem(3212);
				if (Main.rand.Next(80) == 0)
					this.NewItem(3099);
				if (Main.rand.Next(80) == 0)
					this.NewItem(3095);
				if (Main.rand.Next(80) == 0)
					this.NewItem(3096);
				if (Main.rand.Next(80) == 0)
					this.NewItem(3091);
				if (Main.rand.Next(80) == 0)
					this.NewItem(3092);
				if (Main.rand.NextBool(8))
					this.NewItem(2674, Main.rand.Next(1, 6));
				if (Main.rand.Next(15) == 0)
					this.NewItem(2675, Main.rand.Next(1, 10));
				if (Main.rand.Next(50) == 0)
					this.NewItem(2676, Main.rand.Next(1, 15));
				if (Main.rand.Next(60) == 0)
					this.NewItem(2336);
				if (Main.rand.Next(50) == 0)
					this.NewItem(2335);
				if (Main.rand.Next(30) == 0)
					this.NewItem(2334);
				if (Main.rand.Next(15) == 0)
					this.NewItem(422, Main.rand.Next(1, 10));
				if (Main.rand.Next(15) == 0)
					this.NewItem(423, Main.rand.Next(1, 10));
				if (Main.rand.Next(45) == 0)
					this.NewItem(497);
				if (Main.rand.NextBool(3))
					this.NewItem(502, Main.rand.Next(1, 10));
				if (Main.rand.NextBool(3))
					this.NewItem(501, Main.rand.Next(1, 15));
				if (Main.rand.Next(26) == 0)
					this.NewItem(507);
				if (Main.rand.Next(26) == 0)
					this.NewItem(508);
				if (Main.rand.Next(62) == 0)
					this.NewItem(527);
				if (Main.rand.Next(62) == 0)
					this.NewItem(528);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo) && !Main.dayTime && spawnInfo.spawnTileY < Main.worldSurface ? 0.0001f : 0f;
	}
}