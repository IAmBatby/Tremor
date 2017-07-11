using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class SnowmanBomber : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Snowman Bomber");
			Main.npcFrameCount[npc.type] = 20;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 400;
			npc.damage = 60;
			npc.defense = 15;
			npc.knockBackResist = 0.1f;
			npc.width = 34;
			npc.height = 46;
			animationType = 293;
			npc.aiStyle = 3;
			aiType = 293;
			npc.npcSlots = 0.3f;
			npc.HitSound = SoundID.NPCHit11;
			npc.DeathSound = SoundID.NPCDeath38;
			npc.value = Item.buyPrice(0, 0, 4, 7);
			banner = npc.type;
			bannerItem = mod.ItemType("SnowmanBomberBanner");
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
					Dust.NewDust(npc.position, npc.width, npc.height, 76, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1f);
				}
				Dust.NewDust(npc.position, npc.width, npc.height, 76, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 3f);
				Dust.NewDust(npc.position, npc.width, npc.height, 76, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 2f);
				Dust.NewDust(npc.position, npc.width, npc.height, 76, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 3f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return NPC.AnyNPCs(144) && Main.hardMode && y < Main.worldSurface ? 0.08f : 0f;
		}
	}
}