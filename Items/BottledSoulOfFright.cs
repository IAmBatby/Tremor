using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class BottledSoulOfFright : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 28;
			item.maxStack = 1;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;

			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 150;
			item.rare = 5;
			item.createTile = mod.TileType("BottledSoulOfFright");
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bottled Soul of Fright");
			Tooltip.SetDefault("Increases critical strike chance by 6 if worn\n" +
"Increased critical strike chance by 2 if placed");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(547, 5);
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
