using Terraria.ModLoader;

namespace Tremor.Items
{
	public class GloomstoneBrickWall : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 7;
			item.useStyle = 1;
			item.rare = 3;
			item.consumable = true;
			item.createWall = mod.WallType("GloomstoneBrickWall");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gloomstone Brick Wall");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GloomstoneBrick", 1);
			recipe.SetResult(this, 4);
			recipe.AddTile(17);
			recipe.AddRecipe();
		}
	}
}
