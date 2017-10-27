using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Harpy
{
	[AutoloadEquip(EquipType.Body)]
	public class HarpyChestplate : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 18;
			item.value = 100;

			item.rare = 2;
			item.defense = 5;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Harpy Chestplate");
			Tooltip.SetDefault("Increases jump height");
		}

		public override void UpdateEquip(Player player)
		{
			player.jumpBoost = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 10);
			recipe.AddIngredient(ItemID.Feather, 13);
			recipe.SetResult(this);
			recipe.AddTile(86);
			recipe.AddRecipe();
		}
	}
}
