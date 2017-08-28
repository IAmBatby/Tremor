using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class Dranix : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dranix");
			Main.npcFrameCount[npc.type] = 10;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 1600;
			npc.damage = 110;
			npc.defense = 20;
			npc.knockBackResist = 0.3f;
			npc.width = 56;
			npc.height = 48;
			aiType = 429;
			animationType = 429;
			npc.aiStyle = 3;
			npc.npcSlots = 0.2f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = Item.buyPrice(0, 0, 6, 9);
			banner = npc.type;
			bannerItem = mod.ItemType("DranixBanner");
		}

		public override void AI()
		{
			if (Main.rand.Next(1000) == 0)
				Main.PlaySound(22, (int)npc.position.X, (int)npc.position.Y, 1);
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(2) == 0)
				npc.NewItem(mod.ItemType<Doomstone>());
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 74, 2.5f * hitDirection, -2.5f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DranixGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DranixGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DranixGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DranixGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/DranixGore3"), 1f);

			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Main.hardMode && NPC.downedMoonlord && !spawnInfo.player.ZoneDungeon && spawnInfo.spawnTileY > Main.rockLayer ? 0.04f : 0f;
	}
}