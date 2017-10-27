using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class RavenClutches : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 29;
			item.melee = true;
			item.width = 28;
			item.height = 18;
			item.useTime = 9;
			item.useAnimation = 9;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 6400;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Raven Clutches");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SilverBar, 10);
			recipe.AddIngredient(null, "Opal", 1);
			recipe.AddIngredient(null, "RavenFeather", 13);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TungstenBar, 10);
			recipe.AddIngredient(null, "Opal", 1);
			recipe.AddIngredient(null, "RavenFeather", 13);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
