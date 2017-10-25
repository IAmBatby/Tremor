using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items.Brutallisk
{
	[AutoloadEquip(EquipType.Legs)]
	public class BrutalliskGreaves : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 22;
			item.value = 150000;
			item.rare = 11;
			item.defense = 20;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brutallisk Greaves");
			Tooltip.SetDefault("Increases maximum life by 40\n" +
"15% increased melee speed\n" +
"90% increased movement speed\n" +
"Greatly increases jump height");
		}

		public override void UpdateEquip(Player player)
		{
			player.statLifeMax2 += 40;
			player.meleeSpeed += 0.15f;
			player.moveSpeed += 0.9f;
			player.jumpBoost = true;
			player.jumpSpeedBoost += 0.9f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Aquamarine", 8);
			recipe.AddIngredient(null, "NightmareBar", 5);
			recipe.AddIngredient(null, "SteelBar", 5);
			recipe.AddIngredient(null, "Phantaplasm", 3);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
