using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class BrainSmasher : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 44;

			item.value = 250000;
			item.rare = 7;
			item.accessory = true;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brain Smasher");
			Tooltip.SetDefault("Grants a spinning ball around the player");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(mod.BuffType("BrainSmasherBuff"), 2);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BallnChain", 1);
			recipe.AddIngredient(null, "GolemCore", 1);
			recipe.AddIngredient(2766, 25);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
