using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class NightmareBreastplate : ModItem
	{

		public override void SetDefaults()
		{

			item.defense = 35;
			item.width = 22;
			item.height = 30;
			item.value = 25000;
			item.rare = 10;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nightmare Breastplate");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "NightmareBar", 25);
			recipe.AddIngredient(null, "Phantaplasm", 10);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
