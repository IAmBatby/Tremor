using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class BottledSoulOfSight : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 26;
			item.maxStack = 1;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;

			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 150;
			item.rare = 5;
			item.createTile = mod.TileType("BottledSoulOfSight");
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bottled Soul of Sight");
			Tooltip.SetDefault("Makes you shine if worn\n" +
"Shows the location of enemies if placed");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(549, 5);
			recipe.AddIngredient(ItemID.Bottle, 1);
			recipe.SetResult(this);
			recipe.AddTile(114);
			recipe.AddRecipe();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			player.rangedCrit += 6;
			player.meleeCrit += 6;
			player.magicCrit += 6;
			player.thrownCrit += 6;
		}
	}
}
