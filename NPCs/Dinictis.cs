using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class Dinictis : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dinichthys");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 800;
			npc.damage = 95;
			npc.defense = 20;
			npc.knockBackResist = 0.3f;
			npc.width = 34;
			npc.height = 48;
			animationType = 65;
			npc.aiStyle = 16;
			npc.npcSlots = 1f;
			npc.HitSound = SoundID.NPCHit31;
			npc.noGravity = true;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = Item.buyPrice(0, 0, 7, 9);
			banner = npc.type;
			bannerItem = mod.ItemType("DinictisBanner");
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = npc.lifeMax * 1;
			npc.damage = npc.damage * 1;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DinictisGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DinictisGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DinictisGore3"), 1f);
			}
		}

		public override void NPCLoot()
		{
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + npc.width / 2) / 16;
				int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
				int halfLength = npc.width / 2 / 16 + 1;
				if (Main.rand.Next(35) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Sharking"));
				};
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = Main.tile[x, y].type;
			return (Tremor.NormalSpawn(spawnInfo) && (tile == 53 || tile == 112 || tile == 116 || tile == 234) && Tremor.NoZoneAllowWater(spawnInfo) && spawnInfo.water) && Main.hardMode && y < Main.rockLayer && (x < 250 || x > Main.maxTilesX - 250) && !spawnInfo.playerSafe ? 0.01f : 0f;
		}
	}
}