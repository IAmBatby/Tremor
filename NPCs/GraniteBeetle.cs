using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class GraniteBeetle : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Granite Beetle");
			Main.npcFrameCount[npc.type] = 6;
		}

		public override void SetDefaults()
		{
			npc.width = 38;
			npc.height = 44;
			npc.damage = 16;
			npc.defense = 22;
			npc.lifeMax = 65;
			npc.HitSound = SoundID.NPCHit41;
			npc.DeathSound = SoundID.NPCDeath44;
			npc.value = Item.buyPrice(0, 0, 2, 7);
			npc.knockBackResist = 0.4f;
			npc.aiStyle = 3;
			aiType = 258;
			//npc.noGravity = false;
			animationType = 258;
			npc.buffImmune[20] = true;
			npc.buffImmune[31] = false;
			npc.buffImmune[24] = true;
			banner = npc.type;
			bannerItem = mod.ItemType("GraniteBeetleBanner");
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool(2))
				this.NewItem(ItemID.Granite, Main.rand.Next(10));
			if (Main.rand.NextBool(2))
				this.NewItem(mod.ItemType<StoneofLife>());
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 31, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GBeetleGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GBeetleGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GBeetleGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GBeetleGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GBeetleGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GBeetleGore3"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.spawnTileType == TileID.Granite && spawnInfo.spawnTileY > Main.rockLayer ? 0.01f : 0f;
	}
}
