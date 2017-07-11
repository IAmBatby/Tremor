using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class MagiumBreastplate : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 22;


			item.value = 18000;
			item.rare = 5;
			item.defense = 9;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magium Breastplate");
			Tooltip.SetDefault("10% increased magic damage\nIncreases maximum mana by 40");
		}


		public override void UpdateEquip(Player player)
		{
			player.statManaMax2 += 40;
			player.magicDamage += 0.1f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RuneBar", 12);
			recipe.AddIngredient(null, "MagiumShard", 10);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}

	}
}
