using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class CoreBug : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Space Bug");
			Main.npcFrameCount[npc.type] = 6;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 150;
			npc.damage = 18;
			npc.defense = 10;
			npc.knockBackResist = 0.6f;
			npc.width = 38;
			npc.height = 44;
			animationType = 258;
			npc.aiStyle = 3;
			aiType = 258;
			npc.npcSlots = 0.2f;
			npc.HitSound = SoundID.NPCHit45;
			npc.DeathSound = SoundID.NPCDeath47;
			npc.value = Item.buyPrice(0, 0, 2, 24);
			banner = npc.type;
			bannerItem = mod.ItemType("CoreBugBanner");
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
				Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 6, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.6f);
				}
			}
		}

		public override void AI()
		{
			if (Main.rand.Next(4) == 0)
			{
				int num706 = Dust.NewDust(npc.position, npc.width, npc.height, 6, 0f, 0f, 200, npc.color, 1f);
				Main.dust[num706].velocity *= 0.3f;
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return (Tremor.NoZoneAllowWater(spawnInfo)) && spawnInfo.player.ZoneMeteor ? 0.005f : 0f;
		}
	}
}