using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Coral
{
	[AutoloadEquip(EquipType.Legs)]
	public class CoralGreaves : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 18;
			item.value = 180;
			item.rare = 1;
			item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Coral Greaves");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Coral, 10);
			recipe.AddIngredient(ItemID.Starfish, 6);
			recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.AddRecipe();
		}

	}
}
