using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class BronzeGreaves : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 18;
			item.value = 500;

			item.rare = 1;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bronze Greaves");
			Tooltip.SetDefault("6% increased magic critical strike chance");
		}


		public override void UpdateEquip(Player player)
		{
			player.magicCrit += 6;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BronzeBar", 17);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
