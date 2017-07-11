using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class TwilightBat : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Twilight Bat");
			Main.npcFrameCount[npc.type] = 4;
		}


		public override void SetDefaults()
		{
			npc.lifeMax = 1200;
			npc.damage = 110;
			npc.defense = 20;
			npc.knockBackResist = 0.3f;
			npc.width = 56;
			npc.height = 48;
			animationType = 93;
			npc.aiStyle = 14;
			npc.npcSlots = 0.2f;
			npc.HitSound = SoundID.NPCHit1;
			npc.noGravity = true;
			npc.DeathSound = SoundID.NPCDeath4;
			npc.value = Item.buyPrice(0, 0, 6, 9);
			banner = npc.type;
			bannerItem = mod.ItemType("TwilightBatBanner");
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 1);
			npc.damage = (int)(npc.damage * 1);
		}

		public override void NPCLoot()
		{
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
				int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
				int halfLength = npc.width / 2 / 16 + 1;
				if (Main.rand.Next(1) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("NightmareOre"));
				}
			}
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 27, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TwilightGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TwilightGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TwilightGore2"), 1f);
				Dust.NewDust(npc.position, npc.width, npc.height, 27, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 3f);
				Dust.NewDust(npc.position, npc.width, npc.height, 27, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 2f);
				Dust.NewDust(npc.position, npc.width, npc.height, 27, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 3f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return (Tremor.NormalSpawn(spawnInfo) && Tremor.NoZoneAllowWater(spawnInfo)) && NPC.downedMoonlord && Main.hardMode && !Main.dayTime && y < Main.worldSurface ? 0.02f : 0f;
		}
	}
}