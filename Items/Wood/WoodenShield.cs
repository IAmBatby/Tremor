using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Wood
{
	[AutoloadEquip(EquipType.Shield)]
	public class WoodenShield : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 24;
			item.value = 110;
			item.rare = 0;
			item.accessory = true;
			item.defense = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wooden Shield");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 15);
			recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.AddRecipe();
		}
	}
}
