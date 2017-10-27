using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class GuardianBreastplate : ModItem
	{

		public override void SetDefaults()
		{

			item.defense = 60;
			item.width = 22;
			item.height = 30;
			item.value = 25000;
			item.rare = 10;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Guardian Breastplate");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AncientArmorPlate", 20);
			recipe.AddIngredient(null, "Squorb", 1);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
