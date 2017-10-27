using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class ColossalTortoise : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Colossal Tortoise");
			Main.npcFrameCount[npc.type] = 16;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 25000;
			npc.damage = 200;
			npc.defense = 300;
			npc.knockBackResist = 0.0f;
			npc.width = 146;
			npc.height = 86;
			animationType = 21;
			npc.aiStyle = 3;
			aiType = 28;
			npc.npcSlots = 0.3f;
			npc.HitSound = SoundID.NPCHit24;
			npc.DeathSound = SoundID.NPCDeath10;
			npc.value = Item.buyPrice(0, 4, 15, 0);
		}

		public override void AI()
		{
			Lighting.AddLight(npc.position, 1f, 0.3f, 0.3f);

			if (Main.netMode != 1 && Main.rand.Next(750) == 0)
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.GiantTortoise);
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool())
				npc.NewItem(mod.ItemType<GiantShell>(), Main.rand.Next(1, 3));
			if (Main.rand.NextBool(3))
				npc.NewItem(mod.ItemType<LostTurtleKnife>(), Main.rand.Next(10, 55));
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 60; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 3, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 3, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ColossusTortoiseGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ColossusTortoiseGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ColossusTortoiseGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ColossusTortoiseGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ColossusTortoiseGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ColossusTortoiseGore3"), 1f);
			}
			else
			{
				for (int k = 0; k < damage / npc.lifeMax * 50; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 3, hitDirection, -2f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 5, hitDirection, -1f, 0, default(Color), 0.7f);
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.player.ZoneJungle && NPC.downedMoonlord && Main.hardMode && spawnInfo.spawnTileY < Main.worldSurface ? 0.0002f : 0f;
	}
}