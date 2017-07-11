using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class UndeadArchaeologist2 : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Undead Archaeologist");
			Main.npcFrameCount[npc.type] = 15;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 150;
			npc.damage = 27;
			npc.defense = 14;
			npc.knockBackResist = 0.3f;
			npc.width = 36;
			npc.height = 44;
			animationType = 21;
			npc.aiStyle = 3;
			npc.npcSlots = 0.5f;
			aiType = 77;
			npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = Item.buyPrice(0, 0, 6, 9);
			banner = npc.type;
			bannerItem = mod.ItemType("UndeadArchaeologistBanner");
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
					Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UAG4"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UAG2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UAG2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UAG3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UAG3"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)

		{

			int x = spawnInfo.spawnTileX;

			int y = spawnInfo.spawnTileY;

			int tile = (int)Main.tile[x, y].type;

			return (Tremor.NormalSpawn(spawnInfo) && !Main.dayTime && Tremor.NoZoneAllowWater(spawnInfo)) && spawnInfo.player.ZoneDesert ? 0.04f : 0f;
		}
	}
}