using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class SpectralBlade : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 92;
			item.melee = true;
			item.width = 42;
			item.height = 46;
			item.useTime = 20;
			item.useAnimation = 20;
			item.shoot = 297;
			item.shootSpeed = 15f;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 46000;
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spectral Blade");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SpectreBar, 18);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
