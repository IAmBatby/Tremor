using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class PossessedHornet1 : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Possessed Hornet");
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 1500;
			npc.damage = 140;
			npc.defense = 72;
			npc.knockBackResist = 0.05f;
			npc.width = 32;
			npc.height = 40;
			animationType = 176;
			npc.aiStyle = 5;
			aiType = 176;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath44;
			npc.noGravity = true;
			npc.value = Item.buyPrice(0, 0, 10, 0);
			banner = npc.type;
			bannerItem = mod.ItemType("PossessedHornetBanner");
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = npc.lifeMax * 1;
			npc.damage = npc.damage * 1;
		}

		public override void NPCLoot()
		{
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + npc.width / 2) / 16;
				int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
				int halfLength = npc.width / 2 / 16 + 1;
				if (Main.rand.NextBool())
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PurpleQuartz"), 2);
				}
			}
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType<Dusts.NightmareFlame>(), 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PHGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PHGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PHGore3"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = Main.tile[x, y].type;
			return (Helper.NoZoneAllowWater(spawnInfo)) && spawnInfo.player.ZoneJungle && NPC.downedMoonlord && Main.hardMode && y > Main.rockLayer ? 0.01f : 0f;
		}
	}
}