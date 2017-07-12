using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Tremor.Items;
using Tremor.NovaPillar;
using Tremor.Tiles;
using MineralTransmutator = Tremor.Items.MineralTransmutator;

namespace Tremor
{
	// A recipe to be deleted
	sealed class DeletionRecipe
	{
		private DeletionItem Result { get; set; }
		private List<DeletionItem> Ingredients { get; set; }
		private List<short> RequiredTiles { get; set; }

		public DeletionRecipe(DeletionItem result, params DeletionItem[] ingredients)
		{
			Result = result;
			Ingredients = ingredients.ToList();
			RequiredTiles = new List<short>();
		}

		public void SetTiles(params short[] tiles)
		{
			RequiredTiles = tiles.ToList();
		}

		public bool AddTile(short type)
		{
			if (!RequiredTiles.Contains(type))
			{
				RequiredTiles.Add(type);
				return true;
			}
			return false;
		}

		public bool Delete(bool exact = true)
		{
			return SatisfiesConditions() && RecipeDeleter.AttemptDelete(this, exact);
		}

		private bool SatisfiesConditions()
			=> Result.IsValid
			&& Ingredients.TrueForAll(i => i.IsValid);

		public sealed class DeletionItem
		{
			public short Type { get; set; }
			public int Stack { get; set; } = 1;

			public bool IsValid
				=> Type >= 0
				   && Type <= ItemID.Count
				   && Stack >= 1;
		}

		// Handles the actual deletion of a DeletionRecipe
		public static class RecipeDeleter
		{
			private static RecipeFinder Finder { get; set; }
			private static RecipeEditor Editor { get; set; }

			public static bool AttemptDelete(DeletionRecipe recipe, bool exact)
			{
				Finder = new RecipeFinder();
				Finder.SetResult(recipe.Result.Type, recipe.Result.Stack);
				foreach (DeletionItem ingredient in recipe.Ingredients)
				{
					Finder.AddIngredient(ingredient.Type, ingredient.Stack);
				}
				foreach (short tile in recipe.RequiredTiles)
				{
					Finder.AddTile(tile);
				}
				return exact
					? DeleteExact()
					: DeleteAlike();
			}

			public static bool DeleteExact()
			{
				Recipe foundRecipe = Finder.FindExactRecipe();
				if (foundRecipe != null)
				{
					Editor = new RecipeEditor(foundRecipe);
					Editor.DeleteRecipe();
					return true;
				}
				return false;
			}

			public static bool DeleteAlike()
			{
				List<Recipe> recipes = Finder.SearchRecipes();
				foreach (Recipe recipe in recipes)
				{
					Editor = new RecipeEditor(recipe);
					Editor.DeleteRecipe();
				}
				return recipes.Count > 0;
			}
		}
	}

	// Holds recipe data
	static class RecipeData
	{
		public static DeletionRecipe[] DeletionRecipes =
		{
			new DeletionRecipe(new DeletionRecipe.DeletionItem { Type = ItemID.NightsEdge }, new DeletionRecipe.DeletionItem { Type = ItemID.BloodButcherer }),
			new DeletionRecipe(new DeletionRecipe.DeletionItem { Type = ItemID.MechanicalWorm }, new DeletionRecipe.DeletionItem { Type = ItemID.Vertebrae }),
			new DeletionRecipe(new DeletionRecipe.DeletionItem { Type = ItemID.SuperHealingPotion }),
			new DeletionRecipe(new DeletionRecipe.DeletionItem { Type = ItemID.CelestialSigil }),
			new DeletionRecipe(new DeletionRecipe.DeletionItem { Type = ItemID.FragmentVortex }),
			new DeletionRecipe(new DeletionRecipe.DeletionItem { Type = ItemID.FragmentNebula }),
			new DeletionRecipe(new DeletionRecipe.DeletionItem { Type = ItemID.FragmentSolar }),
			new DeletionRecipe(new DeletionRecipe.DeletionItem { Type = ItemID.FragmentStardust }),
		};
	}

	// Our recipe wrapper
	public sealed class RecipeWrapper
	{
		public static void AddRecipes(Tremor mod)
		{
			// TODO: Further improve these recipes, more OO fashion and better handling like DeletionRecipe and data collection
			#region AddRecipes
			// Pillars Recipes
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3456);
			recipe.AddIngredient(3457);
			recipe.AddIngredient(3458);
			recipe.AddIngredient(3459);
			recipe.AddIngredient(mod.ItemType<NovaFragment>());
			recipe.SetResult(3544, 4);
			recipe.AddTile(13);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(3456, 20);
			recipe.AddIngredient(3457, 20);
			recipe.AddIngredient(3458, 20);
			recipe.AddIngredient(3459, 20);
			recipe.AddIngredient(mod.ItemType<NovaFragment>(), 20);
			recipe.SetResult(3601);
			recipe.AddTile(412);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(3457);
			recipe.AddIngredient(3458);
			recipe.AddIngredient(3459);
			recipe.AddIngredient(mod.ItemType<NovaFragment>());
			recipe.SetResult(3456);
			recipe.AddTile(412);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(3456);
			recipe.AddIngredient(3458);
			recipe.AddIngredient(3459);
			recipe.AddIngredient(mod.ItemType<NovaFragment>());
			recipe.SetResult(3457);
			recipe.AddTile(412);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(3456);
			recipe.AddIngredient(3457);
			recipe.AddIngredient(3459);
			recipe.AddIngredient(mod.ItemType<NovaFragment>());
			recipe.SetResult(3458);
			recipe.AddTile(412);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(3457);
			recipe.AddIngredient(3458);
			recipe.AddIngredient(3456);
			recipe.AddIngredient(mod.ItemType<NovaFragment>());
			recipe.SetResult(3459);
			recipe.AddTile(412);
			recipe.AddRecipe();

			//////////////////////////
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SilverBar, 15);
			recipe.AddIngredient(ItemID.Glass, 5);
			recipe.AddIngredient(ItemID.ManaCrystal, 2);
			recipe.SetResult(ItemID.MagicMirror);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 8);
			recipe.AddIngredient(ItemID.GoldBar, 2);
			recipe.SetResult(ItemID.GoldChest);
			recipe.AddTile(18);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 8);
			recipe.AddIngredient(ItemID.PlatinumBar, 2);
			recipe.SetResult(ItemID.GoldChest);
			recipe.AddTile(18);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<Band>());
			recipe.AddIngredient(ItemID.ManaCrystal, 2);
			recipe.SetResult(111);
			recipe.AddTile(16);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<Band>());
			recipe.AddIngredient(ItemID.LifeCrystal, 2);
			recipe.SetResult(49);
			recipe.AddTile(16);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TinBar, 5);
			recipe.AddIngredient(ItemID.Wood);
			recipe.SetResult(ItemID.Aglet);
			recipe.AddTile(16);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CopperBar, 5);
			recipe.AddIngredient(ItemID.Wood);
			recipe.SetResult(ItemID.Aglet);
			recipe.AddTile(16);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 10);
			recipe.AddIngredient(ItemID.Gel, 25);
			recipe.SetResult(ItemID.SlimeStaff);
			recipe.AddTile(304);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CopperOre, 3);
			recipe.SetResult(ItemID.TinOre, 2);
			recipe.AddTile(mod.TileType<Tiles.MineralTransmutator>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TinOre, 3);
			recipe.SetResult(ItemID.CopperOre, 2);
			recipe.AddTile(mod.TileType<Tiles.MineralTransmutator>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronOre, 3);
			recipe.SetResult(ItemID.LeadOre, 2);
			recipe.AddTile(mod.TileType<Tiles.MineralTransmutator>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LeadOre, 3);
			recipe.SetResult(ItemID.IronOre, 2);
			recipe.AddTile(mod.TileType<Tiles.MineralTransmutator>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SilverOre, 3);
			recipe.SetResult(ItemID.TungstenOre, 2);
			recipe.AddTile(mod.TileType<Tiles.MineralTransmutator>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TungstenOre, 3);
			recipe.SetResult(ItemID.SilverOre, 2);
			recipe.AddTile(mod.TileType<Tiles.MineralTransmutator>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GoldOre, 3);
			recipe.SetResult(ItemID.PlatinumOre, 2);
			recipe.AddTile(mod.TileType<Tiles.MineralTransmutator>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PlatinumOre, 3);
			recipe.SetResult(ItemID.GoldOre, 2);
			recipe.AddTile(mod.TileType<Tiles.MineralTransmutator>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DemoniteOre, 5);
			recipe.SetResult(ItemID.CrimtaneOre, 3);
			recipe.AddTile(mod.TileType<Tiles.MineralTransmutator>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrimtaneOre, 5);
			recipe.SetResult(ItemID.DemoniteOre, 3);
			recipe.AddTile(mod.TileType<Tiles.MineralTransmutator>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<TrueBloodCarnage>());
			recipe.AddIngredient(674);
			recipe.AddTile(134);
			recipe.SetResult(757);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<SoulofMind>(), 20);
			recipe.AddIngredient(ItemID.SharkFin, 5);
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddIngredient(ItemID.Minishark);
			recipe.SetResult(533);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 4);
			recipe.AddIngredient(ItemID.SoulofLight, 3);
			recipe.AddIngredient(mod.ItemType<SoulofMind>(), 5);
			recipe.SetResult(561);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 18);
			recipe.AddIngredient(ItemID.SoulofFright);
			recipe.AddIngredient(mod.ItemType<SoulofMind>());
			recipe.AddIngredient(ItemID.SoulofSight);
			recipe.SetResult(579);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 18);
			recipe.AddIngredient(ItemID.SoulofFright);
			recipe.AddIngredient(mod.ItemType<SoulofMind>());
			recipe.AddIngredient(ItemID.SoulofSight);
			recipe.SetResult(990);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WarriorEmblem);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddIngredient(mod.ItemType<SoulofMind>(), 5);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.SetResult(935);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SummonerEmblem);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddIngredient(mod.ItemType<SoulofMind>(), 5);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.SetResult(935);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.RangerEmblem);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddIngredient(mod.ItemType<SoulofMind>(), 5);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.SetResult(935);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SorcererEmblem);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddIngredient(mod.ItemType<SoulofMind>(), 5);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.SetResult(935);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<SharpenedTooth>(), 5);
			recipe.AddIngredient(ItemID.TissueSample, 5);
			recipe.AddIngredient(ItemID.Chain, 2);
			recipe.SetResult(3212);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<SharpenedTooth>(), 5);
			recipe.AddIngredient(ItemID.ShadowScale, 5);
			recipe.AddIngredient(ItemID.Chain, 2);
			recipe.SetResult(3212);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<Items.SandstonePlatform>(), 2);
			recipe.SetResult(607);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PalladiumOre, 3);
			recipe.SetResult(ItemID.CobaltOre, 2);
			recipe.AddTile(mod.TileType<RecyclerofMatterTile>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CobaltOre, 3);
			recipe.SetResult(ItemID.PalladiumOre, 2);
			recipe.AddTile(mod.TileType<RecyclerofMatterTile>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MythrilOre, 3);
			recipe.SetResult(ItemID.OrichalcumOre, 2);
			recipe.AddTile(mod.TileType<RecyclerofMatterTile>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.OrichalcumOre, 3);
			recipe.SetResult(ItemID.MythrilOre, 2);
			recipe.AddTile(mod.TileType<RecyclerofMatterTile>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TitaniumOre, 3);
			recipe.SetResult(ItemID.AdamantiteOre, 2);
			recipe.AddTile(mod.TileType<RecyclerofMatterTile>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AdamantiteOre, 3);
			recipe.SetResult(ItemID.TitaniumOre, 2);
			recipe.AddTile(mod.TileType<RecyclerofMatterTile>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TurtleShell);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 15);
			recipe.AddIngredient(ItemID.JungleSpores, 20);
			recipe.AddIngredient(ItemID.Stinger, 18);
			recipe.AddIngredient(mod.ItemType<KeyMold>());
			recipe.SetResult(ItemID.JungleKey);
			recipe.AddTile(mod.TileType<MagicWorkbenchTile>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DemoniteBar, 25);
			recipe.AddIngredient(ItemID.ShadowScale, 25);
			recipe.AddIngredient(ItemID.EbonstoneBlock, 25);
			recipe.AddIngredient(ItemID.VilePowder, 25);
			recipe.AddIngredient(mod.ItemType<KeyMold>());
			recipe.SetResult(ItemID.CorruptionKey);
			recipe.AddTile(mod.TileType<MagicWorkbenchTile>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrimtaneBar, 25);
			recipe.AddIngredient(ItemID.TissueSample, 25);
			recipe.AddIngredient(ItemID.CrimstoneBlock, 25);
			recipe.AddIngredient(ItemID.ViciousPowder, 25);
			recipe.AddIngredient(mod.ItemType<KeyMold>());
			recipe.SetResult(ItemID.CrimsonKey);
			recipe.AddTile(mod.TileType<MagicWorkbenchTile>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 15);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddIngredient(ItemID.PurificationPowder, 25);
			recipe.AddIngredient(mod.ItemType<KeyMold>());
			recipe.SetResult(ItemID.HallowedKey);
			recipe.AddTile(mod.TileType<MagicWorkbenchTile>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FrostCore, 2);
			recipe.AddIngredient(ItemID.SnowBlock, 30);
			recipe.AddIngredient(ItemID.IceBlock, 30);
			recipe.AddIngredient(mod.ItemType<KeyMold>());
			recipe.SetResult(ItemID.FrozenKey);
			recipe.AddTile(mod.TileType<MagicWorkbenchTile>());
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bone, 80);
			recipe.SetResult(1320);
			recipe.AddTile(300);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 10);
			recipe.AddIngredient(ItemID.Torch, 5);
			recipe.SetResult(3069);
			recipe.AddTile(16);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CobaltBar, 12);
			recipe.AddIngredient(ItemID.SnowBlock, 25);
			recipe.AddIngredient(ItemID.IceBlock, 25);
			recipe.AddIngredient(ItemID.SoulofLight, 6);
			recipe.AddIngredient(ItemID.SoulofNight, 6);
			recipe.AddIngredient(ItemID.Glass, 15);
			recipe.SetResult(602);
			recipe.AddTile(26);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PalladiumBar, 12);
			recipe.AddIngredient(ItemID.SnowBlock, 25);
			recipe.AddIngredient(ItemID.IceBlock, 25);
			recipe.AddIngredient(ItemID.SoulofLight, 6);
			recipe.AddIngredient(ItemID.SoulofNight, 6);
			recipe.AddIngredient(ItemID.Glass, 15);
			recipe.SetResult(602);
			recipe.AddTile(26);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 30);
			recipe.SetResult(2196);
			recipe.AddTile(191);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(2766);
			recipe.SetResult(1261, 75);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(2766);
			recipe.SetResult(1261, 75);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(2766, 15);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 3);
			recipe.AddIngredient(mod.ItemType<EssenseofJungle>());
			recipe.SetResult(1293);
			recipe.AddTile(134);
			recipe.AddRecipe();
			#endregion
		}

		public static void RemoveRecipes()
		{
			foreach (DeletionRecipe recipe in RecipeData.DeletionRecipes)
			{
				recipe.Delete();
			}
		}
	}
}
