using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class DrippingKnife : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 25;
			item.thrown = true;
			item.width = 26;
			item.noUseGraphic = true;
			item.maxStack = 999;
			item.consumable = true;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.shoot = mod.ProjectileType("DrippingKnifePro");
			item.shootSpeed = 25f;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 7;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dripping Knife");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AtisBlood", 1);
			recipe.AddIngredient(null, "DrippingRoot", 1);
			recipe.SetResult(this, 75);
			recipe.AddTile(14);
			recipe.AddRecipe();
		}
	}
}
