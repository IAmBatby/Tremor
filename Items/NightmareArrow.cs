using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class NightmareArrow : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 18;
			item.ranged = true;
			item.width = 26;
			item.maxStack = 999;
			item.consumable = true;
			item.height = 30;

			item.shoot = mod.ProjectileType("NightmareArrowPro");
			item.shootSpeed = 22f;
			item.knockBack = 4;
			item.value = 10;
			item.rare = 11;
			item.ammo = AmmoID.Arrow;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nightmare Arrow");
			Tooltip.SetDefault("'Enemies die... from fear.'");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "NightmareBar", 1);
			recipe.AddIngredient(ItemID.WoodenArrow, 150);
			recipe.SetResult(this, 150);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
