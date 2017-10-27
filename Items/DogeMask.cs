using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class DogeMask : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 24;

			item.rare = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Doge Mask");
			Tooltip.SetDefault("'Let it wow'");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 8);
			recipe.SetResult(this);
			recipe.AddTile(86);
			recipe.AddRecipe();
		}

	}
}
