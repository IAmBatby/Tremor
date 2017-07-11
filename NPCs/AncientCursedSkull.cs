using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class AncientCursedSkull : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Cursed  Skull");
			Main.npcFrameCount[npc.type] = 6;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 4000;
			npc.damage = 122;
			npc.defense = 80;
			npc.knockBackResist = 0.2f;
			npc.width = 80;
			npc.height = 65;
			animationType = 289;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.aiStyle = 10;
			aiType = 289;
			npc.npcSlots = 5f;
			npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = Item.buyPrice(0, 0, 8, 0);
			banner = npc.type;
			bannerItem = mod.ItemType("AncientCursedSkullBanner");
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 1);
			npc.damage = (int)(npc.damage * 1);
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return (Tremor.NoZoneAllowWater(spawnInfo)) && spawnInfo.player.ZoneDungeon && NPC.downedMoonlord && Main.hardMode && y > Main.rockLayer ? 0.008f : 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 60; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 15, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 15, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 15, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 15, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Dust.NewDust(npc.position, npc.width, npc.height, 15, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 15, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 15, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
			}
			else
			{
				for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 15, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
			}
		}
	}
}