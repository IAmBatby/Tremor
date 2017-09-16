using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class SteelBroadsword : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 12;
			item.melee = true;
			item.width = 42;
			item.height = 42;
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 660;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Steel Broadsword");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SteelBar", 10);
			recipe.AddIngredient(ItemID.Wood, 4);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
