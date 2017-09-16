using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class PalladiumWarhammer : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 41;
			item.melee = true;
			item.width = 38;
			item.height = 38;
			item.useTime = 39;
			item.useAnimation = 39;
			item.hammer = 80;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 15300;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Palladium Warhammer");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PalladiumBar, 10);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
