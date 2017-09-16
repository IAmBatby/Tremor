using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class TungstenBullet : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 10;
			item.ranged = true;
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 3;
			item.value = 3;
			item.rare = 1;
			item.shoot = 14;
			item.shootSpeed = 4f;
			item.shoot = 14;
			item.ammo = AmmoID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tungsten Bullet");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MusketBall, 70);
			recipe.AddIngredient(ItemID.TungstenBar, 1);
			recipe.SetResult(this, 70);
			recipe.AddRecipe();
		}
	}
}
