using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace Tremor.NPCs
{
	public class HiveHeadZombie : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hivehead Zombie");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 125;
			npc.damage = 25;
			npc.defense = 15;
			npc.knockBackResist = 0.3f;
			npc.width = 34;
			npc.height = 40;
			animationType = 3;
			npc.aiStyle = 3;
			npc.npcSlots = 1f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = Item.buyPrice(0, 0, 3, 0);
			banner = npc.type;
			bannerItem = mod.ItemType("HiveHeadZombieBanner");
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZombieGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZombieGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZombieGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ZombieGore2"), 1f);

				if (Main.netMode != 1)
				{
					NPC.NewNPC((int)npc.position.X - 22, (int)npc.position.Y + 55, NPCID.Bee);
					NPC.NewNPC((int)npc.position.X + 37, (int)npc.position.Y, NPCID.Bee);
					NPC.NewNPC((int)npc.position.X, (int)npc.position.Y - 48, NPCID.Bee);
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> (Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo)) && NPC.downedQueenBee && !Main.dayTime && spawnInfo.spawnTileY < Main.worldSurface ? 0.01f : 0f;
	}
}