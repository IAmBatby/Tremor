using Terraria.ID;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tremor.Items
{
	public class SpineBlade : ModItem
	{
		public override void SetDefaults()
		{

			item.useStyle = 1;
			item.useAnimation = 28;
			item.useTime = 28;
			item.knockBack = 5.75f;
			item.width = 40;
			item.height = 40;
			item.damage = 165;
			item.scale = 1.125f;
			item.shootSpeed = 15f;
			item.shoot = 524;
			item.UseSound = SoundID.Item1;
			item.rare = 9;
			item.autoReuse = true;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.melee = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spine Blade");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bladetongue, 1);
			recipe.AddIngredient(null, "NightmareBar", 15);
			recipe.AddIngredient(ItemID.CrimtaneBar, 25);
			recipe.AddIngredient(null, "Doomstone", 6);
			recipe.AddIngredient(null, "Phantaplasm", 10);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
