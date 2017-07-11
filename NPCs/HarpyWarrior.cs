using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class HarpyWarrior : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Harpy Warrior");
			Main.npcFrameCount[npc.type] = 4;
		}


		public override void SetDefaults()
		{
			npc.lifeMax = 300;
			npc.damage = 90;
			npc.defense = 17;
			npc.knockBackResist = 0.3f;
			npc.width = 80;
			npc.height = 60;
			animationType = 48;
			npc.aiStyle = 14;
			aiType = 48;
			npc.npcSlots = 1f;
			npc.HitSound = SoundID.NPCHit1;
			npc.noGravity = true;
			npc.DeathSound = SoundID.NPCDeath4;
			npc.value = Item.buyPrice(0, 0, 8, 9);
			banner = npc.type;
			bannerItem = mod.ItemType("HarpyWarriorBanner");
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HarpyGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HarpyGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/HarpyGore2"), 1f);
			}
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
			return Tremor.NoZoneAllowWater(spawnInfo) && Main.hardMode && spawnInfo.sky ? 0.02f : 0;
		}
	}
}