using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class GlobalItems : GlobalItem
	{
		public override void OpenVanillaBag(string context, Player player, int arg)
		{
			if (context == "bossBag" && arg == ItemID.DestroyerBossBag && Main.rand.Next(6) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("Destructor"));
			}

			if (context == "bossBag" && arg == ItemID.SkeletronPrimeBossBag && Main.rand.Next(6) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("PrimeBlade"));
			}
			if (context == "bossBag" && arg == ItemID.WallOfFleshBossBag && Main.rand.NextBool())
			{
				player.QuickSpawnItem(mod.ItemType("PieceofFlesh"), Main.rand.Next(8, 17));
			}
			if (context == "bossBag" && arg == ItemID.SkeletronBossBag && Main.rand.NextBool())
			{
				player.QuickSpawnItem(mod.ItemType("CursedSoul"), Main.rand.Next(1, 5));
			}
			if (context == "bossBag" && arg == ItemID.GolemBossBag && Main.rand.NextBool())
			{
				player.QuickSpawnItem(mod.ItemType("GolemCore"));
			}
			if (context == "bossBag" && arg == ItemID.EyeOfCthulhuBossBag && Main.rand.Next(5) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("EyeMonolith"));
			}
			if (context == "bossBag" && arg == ItemID.EyeOfCthulhuBossBag && Main.rand.Next(4) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("MonsterTooth"));
			}

			if (context == "bossBag" && arg == ItemID.PlanteraBossBag && Main.rand.NextBool())
			{
				player.QuickSpawnItem(mod.ItemType("EssenseofJungle"), Main.rand.Next(2, 3));
			}

			if (context == "bossBag" && arg == ItemID.FishronBossBag && Main.rand.Next(6) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("DukeCannon"));
			}

			if (context == "bossBag" && arg == ItemID.MoonLordBossBag && Main.rand.NextBool())
			{
				player.QuickSpawnItem(mod.ItemType("MultidimensionalFragment"), Main.rand.Next(6, 12));
			}

			if (context == "bossBag" && arg == ItemID.SkeletronBossBag && Main.rand.NextBool())
			{
				player.QuickSpawnItem(mod.ItemType("TearsofDeath"), Main.rand.Next(1, 3));
			}

			if (context == "bossBag" && arg == ItemID.QueenBeeBossBag && Main.rand.Next(3) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("YellowPuzzleFragment"));
			}

			if (context == "bossBag" && arg == ItemID.TwinsBossBag && Main.rand.Next(6) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("MechaSprayer"));
			}

			// Dev. Items

			if (Main.hardMode && context == "bossBag" && Main.rand.Next(30) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("Zadum4iviiHelmet"));
				player.QuickSpawnItem(mod.ItemType("Zadum4iviiCuirass"));
				player.QuickSpawnItem(mod.ItemType("Zadum4iviiLeggings"));
			}

			if (Main.hardMode && context == "bossBag" && Main.rand.Next(30) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("HummerHelmet"));
				player.QuickSpawnItem(mod.ItemType("HummerBreastplate"));
				player.QuickSpawnItem(mod.ItemType("HummerGreaves"));
			}

			if (Main.hardMode && context == "bossBag" && Main.rand.Next(30) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("ZerokkHead"));
				player.QuickSpawnItem(mod.ItemType("ZerokkBody"));
				player.QuickSpawnItem(mod.ItemType("ZerokkLegs"));
			}

			if (Main.hardMode && context == "bossBag" && Main.rand.Next(30) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("CursedKnightHelmet"));
				player.QuickSpawnItem(mod.ItemType("CursedKnightBreastplate"));
				player.QuickSpawnItem(mod.ItemType("CursedKnightGreaves"));
			}

			if (Main.hardMode && context == "bossBag" && Main.rand.Next(42) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("SpinalMask"));
			}
		}
	}
}
