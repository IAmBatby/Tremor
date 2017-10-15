using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class BottledSoulOfMight : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 24;
			item.maxStack = 1;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;

			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 150;
			item.rare = 5;
			item.createTile = mod.TileType("BottledSoulOfMight");
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bottled Soul of Might");
			Tooltip.SetDefault("12% increased damage if worn\n" +
"5% increased damage if placed");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(548, 5);
			recipe.AddIngredient(ItemID.Bottle, 1);
			recipe.SetResult(this);
			recipe.AddTile(114);
			recipe.AddRecipe();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.meleeDamage += 0.12f;
			player.rangedDamage += 0.12f;
			player.thrownDamage += 0.12f;
			player.minionDamage += 0.12f;
			player.magicDamage += 0.12f;
		}
	}
}
