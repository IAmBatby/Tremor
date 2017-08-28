using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class Orc : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Orc");
			Main.npcFrameCount[npc.type] = 20;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 80;
			npc.damage = 22;
			npc.defense = 5;
			npc.knockBackResist = 0.3f;
			npc.width = 48;
			aiType = 77;
			npc.height = 54;
			animationType = 482;
			npc.aiStyle = 3;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath40;
			npc.value = Item.buyPrice(0, 0, 6, 7);
			banner = npc.type;
			bannerItem = mod.ItemType("OrcBanner");
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Orc1Gore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Orc1Gore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Orc1Gore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Orc1Gore2"), 1f);
			}
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(20) == 0)
				this.NewItem(mod.ItemType<OrcishShield>());
			if (Main.rand.Next(20) == 0)
				this.NewItem(mod.ItemType<OrcishKnife>());
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo) && NPC.downedBoss1 && spawnInfo.spawnTileY < Main.worldSurface ? 0.1f : 0f;
	}
}