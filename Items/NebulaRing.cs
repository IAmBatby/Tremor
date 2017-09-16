using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class NebulaRing : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 28;
			item.height = 22;
			item.value = 250000;
			item.rare = 8;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nebula Ring ");
			Tooltip.SetDefault("20% increased magic damage\nIncreases magic critical strike chance by 15\nIncreases maximum mana by 80");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			player.magicDamage += 0.2f;
			player.magicCrit += 15;
			player.statManaMax2 += 80;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3457, 10);
			recipe.AddIngredient(3467, 15);
			recipe.AddIngredient(null, "Band");
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
