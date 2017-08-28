using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class EliteBloodmoonWarrior : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Elite Bloodmoon Warrior");
			Main.npcFrameCount[npc.type] = 20;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 1750;
			npc.damage = 135;
			npc.defense = 36;
			npc.knockBackResist = 0.1f;
			npc.width = 36;
			npc.height = 44;
			animationType = 482;
			npc.aiStyle = 26;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = Item.buyPrice(0, 0, 50, 7);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("EliteBloodmoonWarriorBanner");
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool())
				npc.NewItem(mod.ItemType<SkullTeeth>());
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/EliteGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/EliteGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/EliteGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/EliteGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/EliteGore3"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> (Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo)) && NPC.downedMechBossAny && Main.bloodMoon && spawnInfo.spawnTileY < Main.worldSurface ? 0.03f : 0f;
	}
}