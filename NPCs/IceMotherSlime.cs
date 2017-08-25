using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class IceMotherSlime : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ice Mother Slime");
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 120;
			npc.damage = 22;
			npc.defense = 4;
			npc.knockBackResist = 0.6f;
			npc.width = 32;
			npc.height = 22;
			animationType = 1;
			npc.aiStyle = 1;
			aiType = 141;
			npc.npcSlots = 0.1f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = Item.buyPrice(0, 0, 6, 50);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("IceMotherSlimeBanner");
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y - 48, 147);
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y - 48, 147);
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y - 48, 147);
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.6f);
				}
			}
		}

		public override void AI()
		{
			if (Main.rand.Next(10) == 0)
			{
				int num706 = Dust.NewDust(npc.position, npc.width, npc.height, 80, 0f, 0f, 200, npc.color, 1f);
				Main.dust[num706].velocity *= 0.3f;
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
			return (Helper.NoZoneAllowWater(spawnInfo)) && Main.cloudAlpha > 0f && y < Main.worldSurface && spawnInfo.player.ZoneSnow ? 0.01f : 0f;
		}
	}
}