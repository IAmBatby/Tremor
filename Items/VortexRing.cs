using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class VortexRing : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 28;
			item.height = 20;
			item.value = 250000;
			item.rare = 8;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vortex Ring ");
			Tooltip.SetDefault("20% increased ranged damage\nIncreases ranged critical strike chance by 15\n25% chance not to consume ammo");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.rangedDamage += 0.2f;
			player.rangedCrit += 15;
			player.ammoCost75 = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3456, 10);
			recipe.AddIngredient(3467, 15);
			recipe.AddIngredient(null, "Band");
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
