using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class BouncingCasing : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 44;

			item.value = 25000;
			item.rare = 5;
			item.accessory = true;
			item.defense = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bouncing Casing");
			Tooltip.SetDefault("Alchemical flasks bounce off blocks");
		}


		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(mod.BuffType("BouncingCasingBuff"), 2);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bottle, 1);
			recipe.AddIngredient(null, "PinkGelCube", 5);
			recipe.AddIngredient(ItemID.SoulofLight, 9);
			recipe.AddIngredient(ItemID.SoulofNight, 9);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
