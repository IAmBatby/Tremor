using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
		public static void AddRecipes()
		{
			// TODO: Migrate ModRecipes to RecipeWrapper
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
