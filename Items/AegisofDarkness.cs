using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Shield)]
	public class AegisofDarkness : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 30;
			item.value = 110;
			item.rare = 0;

			item.accessory = true;
			item.defense = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Aegis of Darkness");
			Tooltip.SetDefault("Increases minion damage by 10%\n" +
"Increases magic critical strike chance by 10\n" +
"8% decreased magic damage\n" +
"Increases maximum mana by 40");
		}

		public override void UpdateEquip(Player player)
		{
			player.magicCrit += 10;
			player.minionDamage += 0.1f;
			player.statManaMax2 += 40;
			player.magicDamage -= 0.08f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "EnchantedShield", 1);
			recipe.AddIngredient(null, "NecroShield", 1);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
