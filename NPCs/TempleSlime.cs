using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace Tremor.NPCs
{
	public class TempleSlime : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Temple Slime");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 2000;
			npc.damage = 125;
			npc.defense = 32;
			npc.knockBackResist = 0.3f;
			npc.width = 70;
			npc.height = 46;
			animationType = 244;
			npc.aiStyle = 41;
			aiType = 138;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath23;
			npc.value = Item.buyPrice(0, 0, 12, 15);
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool())
				this.NewItem(ItemID.LihzahrdPowerCell);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 4, 2.5f * hitDirection, -2.5f, 0, Color.Brown, 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 4, 2.5f * hitDirection, -2.5f, 0, Color.Brown, 0.7f);
				}

				Dust.NewDust(npc.position, npc.width, npc.height, 4, 2.5f * hitDirection, -2.5f, 0, Color.Brown, 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 4, 2.5f * hitDirection, -2.5f, 0, Color.Brown, 1.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 4, 2.5f * hitDirection, -2.5f, 0, Color.Brown, 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 4, 2.5f * hitDirection, -2.5f, 0, Color.Brown, 1.7f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Main.hardMode && spawnInfo.spawnTileType == TileID.LihzahrdBrick && NPC.downedMoonlord && spawnInfo.spawnTileY > Main.rockLayer ? 0.005f : 0f;
	}
}