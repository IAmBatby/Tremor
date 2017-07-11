using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ArgiteTome : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 18;
			item.melee = false;
			item.magic = true;
			item.width = 50;
			item.height = 55;
			item.useTime = 30;
			item.mana = 8;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.shoot = mod.ProjectileType("ArgiteSpherePro");
			item.shootSpeed = 12f;
			item.knockBack = 4;
			item.value = 32000;
			item.rare = 3;
			item.UseSound = SoundID.Item9;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Argite Tome");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Book, 1);
			recipe.AddIngredient(null, "ArgiteBar", 20);
			recipe.SetResult(this);
			recipe.AddTile(null, "MagicWorkbenchTile");
			recipe.AddRecipe();
		}
	}
}
