using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items.Alchemist.Chemist
{
	[AutoloadEquip(EquipType.Legs)]
	public class ChemistPants : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 38;
			item.height = 22;
			item.value = 10000;
			item.rare = 2;
			item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chemist Pants");
			Tooltip.SetDefault("6% increased alchemical damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.06f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ChainGreaves", 1);
			recipe.AddIngredient(null, "LeatherGreaves", 1);
			recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.AddRecipe();
		}

	}
}
