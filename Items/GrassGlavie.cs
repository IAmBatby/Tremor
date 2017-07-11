using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class GrassGlavie : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 19;
			item.width = 14;
			item.height = 84;
			item.noUseGraphic = true;
			item.melee = true;
			item.useTime = 30;
			item.shoot = mod.ProjectileType("GrassGlaviePro");
			item.shootSpeed = 3f;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.knockBack = 4;
			item.value = 900;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Grass Glaive");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.RichMahogany, 16);
			recipe.AddIngredient(ItemID.Stinger, 1);
			recipe.AddIngredient(ItemID.Vine, 1);
			recipe.AddIngredient(ItemID.JungleSpores, 5);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
