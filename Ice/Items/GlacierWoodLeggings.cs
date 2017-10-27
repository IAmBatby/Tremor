using Terraria.ModLoader;

namespace Tremor.Ice.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class GlacierWoodLeggings : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 18;
			item.value = 500;
			item.rare = 1;
			item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glacier Wood Leggings");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GlacierWood", 25);
			recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.AddRecipe();
		}
	}
}
