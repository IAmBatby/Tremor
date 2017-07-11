using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class AlphaKnife : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 12;
			item.thrown = true;
			item.width = 26;
			item.noUseGraphic = true;
			item.maxStack = 999;
			item.consumable = true;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.shoot = mod.ProjectileType("AlphaKnifePro");
			item.shootSpeed = 22f;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 7;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alpha Knife");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AlphaClaw", 1);
			recipe.SetResult(this, 75);
			recipe.AddTile(14);
			recipe.AddRecipe();
		}
	}
}
