using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class BottledSoulOfFlight : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 36;
			item.maxStack = 1;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;


			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 150;
			item.rare = 5;
			item.createTile = mod.TileType("BottledSoulOfFlight");
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bottled Soul of Flight");
			Tooltip.SetDefault("Grants Shiny Red Baloon effect if worn\n20% increased jump height if placed");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(575, 5);
			recipe.AddIngredient(ItemID.Bottle, 1);
			recipe.SetResult(this);
			recipe.AddTile(114);
			recipe.AddRecipe();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			player.jumpBoost = true;
		}
	}
}
