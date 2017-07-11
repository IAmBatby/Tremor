using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class MineralTransmutator : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 46;
			item.height = 46;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 150;
			item.createTile = mod.TileType("MineralTransmutator");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mineral Transmutator");
			Tooltip.SetDefault("Allows to transform pre-hardmode metals to their alternatives");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Extractinator, 1);
			recipe.AddIngredient(ItemID.SilverOre, 15);
			recipe.AddIngredient(ItemID.TungstenOre, 15);
			recipe.AddIngredient(ItemID.Diamond, 6);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
