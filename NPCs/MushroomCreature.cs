using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class MushroomCreature : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mushroom Creature");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 80;
			npc.damage = 22;
			npc.defense = 5;
			npc.knockBackResist = 0.3f;
			npc.width = 38;
			npc.height = 50;
			animationType = 75;
			npc.aiStyle = 3;
			npc.npcSlots = 1f;
			npc.HitSound = SoundID.NPCHit40;
			npc.DeathSound = SoundID.NPCDeath24;
			npc.value = Item.buyPrice(0, 0, 3, 20);
			banner = npc.type;
			aiType = 21;
			bannerItem = mod.ItemType("MushroomCreatureBanner");
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 1);
			npc.damage = (int)(npc.damage * 1);
		}

		public override void AI()
		{

			if (Main.rand.Next(1000) == 0)
			{
				Main.PlaySound(22, (int)npc.position.X, (int)npc.position.Y, 1);
			}
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				//Gore.NewGore(npc.position, npc.velocity, mod.GoreType("Orc1Gore1"), 1f);
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return (Tremor.NormalSpawn(spawnInfo) && (tile == 70)) && y < Main.rockLayer ? 0.03f : 0f;
		}
	}
}