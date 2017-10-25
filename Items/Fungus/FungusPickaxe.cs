using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Fungus
{
	public class FungusPickaxe : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 10;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 15;
			item.useAnimation = 20;
			item.pick = 85;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 1000;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fungus Pickaxe");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "FungusElement", 13);
			recipe.AddIngredient(ItemID.GlowingMushroom, 10);
			recipe.AddIngredient(ItemID.GoldPickaxe, 1);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "FungusElement", 13);
			recipe.AddIngredient(ItemID.GlowingMushroom, 10);
			recipe.AddIngredient(ItemID.PlatinumPickaxe, 1);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
