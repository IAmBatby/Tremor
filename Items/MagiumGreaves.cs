using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class MagiumGreaves : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 22;


			item.value = 18000;
			item.rare = 5;
			item.defense = 8;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magium Greaves");
			Tooltip.SetDefault("Increases movement speed by 25%\nIncreases maximum mana by 40");
		}


		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.2f;
			player.maxRunSpeed += 0.2f;
			player.statManaMax2 += 40;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RuneBar", 10);
			recipe.AddIngredient(null, "MagiumShard", 8);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}

	}
}
