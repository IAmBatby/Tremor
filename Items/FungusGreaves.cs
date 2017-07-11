using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class FungusGreaves : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;
			item.value = 40000;

			item.rare = 3;
			item.defense = 7;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fungus Greaves");
			Tooltip.SetDefault("");
		}


		public override void UpdateEquip(Player player)
		{
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "FungusElement", 14);
			recipe.AddIngredient(ItemID.GlowingMushroom, 12);
			recipe.AddIngredient(ItemID.GoldGreaves, 1);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "FungusElement", 14);
			recipe.AddIngredient(ItemID.GlowingMushroom, 12);
			recipe.AddIngredient(ItemID.PlatinumGreaves, 1);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
