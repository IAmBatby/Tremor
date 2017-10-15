using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class LuxoriousBreastplate : ModItem
	{

		public override void SetDefaults()
		{
			item.defense = 20;
			item.width = 22;
			item.height = 30;
			item.value = 2500;
			item.rare = 8;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Luxorious Breastplate");
			Tooltip.SetDefault("12% increased mining speed");
		}

		public override void UpdateEquip(Player player)
		{
			player.pickSpeed -= 0.12f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "EvershinyBar", 25);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
