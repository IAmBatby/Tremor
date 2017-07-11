using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	public class Avenger : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Avenger");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 1750;
			npc.damage = 165;
			npc.defense = 80;
			npc.knockBackResist = 0.0f;
			npc.width = 80;
			npc.height = 80;
			animationType = 82;
			npc.aiStyle = 97;
			aiType = 420;
			npc.npcSlots = 0.4f;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit4;
			npc.noGravity = true;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = Item.buyPrice(0, 0, 4, 15);
			banner = npc.type;
			bannerItem = mod.ItemType("AvengerBanner");
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = npc.lifeMax * 1;
			npc.damage = npc.damage * 1;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life > 0)
			{
				int num85 = Dust.NewDust(npc.position, npc.width, npc.height, 71, 0f, 0f, 200, default(Color), 1f);
				Main.dust[num85].velocity *= 1.5f;
			}
			else
			{
				for (int num86 = 0; num86 < 50; num86++)
				{
					int num87 = Dust.NewDust(npc.position, npc.width, npc.height, 71, hitDirection, 0f, 200, default(Color), 1f);
					Main.dust[num87].velocity *= 1.5f;
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AvengerGore1"), 1f);
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AvengerGore1"), 1f);
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AvengerGore2"), 1f);
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AvengerGore2"), 1f);
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AvengerGore3"), 1f);
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AvengerGore4"), 1f);
				}
			}
		}

		public override void NPCLoot()
		{
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + npc.width / 2) / 16;
				int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
				int halfLength = npc.width / 2 / 16 + 1;
				if (Main.rand.Next(3) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CarbonSteel"), Main.rand.Next(1, 3));
				}
				if (Main.rand.Next(5) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GoldenClaw"), Main.rand.Next(1, 5));
				}
				if (Main.rand.Next(10) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AngryShard"), Main.rand.Next(1, 2));
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = Main.tile[x, y].type;
			return (Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo)) && NPC.downedMoonlord && Main.hardMode && !Main.dayTime && y < Main.worldSurface ? 0.03f : 0f;
		}
	}
}