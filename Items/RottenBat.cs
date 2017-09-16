using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class RottenBat : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 16;
			item.melee = true;
			item.width = 48;
			item.height = 48;
			item.useTime = 30;

			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 9;
			item.value = 100;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rotten Bat");
			Tooltip.SetDefault("'Sewn from pieces of flesh'");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "UntreatedFlesh", 9);
			recipe.SetResult(this);
			recipe.AddTile(null, "FleshWorkstationTile");
			recipe.AddRecipe();
		}
	}
}
