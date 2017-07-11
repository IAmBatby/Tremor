using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class DreadBeetle : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dread Beetle");
			Main.npcFrameCount[npc.type] = 6;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 1800;
			npc.damage = 150;
			npc.defense = 30;
			npc.knockBackResist = 0.6f;
			npc.width = 38;
			npc.height = 44;
			animationType = 258;
			npc.aiStyle = 3;
			aiType = 258;
			npc.npcSlots = 0.2f;
			npc.HitSound = SoundID.NPCHit45;
			npc.DeathSound = SoundID.NPCDeath47;
			npc.value = Item.buyPrice(0, 0, 8, 24);
			banner = npc.type;
			npc.noGravity = false;
			bannerItem = mod.ItemType("DreadBeetleBanner");
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
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Doomstone"));
				}
			}
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DreadGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DreadGore2"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = Main.tile[x, y].type;
			return Main.hardMode && NPC.downedMoonlord && !spawnInfo.player.ZoneDungeon && y > Main.rockLayer ? 0.04f : 0f;
		}
	}
}