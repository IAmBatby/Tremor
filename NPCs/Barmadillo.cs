using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class Barmadillo : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Barmadillo");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 12500;
			npc.damage = 120;
			npc.defense = 100;
			npc.knockBackResist = 0.3f;
			npc.width = 100;
			npc.height = 100;
			npc.aiStyle = 2;
			aiType = 180;
			animationType = 48;
			npc.aiStyle = 2;
			npc.npcSlots = 0.5f;
			npc.noTileCollide = true;
			npc.buffImmune[20] = true;
			npc.buffImmune[24] = true;
			npc.buffImmune[39] = true;
			npc.buffImmune[31] = false;
			npc.HitSound = SoundID.NPCHit1;
			npc.noGravity = true;
			npc.DeathSound = SoundID.NPCDeath57;
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("BarmadilloBanner");
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 44, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BarmadilloGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BarmadilloGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BarmadilloGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BarmadilloGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BarmadilloGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BarmadilloGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BarmadilloGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BarmadilloGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BarmadilloGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BarmadilloGore4"), 1f);
			}
			else
			{
				for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 44, hitDirection, -1f, 0, default(Color), 0.7f);
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
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Blasticyde"), Main.rand.Next(1, 3));
				}
				if (Main.rand.NextBool())
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LapisLazuli"), Main.rand.Next(2, 4));
				}
			}
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = npc.lifeMax * 1;
			npc.damage = npc.damage * 1;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = Main.tile[x, y].type;
			return Main.hardMode && TremorWorld.Boss.Trinity.Downed() && !spawnInfo.player.ZoneDungeon && y > Main.rockLayer ? 0.002f : 0f;
		}
	}
}