using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class NovaRing : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 24;
			item.value = 250000;
			item.rare = 8;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nova Ring");
			Tooltip.SetDefault("20% increased alchemical damage\n14 increased alchemical critical strike chance");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.2f;
			player.GetModPlayer<MPlayer>(mod).alchemicalCrit += 14;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "NovaFragment", 10);
			recipe.AddIngredient(3467, 15);
			recipe.AddIngredient(null, "Band");
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
