using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Fungus
{
	public class FungusHamaxe : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 16;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 22;
			item.useAnimation = 18;
			item.axe = 13;
			item.hammer = 75;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 1000;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fungus Hamaxe");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "FungusElement", 11);
			recipe.AddIngredient(ItemID.GlowingMushroom, 8);
			recipe.AddIngredient(ItemID.GoldAxe, 1);
			recipe.AddIngredient(ItemID.GoldHammer, 1);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "FungusElement", 11);
			recipe.AddIngredient(ItemID.GlowingMushroom, 8);
			recipe.AddIngredient(ItemID.PlatinumAxe, 1);
			recipe.AddIngredient(ItemID.PlatinumHammer, 1);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
