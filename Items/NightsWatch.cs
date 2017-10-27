using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class NightsWatch : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 44;
			item.value = 10000;
			item.rare = 3;
			item.defense = 6;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Night's Watch");
			Tooltip.SetDefault("8% increased magic, melee and minion damage\n" +
"Increases maximum mana and health by 60\n" +
"Increases melee and magic critical strike chance by 10");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.magicDamage += 0.08f;
			player.minionDamage += 0.08f;
			player.meleeDamage += 0.08f;
			player.statManaMax2 += 60;
			player.statLifeMax2 += 60;
			player.meleeCrit += 10;
			player.magicCrit += 10;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "JungleWrath", 1);
			recipe.AddIngredient(null, "DemoniteProtector", 1);
			recipe.AddIngredient(null, "WaterStorm", 1);
			recipe.AddIngredient(null, "Candent", 1);
			recipe.SetResult(this);
			recipe.AddTile(null, "GreatAnvilTile");
			recipe.AddRecipe();
		}
	}
}
