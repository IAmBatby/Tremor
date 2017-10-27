using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class SolarRing : ModItem
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
			DisplayName.SetDefault("Solar Ring ");
			Tooltip.SetDefault("20% increased melee damage\n" +
"Increases melee critical strike chance by 15\n" +
"Casts a ring of fire");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			player.meleeDamage += 0.2f;
			player.meleeCrit += 15;
			player.AddBuff(116, 60, true);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3458, 10);
			recipe.AddIngredient(3467, 15);
			recipe.AddIngredient(null, "Band");
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
