using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class LuxoriousLeggings : ModItem
	{

		public override void SetDefaults()
		{
			item.defense = 15;
			item.width = 22;
			item.height = 18;
			item.value = 2500;
			item.rare = 8;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Luxorious Leggings");
			Tooltip.SetDefault("12% increased mining speed");
		}

		public override void UpdateEquip(Player player)
		{
			player.pickSpeed -= 0.12f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "EvershinyBar", 20);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
