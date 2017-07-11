using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace Tremor.NPCs
{

	public class RichSlime : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rich Slime");
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 1100;
			npc.damage = 210;
			npc.defense = 45;
			npc.knockBackResist = 0.3f;
			npc.width = 32;
			npc.height = 46;
			animationType = 1;
			npc.aiStyle = 1;
			aiType = 1;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath23;
			npc.value = Item.buyPrice(1, 0, 0, 0);
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
					Dust.NewDust(npc.position, npc.width, npc.height, 4, 2.5f * (float)hitDirection, -2.5f, 0, Color.Yellow, 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 4, 2.5f * (float)hitDirection, -2.5f, 0, Color.Yellow, 0.7f);
				}
				Dust.NewDust(npc.position, npc.width, npc.height, 4, 2.5f * (float)hitDirection, -2.5f, 0, Color.Yellow, 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 4, 2.5f * (float)hitDirection, -2.5f, 0, Color.Yellow, 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 4, 2.5f * (float)hitDirection, -2.5f, 0, Color.Yellow, 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 1, 2.5f * (float)hitDirection, -2.5f, 0, Color.Yellow, 0.7f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.spawnTileY < Main.rockLayer && Main.hardMode && Tremor.NoInvasion(spawnInfo) && NPC.downedMoonlord && Main.dayTime ? 0.005f : 0f;
		}

		public override void NPCLoot()
		{
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
				int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
				int halfLength = npc.width / 2 / 16 + 1;
				if (Main.rand.Next(1) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 23, Main.rand.Next(5, 9));
				};
				if (Main.rand.Next(50) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FashionableHat"));
				};
			}
		}

	}
}