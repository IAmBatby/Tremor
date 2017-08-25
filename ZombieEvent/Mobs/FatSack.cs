using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Mobs
{

	public class FatSack : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fat Sack");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 100;
			npc.damage = 10;
			npc.defense = 26;
			npc.knockBackResist = 0.3f;
			npc.width = 34;
			npc.height = 46;
			animationType = 3;
			npc.aiStyle = 3;
			npc.npcSlots = 2f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = Item.buyPrice(0, 0, 1, 0);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("FatSackBanner");
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
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FatSackGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FatSackGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FatSackGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FatSackGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FatSackGore3"), 1f);
			}
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
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 331, Main.rand.Next(1, 3));
				}

			}
		}
	}
}