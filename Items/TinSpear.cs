using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class TinSpear : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 10;
			item.width = 14;
			item.height = 84;
			item.noUseGraphic = true;
			item.melee = true;
			item.useTime = 30;
			item.shoot = mod.ProjectileType("TinSpearPro");
			item.shootSpeed = 3f;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.knockBack = 4;
			item.value = 1000;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tin Spear");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TinBar, 9);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
