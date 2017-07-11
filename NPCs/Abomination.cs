using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace Tremor.NPCs
{

	public class Abomination : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Abomination");
			Main.npcFrameCount[npc.type] = 9;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 125;
			npc.damage = 25;
			npc.defense = 15;
			npc.knockBackResist = 0.6f;
			npc.width = 38;
			npc.height = 44;
			animationType = 489;
			npc.aiStyle = 3;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit31;
			aiType = 77;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = Item.buyPrice(0, 0, 4, 0);
			banner = npc.type;
			bannerItem = mod.ItemType("AbominationBanner");
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				NPC.NewNPC((int)npc.position.X - 22, (int)npc.position.Y + 55, 21);
			}
		}

		public override void AI()
		{

			if (Main.rand.Next(1000) == 0)
			{
				Main.PlaySound(22, (int)npc.position.X, (int)npc.position.Y, 1);
			}
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
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 331, Main.rand.Next(1, 3));
				}

			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return (Tremor.NoZoneAllowWater(spawnInfo)) && spawnInfo.player.ZoneJungle && y > Main.rockLayer ? 0.01f : 0f;
		}
	}
}