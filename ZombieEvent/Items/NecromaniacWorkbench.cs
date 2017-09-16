using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Items
{
	public class NecromaniacWorkbench : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 48;
			item.height = 32;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 1;
                        item.rare = 1;
			item.consumable = true;
			item.value = 200;
			item.createTile = mod.TileType("NecromaniacWorkbenchTile");
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Necromaniac Workbench");
      Tooltip.SetDefault("");
    }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null, "FleshWorkstation", 1);
        recipe.AddIngredient(null, "RupicideBar", 5);
        recipe.AddIngredient(null, "WickedHeart", 1);
        recipe.AddIngredient(null, "BookofRevelations", 1);
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
	}
}
