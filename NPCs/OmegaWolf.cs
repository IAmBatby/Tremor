using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class OmegaWolf : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Omega Wolf");
			Main.npcFrameCount[npc.type] = 9;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 28;
			npc.damage = 16;
			npc.defense = 5;
			npc.knockBackResist = 0.6f;
			npc.width = 62;
			npc.height = 32;
			animationType = 155;
			npc.aiStyle = 26;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit6;
			npc.DeathSound = SoundID.NPCDeath5;
			npc.value = Item.buyPrice(0, 0, 5, 0);
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(2) == 0)
				this.NewItem(mod.ItemType<WolfPelt>());
			if (Main.rand.Next(25) == 0)
				this.NewItem(mod.ItemType<FurHat>());
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/OmegaWolfGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/OmegaWolfGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WolfGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WolfGore1"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.player.ZoneSnow && spawnInfo.spawnTileY < Main.worldSurface ? 0.02f : 0f;
	}
}