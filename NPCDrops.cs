using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace Tremor
{
	public class NPCDrops : GlobalNPC
	{
		internal static readonly int[] VanillaWoFWeapons =
		{
			ItemID.LaserRifle,
			ItemID.BreakerBlade,
			ItemID.ClockworkAssaultRifle
		};

		internal static readonly int[] VanillaWoFEmblems =
		{
			ItemID.WarriorEmblem,
			ItemID.RangerEmblem,
			ItemID.SorcererEmblem,
			ItemID.SummonerEmblem,
			ModLoader.GetMod("Tremor").ItemType("AlchemistEmblem"),
			ModLoader.GetMod("Tremor").ItemType("ThrowerEmblem")
		};

		public override void NPCLoot(NPC npc)
		{
			switch (npc.type)
			{
				case NPCID.WallofFlesh:
					bool dropEmblemAlchemist = Main.rand.NextBool(1, 5);
					if (dropEmblemAlchemist)
					{
						if (Main.rand.NextBool(1, 7))
						{
							Item.NewItem(npc.position, npc.width, npc.height, ItemID.FleshMask);
						}
						if (Main.rand.NextBool(1, 7))
						{
							Item.NewItem(npc.position, npc.width, npc.height, 1365);
						}
						Item.NewItem(npc.position, npc.width, npc.height, Utils.SelectRandom(Main.rand, NPCDrops.VanillaWoFEmblems));
						Item.NewItem(npc.position, npc.width, npc.height, Utils.SelectRandom(Main.rand, NPCDrops.VanillaWoFWeapons));
						Item.NewItem(npc.position, npc.width, npc.height, ItemID.GoldCoin, Main.rand.Next(6, 10));
					}
					break;
			}
		}
	}

	public class BossBags : GlobalItem
	{
		public override bool PreOpenVanillaBag(string context, Player player, int arg)
		{
			if (context == "bossBag")
			{
				switch (arg)
				{
					case ItemID.WallOfFleshBossBag:
						bool dropEmblemAlchemist = Main.rand.NextBool(1, 5);
						if (dropEmblemAlchemist)
						{
							if (!player.extraAccessory)
							{
								player.QuickSpawnItem(ItemID.DemonHeart);
							}
							if (Main.rand.NextBool(1, 7))
							{
								player.QuickSpawnItem(ItemID.FleshMask);
							}
							player.QuickSpawnItem(Utils.SelectRandom(Main.rand, NPCDrops.VanillaWoFEmblems));
							player.QuickSpawnItem(Utils.SelectRandom(Main.rand, NPCDrops.VanillaWoFWeapons));
							player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(6, 10));
							return false;
						}
						break;
				}
			}
			return true;
		}
	}
}

