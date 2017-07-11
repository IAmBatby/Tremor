using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class RoyalStrike : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 189;
			item.melee = true;
			item.width = 30;
			item.height = 38;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = 1;
			item.knockBack = 7;
			item.shoot = 160;
			item.shootSpeed = 14f;
			item.value = 150000;
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Royal Strike");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Sapphire, 8);
			recipe.AddIngredient(ItemID.GoldBar, 15);
			recipe.AddIngredient(null, "SteelBar", 6);
			recipe.AddIngredient(null, "EvershinyBar", 12);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
