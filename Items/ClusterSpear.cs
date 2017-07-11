using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ClusterSpear : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 295;
			item.width = 70;
			item.height = 70;
			item.noUseGraphic = true;
			item.melee = true;
			item.useTime = 16;
			item.shoot = mod.ProjectileType("ClusterSpearPro");
			item.shootSpeed = 5f;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.knockBack = 4;
			item.value = 512500;
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cluster Spear");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "EyeofOblivion", 1);
			recipe.AddIngredient(null, "CarbonSteel", 12);
			recipe.AddIngredient(null, "ToothofAbraxas", 15);
			recipe.AddIngredient(null, "ClusterShard", 25);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
