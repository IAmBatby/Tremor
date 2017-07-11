using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class FungusBroadsword : ModItem
	{
		public override void SetDefaults()
		{
			item.rare = 3;
			item.UseSound = SoundID.Item1;

			item.useStyle = 1;
			item.damage = 26;
			item.useAnimation = 19;
			item.useTime = 19;
			item.width = 84;
			item.height = 84;
			item.shoot = 131;
			item.shootSpeed = 15f;
			item.knockBack = 3f;
			item.melee = true;
			item.value = Item.sellPrice(0, 0, 5, 0);
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fungus Broadsword");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "FungusElement", 12);
			recipe.AddIngredient(ItemID.GlowingMushroom, 9);
			recipe.AddIngredient(ItemID.GoldBroadsword, 1);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "FungusElement", 12);
			recipe.AddIngredient(ItemID.GlowingMushroom, 9);
			recipe.AddIngredient(ItemID.PlatinumBroadsword, 1);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
