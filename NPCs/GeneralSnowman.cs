using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class GeneralSnowman : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("General Snowman");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 800;
			npc.damage = 50;
			npc.defense = 22;
			npc.knockBackResist = 0.1f;
			npc.width = 34;
			npc.height = 46;
			animationType = 143;
			npc.aiStyle = 38;
			aiType = 143;
			npc.npcSlots = 0.3f;
			npc.HitSound = SoundID.NPCHit11;
			npc.DeathSound = SoundID.NPCDeath15;
			npc.value = Item.buyPrice(0, 0, 8, 7);
			banner = npc.type;
			bannerItem = mod.ItemType("GeneralSnowmanBanner");
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
					Dust.NewDust(npc.position, npc.width, npc.height, 76, 2.5f * hitDirection, -2.5f, 0, default(Color), 1f);
				}
				Dust.NewDust(npc.position, npc.width, npc.height, 76, 2.5f * hitDirection, -2.5f, 0, default(Color), 3f);
				Dust.NewDust(npc.position, npc.width, npc.height, 76, 2.5f * hitDirection, -2.5f, 0, default(Color), 2f);
				Dust.NewDust(npc.position, npc.width, npc.height, 76, 2.5f * hitDirection, -2.5f, 0, default(Color), 3f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = Main.tile[x, y].type;
			return NPC.AnyNPCs(144) && Main.hardMode && y < Main.worldSurface ? 0.01f : 0f;
		}
	}
}