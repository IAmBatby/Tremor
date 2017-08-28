using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class DevourerofPlanets : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Devourer of Planets");
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 15000;
			npc.damage = 130;
			npc.defense = 132;
			npc.knockBackResist = 0f;
			npc.width = 50;
			npc.height = 78;
			animationType = 6;
			aiType = 6;
			npc.aiStyle = 5;
			npc.npcSlots = 0.5f;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit37;
			npc.noGravity = true;
			npc.DeathSound = SoundID.NPCDeath40;
			npc.value = Item.buyPrice(0, 2, 25, 9);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("DevourerofPlanetsBanner");
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool())
				npc.NewItem(mod.ItemType<HuskofDusk>(), Main.rand.Next(2, 5));
			if (Main.rand.Next(10) == 0)
				npc.NewItem(mod.ItemType<EyeofOblivion>());
			if (Main.rand.Next(3) == 0)
				npc.NewItem(mod.ItemType<NightCore>());
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 27, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 27, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 27, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 27, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 27, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 27, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 27, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}

				for(int i = 0; i < 3; ++i)
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot($"Gores/DevourerofPlanetsGore{i+1}"), 1f);
			}
			else
			{
				for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 27, hitDirection, -1f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 22, hitDirection, -1f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 27, hitDirection, -1f, 0, default(Color), 0.7f);
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Main.hardMode && TremorWorld.Boss.Trinity.IsDowned() && !spawnInfo.player.ZoneDungeon && spawnInfo.spawnTileY > Main.rockLayer ? 0.005f : 0f;
	}
}