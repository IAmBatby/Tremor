using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class RedSteelChestplate : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 18;
			item.value = 200;

			item.rare = 2;
			item.defense = 8;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red Steel Chestplate");
			Tooltip.SetDefault("10% increased melee speed");
		}



		public override void UpdateEquip(Player player)
		{
			player.meleeSpeed += 0.1f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RedSteelArmorPiece", 5);
			recipe.AddIngredient(null, "RedSteelBar", 8);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
