using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class NightTerror : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Night Terror");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 10000;
			npc.damage = 122;
			npc.defense = 30;
			npc.knockBackResist = 0.6f;
			npc.width = 75;
			npc.height = 95;
			animationType = 82;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.aiStyle = 22;
			aiType = 82;
			npc.npcSlots = 5f;
			npc.HitSound = SoundID.NPCHit54;
			npc.DeathSound = SoundID.NPCDeath52;
			npc.value = Item.buyPrice(0, 0, 8, 0);
			banner = npc.type;
			bannerItem = mod.ItemType("NightTerrorBanner");
		}

		public override void NPCLoot()
		{
			if (Main.rand.Next(40) == 0)
				this.NewItem(mod.ItemType<AxeofExecutioner>());
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 60; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 54, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 54, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 54, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}

				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 54, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(npc.position, npc.velocity, 99, 1f);
				Gore.NewGore(npc.position, npc.velocity, 99, 1f);
				Gore.NewGore(npc.position, npc.velocity, 99, 1f);
				Gore.NewGore(npc.position, npc.velocity, 99, 1f);
				Gore.NewGore(npc.position, npc.velocity, 99, 1f);
				Gore.NewGore(npc.position, npc.velocity, 99, 1f);
			}
			else
			{
				for (int k = 0; k < damage / npc.lifeMax * 50; k++)
					Gore.NewGore(npc.position, npc.velocity, 99, 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> (Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo)) && NPC.downedMoonlord && Main.hardMode && Main.bloodMoon && spawnInfo.spawnTileY < Main.worldSurface ? 0.004f : 0f;
	}
}