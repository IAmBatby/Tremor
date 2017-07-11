using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class TrueSanctifier : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 44;

			item.value = 30000;
			item.rare = 5;
			item.maxStack = 1;
			item.defense = 3;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Sanctifier");
			Tooltip.SetDefault("Increases alchemic and throwing damage by 30%");
		}


		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.3f;
			player.thrownDamage += 0.3f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Sanctifier", 1);
			recipe.AddIngredient(null, "BrokenHeroAmulet", 1);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
