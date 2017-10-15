using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class AfterlifeLeggings : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 22;

			item.value = 10000;
			item.rare = 6;
			item.defense = 9;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Afterlife Leggings");
			Tooltip.SetDefault("Higher jump height\n" +
"Increases movement speed");
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.25f;
			player.jumpBoost = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SkullTeeth", 2);
			recipe.AddIngredient(null, "SteelBar", 16);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}

	}
}
