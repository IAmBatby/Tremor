using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Basilisk : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 68;
			item.melee = true;
			item.width = 48;
			item.height = 48;
			item.useTime = 35;
			item.useAnimation = 35;
			item.useStyle = 1;
			item.knockBack = 7;
			item.value = 32740;
			item.rare = 6;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = 606;
			item.shootSpeed = 30f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Basilisk");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SkullTeeth", 5);
			recipe.AddIngredient(null, "SteelBar", 10);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}

	}
}
