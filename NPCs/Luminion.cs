using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class Luminion : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Luminion");
			Main.npcFrameCount[npc.type] = 15;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 2000;
			npc.damage = 120;
			npc.defense = 100;
			npc.knockBackResist = 0.0f;
			npc.width = 46;
			npc.height = 32;
			aiType = 417;
			animationType = 417;
			npc.aiStyle = 39;
			npc.npcSlots = 2f;
			npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath5;
			npc.value = Item.buyPrice(0, 0, 6, 9);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("LuminionBanner");
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool(4))
				this.NewItem(mod.ItemType<Squorb>(), Main.rand.Next(1, 3));
			if (Main.rand.NextBool())
				this.NewItem(ItemID.LunarBar, Main.rand.Next(3, 8));
			if (Main.rand.NextBool(2))
				this.NewItem(mod.ItemType<LunarRoot>(), Main.rand.Next(2, 4));
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 74, 2.5f * hitDirection, -2.5f, 0, default(Color), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/LuminionGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/LuminionGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/LuminionGore2"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Main.hardMode && NPC.downedMoonlord && !spawnInfo.player.ZoneDungeon && spawnInfo.spawnTileY > Main.rockLayer ? 0.01f : 0f;
	}
}