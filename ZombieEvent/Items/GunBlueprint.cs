using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Items
{
	public class GunBlueprint : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 24;
			item.maxStack = 999;
			item.value = 10000;
			item.rare = 6;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gun Blueprint");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "TornPapyrus", 1);
			recipe.AddIngredient(null, "TearsofDeath", 1);
			recipe.AddIngredient(null, "CursedInk", 1);
			recipe.AddTile(null, "NecromaniacWorkbenchTile");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
