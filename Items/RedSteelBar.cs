using Terraria.ModLoader;

namespace Tremor.Items
{
	public class RedSteelBar : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 24;
			item.maxStack = 99;
			item.value = 300;
			item.rare = 1;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.createTile = mod.TileType("RedSteelBar");
			item.useStyle = 1;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red Steel Bar");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ChippyRedSteelSword");
			recipe.SetResult(this, 2);
			recipe.AddTile(17);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "FaultyRedSteelShield");
			recipe.SetResult(this, 3);
			recipe.AddTile(17);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RedSteelArmorPiece");
			recipe.SetResult(this, 2);
			recipe.AddTile(17);
			recipe.AddRecipe();
		}
	}
}
