using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class Thief1 : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thief");
			Main.npcFrameCount[npc.type] = 16;
		}

		public override void SetDefaults()
		{
			npc.width = 40;
			npc.height = 40;
			npc.damage = 9;
			npc.defense = 7;
			npc.lifeMax = 90;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = Item.buyPrice(0, 0, 2, 7);
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 3;
			aiType = 73;
			npc.aiStyle = 3;
			animationType = 27;
			banner = npc.type;
			bannerItem = mod.ItemType("ThiefBanner");
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(6) == 0)
				this.NewItem(mod.ItemType<LeatherHat>());
			if (Main.rand.Next(6) == 0)
				this.NewItem(mod.ItemType<LeatherGreaves>());
			if (Main.rand.Next(6) == 0)
				this.NewItem(mod.ItemType<LeatherShirt>());
			if (Main.rand.Next(6) == 0)
				this.NewItem(mod.ItemType<ChainCoif>());
			if (Main.rand.Next(6) == 0)
				this.NewItem(mod.ItemType<ChainGreaves>());
			if (Main.rand.Next(6) == 0)
				this.NewItem(mod.ItemType<Chainmail>());

			if (Main.rand.Next(3) == 0)
				this.NewItem(ItemID.LesserHealingPotion);
			if (Main.rand.Next(3) == 0)
				this.NewItem(ItemID.LesserManaPotion);
			if (Main.rand.Next(3) == 0)
				this.NewItem(ItemID.Bottle);
			if (Main.rand.Next(3) == 0)
				this.NewItem(ItemID.Torch);
			if (Main.rand.Next(3) == 0)
				this.NewItem(ItemID.Chain);
			if (Main.rand.Next(3) == 0)
				this.NewItem(ItemID.Leather);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Thief1Gore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Thief1Gore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Thief1Gore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Thief1Gore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Thief1Gore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Thief1Gore4"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> spawnInfo.spawnTileY < Main.rockLayer && Main.dayTime ? (NPC.downedBoss2 ? 0.02f : 0.002f) : 0f;
	}
}
