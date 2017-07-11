using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	public class GoplitArcher : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hoplite Archer");
			Main.npcFrameCount[npc.type] = 20;
		}

		public override void SetDefaults()
		{
			npc.width = 24;
			npc.height = 44;
			npc.damage = 26;
			npc.defense = 20;
			npc.lifeMax = 95;
			npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = Item.buyPrice(0, 0, 3, 7);
			npc.knockBackResist = 0.2f;
			npc.aiStyle = 3;
			aiType = 111;
			animationType = 110;
			npc.buffImmune[20] = true;
			npc.buffImmune[31] = false;
			npc.buffImmune[24] = true;
			banner = npc.type;
			bannerItem = mod.ItemType("GoplitArcherBanner");
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 1);
			npc.damage = (int)(npc.damage * 1);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 31, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GoplitAGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GoplitAGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GoplitAGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GoplitAGore3"), 1f);
			}
		}

		public override void NPCLoot()
		{
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
				int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
				int halfLength = npc.width / 2 / 16 + 1;
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StoneofLife"));
				};
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			Tile tile = Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY];
			return (Tremor.NoZoneAllowWater(spawnInfo)) && (tile.type == 367) && y > Main.rockLayer ? 0.01f : 0f;
		}

	}
}
