using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class M29 : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 313;
			item.ranged = true;
			item.width = 98;
			item.height = 28;
			item.useTime = 60;
			item.useAmmo = AmmoID.Bullet;
			item.useAnimation = 60;
			item.shoot = 242;
			item.shootSpeed = 15f;
			item.useStyle = 5;
			item.knockBack = 10;
			item.value = 96300;
			item.rare = 10;
			item.UseSound = SoundID.Item40;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("M-29");
			Tooltip.SetDefault("");
		}


		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = 242;
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-25, 0);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "EyeofOblivion", 1);
			recipe.AddIngredient(ItemID.ShroomiteBar, 15);
			recipe.AddIngredient(null, "CarbonSteel", 15);
			recipe.AddIngredient(null, "Doomstone", 6);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
