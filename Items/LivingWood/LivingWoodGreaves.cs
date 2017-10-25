using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.LivingWood
{
	[AutoloadEquip(EquipType.Legs)]
	public class LivingWoodGreaves : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 18;
			item.value = 200;

			item.rare = 1;
			item.defense = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Living Wood Greaves");
			Tooltip.SetDefault("4% increased minion damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.minionDamage += 0.04f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 25);
			recipe.SetResult(this);
			recipe.AddTile(304);
			recipe.AddRecipe();
		}

	}
}
