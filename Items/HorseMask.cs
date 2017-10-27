using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class HorseMask : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 24;
			item.rare = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Horse Mask");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Leather, 8);
			recipe.SetResult(this);
			recipe.AddTile(86);
			recipe.AddRecipe();
		}

	}
}
