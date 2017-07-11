using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class FungusSpear : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 23;
			item.width = 54;
			item.height = 54;
			item.noUseGraphic = true;
			item.melee = true;
			item.useTime = 30;
			item.shoot = mod.ProjectileType("FungusSpear");
			item.shootSpeed = 3f;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 1000;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fungus Spear");
			Tooltip.SetDefault("Has a chance to inflict confusion on enemies");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "FungusElement", 11);
			recipe.AddIngredient(ItemID.GlowingMushroom, 10);
			recipe.AddIngredient(null, "GoldSpear", 1);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "FungusElement", 11);
			recipe.AddIngredient(ItemID.GlowingMushroom, 10);
			recipe.AddIngredient(null, "PlatinumSpear", 1);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
