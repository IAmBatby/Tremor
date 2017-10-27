using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class CrimtaneScythe : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 19;
			item.melee = true;
			item.width = 50;
			item.height = 40;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 1;
			item.knockBack = 7;
			item.value = 2700;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crimtane Scythe");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrimtaneBar, 8);
			recipe.AddIngredient(ItemID.TissueSample, 8);
			recipe.AddIngredient(ItemID.Wood, 25);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}

	}
}
