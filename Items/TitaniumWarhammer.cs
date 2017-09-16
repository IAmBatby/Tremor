using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class TitaniumWarhammer : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 50;
			item.melee = true;
			item.width = 44;
			item.height = 44;
			item.useTime = 35;
			item.useAnimation = 35;
			item.hammer = 86;
			item.useStyle = 1;
			item.knockBack = 7;
			item.value = 32200;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Titanium Warhammer");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TitaniumBar, 13);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
