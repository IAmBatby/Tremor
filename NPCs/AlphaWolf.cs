using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;
using Tremor.Items.Wolf;

namespace Tremor.NPCs
{
	public class AlphaWolf : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alpha Wolf");
			Main.npcFrameCount[npc.type] = 9;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 88;
			npc.damage = 23;
			npc.defense = 10;
			npc.knockBackResist = 0.6f;
			npc.width = 76;
			npc.height = 38;
			animationType = 155;
			npc.aiStyle = 26;
			npc.npcSlots = 1f;
			npc.HitSound = SoundID.NPCHit6;
			npc.DeathSound = SoundID.NPCDeath5;
			npc.value = Item.buyPrice(0, 0, 4, 0);
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool(2))
				npc.NewItem((short)mod.ItemType<WolfPelt>(), Main.rand.Next(2, 3));
			if (Main.rand.Next(25) == 0)
				npc.NewItem((short)mod.ItemType<FurHat>());
			if (Main.rand.NextBool())
				npc.NewItem((short)mod.ItemType<AlphaClaw>());
			if (Main.rand.Next(25) == 0)
				npc.NewItem((short)mod.ItemType<FurCoat>());
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				for(int i = 0; i < 2; ++i)
				{
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot($"Gores/WolfGore{i+1}"), 1f);
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot($"Gores/AlphaWolfGore{i+1}"), 1f);
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.player.ZoneSnow && !Main.dayTime && spawnInfo.spawnTileY < Main.worldSurface ? 0.08f : 0f;
		}
	}
}