using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class StarSmithy : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 46;
			item.height = 46;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 150;
			item.createTile = mod.TileType("StarvilTile");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Starvil");
			Tooltip.SetDefault("Allows you to treat space materials");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MeteoriteBar, 15);
			recipe.AddIngredient(ItemID.GoldBar, 15);
			recipe.AddIngredient(null, "VoidBar", 15);
			recipe.AddIngredient(null, "Squorb", 3);
			recipe.AddIngredient(ItemID.FallenStar, 5);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MeteoriteBar, 15);
			recipe.AddIngredient(ItemID.PlatinumBar, 15);
			recipe.AddIngredient(null, "VoidBar", 15);
			recipe.AddIngredient(null, "Squorb", 3);
			recipe.AddIngredient(ItemID.FallenStar, 5);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
