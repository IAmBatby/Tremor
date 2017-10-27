using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Harpy
{
	[AutoloadEquip(EquipType.Legs)]
	public class HarpyLeggings : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 18;
			item.value = 180;

			item.rare = 1;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Harpy Leggings");
			Tooltip.SetDefault("10% increased movement speed");
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.10f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 10);
			recipe.AddIngredient(ItemID.Feather, 6);
			recipe.SetResult(this);
			recipe.AddTile(86);
			recipe.AddRecipe();
		}

	}
}
