using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NovaPillar.Items.Placeable
{
	public class NovaFragmentBlock : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 22;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.rare = 0;
			item.consumable = true;
			item.createTile = mod.TileType("NovaBlock");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nova Fragment Block");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "NovaFragment", 1);
			recipe.AddIngredient(ItemID.StoneBlock, 5);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this, 5);
			recipe.AddRecipe();
		}
	}
}
