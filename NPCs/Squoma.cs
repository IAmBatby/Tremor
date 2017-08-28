using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class Squoma : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Squoma");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 8200;
			npc.damage = 122;
			npc.defense = 128;
			npc.knockBackResist = 0.2f;
			npc.width = 34;
			npc.height = 48;
			animationType = 48;
			npc.aiStyle = 14;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit53;
			npc.noGravity = true;
			npc.DeathSound = SoundID.NPCDeath45;
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("SquomaBanner");
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(3) == 0)
				this.NewItem(mod.ItemType<Squorb>(), Main.rand.Next(1, 3));
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 59, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SquomaGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SquomaGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SquomaGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SquomaGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SquomaGore2"), 1f);
			}
			else
			{
				for (int k = 0; k < damage / npc.lifeMax * 50; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 59, hitDirection, -1f, 0, default(Color), 0.7f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo) && NPC.downedMoonlord && Main.hardMode && spawnInfo.player.ZoneSnow && spawnInfo.spawnTileY < Main.worldSurface ? 0.08f : 0f;
	}
}