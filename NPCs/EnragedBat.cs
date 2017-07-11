using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class EnragedBat : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enraged Bat");
			Main.npcFrameCount[npc.type] = 4;
		}


		public override void SetDefaults()
		{
			npc.lifeMax = 1000;
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
			bannerItem = mod.ItemType("EnragedBatBanner");
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
					Dust.NewDust(npc.position, npc.width, npc.height, 27, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/EnragedGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/EnragedGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/EnragedGore2"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return Main.hardMode && NPC.downedMoonlord && !spawnInfo.player.ZoneDungeon && y > Main.rockLayer ? 0.1f : 0f;
		}
	}
}