using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class OrcSkeleton : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Orc Skeleton");
			Main.npcFrameCount[npc.type] = 20;
		}

		public override void SetDefaults()
		{
			aiType = 77;
			npc.lifeMax = 150;
			npc.damage = 30;
			npc.defense = 10;
			npc.knockBackResist = 0.3f;
			npc.width = 36;
			npc.height = 44;
			animationType = 482;
			npc.aiStyle = 3;
			npc.npcSlots = 0.6f;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = Item.buyPrice(0, 0, 6, 9);
			banner = npc.type;
			bannerItem = mod.ItemType("OrcSkeletonBanner");
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
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/OrcSkeletonGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/OrcSkeletonGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/OrcSkeletonGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/OrcSkeletonGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/OrcSkeletonGore3"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = Main.tile[x, y].type;
			return (Tremor.NoZoneAllowWater(spawnInfo)) && NPC.downedBoss1 && y > Main.rockLayer ? 0.01f : 0f;
		}

	}
}