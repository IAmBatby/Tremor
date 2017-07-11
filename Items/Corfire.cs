using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Corfire : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(3279);

			item.damage = 56;
			item.width = 30;
			item.height = 26;
			item.shoot = mod.ProjectileType("CorfirePro");
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Corfire");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3290, 1);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.AddIngredient(ItemID.CursedFlame, 18);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
