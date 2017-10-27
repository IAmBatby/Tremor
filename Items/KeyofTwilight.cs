using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class KeyofTwilight : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 26;
			item.maxStack = 99;
			item.height = 26;

			item.rare = 0;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Key of Jungles");
			Tooltip.SetDefault("'Charged with the essence of jungle grass'");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GoldenKey, 1);
			recipe.AddIngredient(ItemID.SoulofLight, 6);
			recipe.AddIngredient(ItemID.SoulofNight, 6);
			recipe.AddIngredient(ItemID.Vine, 2);
			recipe.AddIngredient(ItemID.Stinger, 1);
			recipe.AddIngredient(ItemID.JungleSpores, 3);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
