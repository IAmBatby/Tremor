using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Mobs
{

	public class GhoulOfficer : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ghoul Officer");
			Main.npcFrameCount[npc.type] = 20;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 500;
			npc.damage = 70;
			npc.defense = 12;
			npc.knockBackResist = 0.3f;
			npc.width = 48;
			npc.height = 54;
			animationType = 482;
			npc.aiStyle = 3;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath40;
			npc.value = Item.buyPrice(0, 0, 30, 7);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("GhoulOfficerBanner");
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
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GhoulOfficerGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GhoulOfficerGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GhoulOfficerGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GhoulOfficerGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GhoulOfficerGore4"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GhoulOfficerGore5"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GhoulOfficerGore5"), 1f);
			}
		}

	}
}