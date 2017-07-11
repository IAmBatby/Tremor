using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class ArchDemon : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Arch Demon");
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 300;
			npc.damage = 62;
			npc.defense = 2;
			npc.knockBackResist = 0.3f;
			npc.width = 66;
			npc.height = 58;
			animationType = 62;
			npc.aiStyle = 14;
			npc.npcSlots = 15f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = Item.buyPrice(0, 0, 2, 50);
			banner = npc.type;
			bannerItem = mod.ItemType("ArchDemonBanner");
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = npc.lifeMax * 1;
			npc.damage = npc.damage * 1;
		}

		public override void AI()
		{
			if (Main.rand.Next(125) == 0)
			{
				NPC.NewNPC((int)npc.position.X - 50, (int)npc.position.Y, mod.NPCType("FlamingReaper"));
			}
		}


		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ArchdemonGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ArchdemonGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ArchdemonGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ArchdemonGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ArchdemonGore3"), 1f);
			}
		}

	}
}