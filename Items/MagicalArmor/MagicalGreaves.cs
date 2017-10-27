using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.MagicalArmor
{
	[AutoloadEquip(EquipType.Legs)]
	public class MagicalGreaves : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 18;
			item.value = 250;

			item.rare = 1;
			item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Theurgic Greaves");
			Tooltip.SetDefault("3% increased magic damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.magicDamage += 0.03f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 8);
			recipe.AddIngredient(ItemID.LeadBar, 3);
			recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 8);
			recipe.AddIngredient(ItemID.IronBar, 3);
			recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.AddRecipe();

		}

	}
}
