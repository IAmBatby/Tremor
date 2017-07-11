using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class TrueBloodshed : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 44;


			item.value = 10000;
			item.rare = 4;
			item.defense = 6;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Bloodshed");
			Tooltip.SetDefault("12% increased melee, magic, minion, ranged damage and crit\nIncreases maximum mana and health by 80");
		}


		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.magicDamage += 0.12f;
			player.minionDamage += 0.12f;
			player.meleeDamage += 0.12f;
			player.rangedDamage += 0.12f;
			player.statManaMax2 += 80;
			player.statLifeMax2 += 80;
			player.meleeCrit += 12;
			player.magicCrit += 12;
			player.rangedCrit += 12;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Bloodshed", 1);
			recipe.AddIngredient(null, "BrokenHeroAmulet", 1);
			recipe.SetResult(this);
			recipe.AddTile(null, "GreatAnvilTile");
			recipe.AddRecipe();
		}
	}
}
