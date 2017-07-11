using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class TheGirl : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Girl");
			Main.npcFrameCount[npc.type] = 9;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 3000;
			npc.damage = 175;
			npc.defense = 48;
			npc.knockBackResist = 0.3f;
			npc.width = 34;
			npc.height = 54;
			animationType = 529;
			npc.aiStyle = 3;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit1;
			aiType = 529;
			npc.DeathSound = SoundID.NPCDeath52;
			npc.value = Item.buyPrice(0, 3, 1, 0);
			banner = npc.type;
			bannerItem = mod.ItemType("TheGirlBanner");
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
				for (int k = 0; k < 60; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 54, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 54, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 54, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 54, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
			}
		}

		public override void NPCLoot()
		{
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
				int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
				int halfLength = npc.width / 2 / 16 + 1;
				if (Main.rand.Next(5) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrokenHeroArmorplate"));
				}
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return (Tremor.NormalSpawn(spawnInfo) && (tile == 53 || tile == 112 || tile == 116 || tile == 234) && spawnInfo.water) && y < Main.rockLayer && (x < 250 || x > Main.maxTilesX - 250) && !spawnInfo.playerSafe && NPC.downedMoonlord && Main.eclipse ? 0.01f : 0f;
		}
	}
}