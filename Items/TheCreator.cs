using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class TheCreator : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 44;

			item.value = 10000;
			item.rare = 4;
			item.defense = 9;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Creator");
			Tooltip.SetDefault("15% increased damage and crit\n" +
"Increases maximum mana and health by 100");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.magicDamage += 0.15f;
			player.minionDamage += 0.15f;
			player.meleeDamage += 0.15f;
			player.rangedDamage += 0.15f;
			player.thrownDamage += 0.15f;
			player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.15f;
			player.statManaMax2 += 100;
			player.statLifeMax2 += 100;
			player.meleeCrit += 15;
			player.magicCrit += 15;
			player.rangedCrit += 15;
			player.thrownCrit += 15;
			player.GetModPlayer<MPlayer>(mod).alchemicalCrit += 15;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "TrueBloodshed", 1);
			recipe.AddIngredient(null, "TrueSanctifier", 1);
			recipe.SetResult(this);
			recipe.AddTile(null, "GreatAnvilTile");
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "TrueNightsWatch", 1);
			recipe.AddIngredient(null, "TrueSanctifier", 1);
			recipe.SetResult(this);
			recipe.AddTile(null, "GreatAnvilTile");
			recipe.AddRecipe();
		}
	}
}
