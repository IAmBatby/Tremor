using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class PurplePuzzleFragment : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 24;
			item.maxStack = 99;
			item.value = 10000;
			item.rare = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Purple Puzzle Fragment");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "PhantomSoul", 4);
			recipe.AddIngredient(ItemID.Amethyst, 8);
			recipe.AddIngredient(ItemID.SoulofNight, 2);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}

	}
}
