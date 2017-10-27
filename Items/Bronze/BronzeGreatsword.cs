using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Bronze
{
	public class BronzeGreatsword : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 11;
			item.melee = true;
			item.width = 42;
			item.height = 42;
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 660;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bronze Greatsword");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BronzeBar", 15);
			recipe.AddIngredient(ItemID.Wood, 3);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
