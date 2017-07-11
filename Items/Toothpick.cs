using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{

	public class Toothpick : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 8;
			item.melee = true;
			item.width = 20;
			item.height = 12;
			item.useTime = 15;
			item.useAnimation = 25;
			item.channel = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.pick = 65;
			item.tileBoost++;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = Item.buyPrice(0, 1, 50, 0);
			item.rare = 3;
			item.UseSound = SoundID.Item23;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("ToothpickPro");
			item.shootSpeed = 26f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Toothpick");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrimtaneBar, 10);
			recipe.AddIngredient(null, "SharpenedTooth", 5);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DemoniteBar, 10);
			recipe.AddIngredient(null, "SharpenedTooth", 5);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
