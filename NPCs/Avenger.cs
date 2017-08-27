using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class Avenger : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Avenger");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 1750;
			npc.damage = 165;
			npc.defense = 80;
			npc.knockBackResist = 0.0f;
			npc.width = 80;
			npc.height = 80;
			animationType = 82;
			npc.aiStyle = 97;
			aiType = 420;
			npc.npcSlots = 0.4f;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit4;
			npc.noGravity = true;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = Item.buyPrice(0, 0, 4, 15);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("AvengerBanner");
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life > 0)
				Main.dust[Dust.NewDust(npc.position, npc.width, npc.height, 71, 0f, 0f, 200)].velocity *= 1.5F;
			else
			{
				for (int i = 0; i < 50; i++)
				{
					Main.dust[Dust.NewDust(npc.position, npc.width, npc.height, 71, hitDirection, 0f, 200)].velocity *= 1.5f;

					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AvengerGore1"), 1f);
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AvengerGore1"), 1f);
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AvengerGore2"), 1f);
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AvengerGore2"), 1f);
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AvengerGore3"), 1f);
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AvengerGore4"), 1f);
				}
			}
		}

		public override void NPCLoot()
		{			
			if (Main.rand.Next(3) == 0)
				npc.NewItem((short)mod.ItemType<CarbonSteel>(), Main.rand.Next(1, 3));
			if (Main.rand.Next(5) == 0)
				npc.NewItem((short)mod.ItemType<GoldenClaw>(), Main.rand.Next(1, 5));
			if (Main.rand.Next(10) == 0)
				npc.NewItem((short)mod.ItemType<AngryShard>(), Main.rand.Next(1, 3));
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo) && NPC.downedMoonlord && Main.hardMode && !Main.dayTime && spawnInfo.spawnTileY < Main.worldSurface ? 0.03f : 0f;
		}
	}
}