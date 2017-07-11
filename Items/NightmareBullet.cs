using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class NightmareBullet : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 20;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;

			item.consumable = true;
			item.knockBack = 1.5f;
			item.value = 10;
			item.rare = 11;
			item.shoot = mod.ProjectileType("NightmareBulletPro");
			item.shootSpeed = 10f;
			item.ammo = AmmoID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nightmare Bullet");
			Tooltip.SetDefault("'Can bounce off blocks.'");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.EmptyBullet, 50);
			recipe.AddIngredient(null, "NightmareBar", 1);
			recipe.AddTile(412);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}
