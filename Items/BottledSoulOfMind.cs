using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class BottledSoulOfMind : ModItem
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
			item.createTile = mod.TileType("BottledSoulOfMind");
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bottled Soul of Mind");
			Tooltip.SetDefault("Shows the location of enemies if worn\nShows the location of treasure and ore if placed");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SoulofMind", 5);
			recipe.AddIngredient(ItemID.Bottle, 1);
			recipe.SetResult(this);
			recipe.AddTile(114);
			recipe.AddRecipe();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			player.detectCreature = true;
		}
	}
}
