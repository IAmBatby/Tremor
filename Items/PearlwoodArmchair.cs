using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class PearlwoodArmchair : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 42;
			item.height = 32;
			item.maxStack = 99;
			item.value = 100;
			item.rare = 1;
			item.createTile = mod.TileType("PearlwoodArmchair");
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pearlwood Armchair");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Pearlwood, 15);
			recipe.AddIngredient(ItemID.Silk, 6);
			recipe.SetResult(this);
			recipe.AddTile(106);
			recipe.AddRecipe();
		}
	}
}
