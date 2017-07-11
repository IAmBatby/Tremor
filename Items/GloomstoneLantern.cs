using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class GloomstoneLantern : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 16;
			item.height = 32;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 1;
			item.rare = 1;
			item.consumable = true;
			item.value = 2000;
			item.createTile = mod.TileType("GloomstoneLantern");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gloomstone Lantern");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Gloomstone", 6);
			recipe.AddIngredient(ItemID.Torch, 1);
			recipe.SetResult(this);
			recipe.AddTile(17);
			recipe.AddRecipe();
		}
	}
}
