using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class LeatherGreaves : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 20;
			item.value = 200;
			item.rare = 1;
			item.defense = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Leather Greaves");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Leather, 15);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Leather, 15);
			recipe.AddTile(TileID.HeavyWorkBench);
			recipe.SetResult(this);
		}
	}
}
