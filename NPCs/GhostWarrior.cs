using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class GhostWarrior : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ghost Warrior");
			Main.npcFrameCount[npc.type] = 15;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 6400;
			npc.damage = 16;
			npc.defense = 90;
			npc.knockBackResist = 0.3f;
			npc.width = 36;
			npc.alpha = 120;
			npc.height = 44;
			animationType = 21;
			npc.aiStyle = 3;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = Item.buyPrice(0, 0, 4, 7);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("GhostWarriorBanner");
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(3) == 0)
				npc.NewItem(mod.ItemType<GoldenClaw>());
			if (Main.rand.NextBool(2))
				npc.NewItem(mod.ItemType<LapisLazuli>());
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UndeadGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GWGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GWGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GWGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/UndeadGore1"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo) && TremorWorld.Boss.Trinity.IsDowned() && NPC.downedMoonlord && Main.hardMode && !Main.dayTime && spawnInfo.spawnTileY < Main.worldSurface ? 0.005f : 0f;
	}
}