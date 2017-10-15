using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class RedSteelGreaves : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 18;
			item.value = 360;
			item.rare = 2;
			item.defense = 5;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red Steel Greaves");
			Tooltip.SetDefault("20% increased movement speed");
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.2f;
		}

		public override void AddRecipes()
		{
			//ModRecipe recipe = new ModRecipe(mod);
			//recipe.AddIngredient(null, "RedSteelArmorPiece", 5);
			//recipe.AddIngredient(null, "RedSteelBar", 6);
			//recipe.SetResult(this);
			//recipe.AddTile(16);
			//recipe.AddRecipe();
		}

	}
}
