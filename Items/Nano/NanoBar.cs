using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Nano
{
	public class NanoBar : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 28;
			item.height = 30;

			item.maxStack = 99;
			item.value = 10000;
			item.rare = 6;
			item.createTile = mod.TileType("NanoBar");
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nano Bar");
			Tooltip.SetDefault("Pulsing with pure energy");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TitaniumBar, 1);
			recipe.AddIngredient(ItemID.SoulofNight, 1);
			recipe.AddIngredient(ItemID.SoulofLight, 1);
			recipe.AddIngredient(ItemID.Nanites, 1);
			recipe.SetResult(this, 2);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AdamantiteBar, 1);
			recipe.AddIngredient(ItemID.SoulofNight, 1);
			recipe.AddIngredient(ItemID.SoulofLight, 1);
			recipe.AddIngredient(ItemID.Nanites, 1);
			recipe.SetResult(this, 2);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}

	}
}
