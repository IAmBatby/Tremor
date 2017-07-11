using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class Gelateen : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gelateen");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 500;
			npc.damage = 20;
			npc.defense = 24;
			npc.knockBackResist = 0.6f;
			npc.width = 90;
			npc.height = 62;
			animationType = 141;
			npc.aiStyle = 1;
			npc.npcSlots = 1f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = Item.buyPrice(0, 0, 12, 24);
			banner = npc.type;
			bannerItem = mod.ItemType("GelateenBanner");
		}


		public override void NPCLoot()
		{
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + npc.width / 2) / 16;
				int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
				int halfLength = npc.width / 2 / 16 + 1;
				if (Main.rand.Next(1) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BounceTome"));
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
			return (Tremor.NoZoneAllowWater(spawnInfo)) && y > Main.rockLayer ? 0.001f : 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 4, 2.5f * hitDirection, -2.5f, 0, Color.Green, 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 4, 2.5f * hitDirection, -2.5f, 0, Color.Green, 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GelateenGore1"), 1f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GelateenGore2"), 1f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GelateenGore3"), 1f);
				Dust.NewDust(npc.position, npc.width, npc.height, 4, 2.5f * hitDirection, -2.5f, 0, Color.Green, 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 4, 2.5f * hitDirection, -2.5f, 0, Color.Green, 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 4, 2.5f * hitDirection, -2.5f, 0, Color.Green, 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 1, 2.5f * hitDirection, -2.5f, 0, Color.Green, 0.7f);
			}
		}
	}
}