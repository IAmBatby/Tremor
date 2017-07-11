using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class DragonRafale : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 236;
			item.ranged = true;
			item.width = 50;
			item.maxStack = 1;
			item.height = 30;
			item.useTime = 10;
			item.useAnimation = 15;
			//item.shoot = mod.ProjectileType("DragonLaser");
			item.shoot = 20;

			item.useAmmo = AmmoID.Bullet;
			item.shootSpeed = 15f;
			item.useStyle = 5;
			item.knockBack = 4;
			item.value = 31000; ;
			item.rare = 11;
			item.UseSound = SoundID.Item11;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dragon Rafale");
			Tooltip.SetDefault("Two round burst");
		}


		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, -4);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = 20;
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DragonCapsule", 9);
			recipe.AddIngredient(null, "EarthFragment", 14);
			recipe.AddIngredient(ItemID.IllegalGunParts, 1);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
