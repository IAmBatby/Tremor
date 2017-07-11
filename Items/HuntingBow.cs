using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class HuntingBow : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 16;
			item.width = 18;
			item.noMelee = true;
			item.height = 56;
			item.ranged = true;
			item.useTime = 30;
			item.shoot = 1;
			item.shootSpeed = 12f;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.knockBack = 5;
			item.value = 2500;
			item.useAmmo = AmmoID.Arrow;
			item.rare = 1;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hunting Bow");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "WolfPelt", 12);
			recipe.AddIngredient(ItemID.BorealWood, 30);
			recipe.AddIngredient(null, "AlphaClaw", 1);
			recipe.AddTile(18);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
