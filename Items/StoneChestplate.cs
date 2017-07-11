using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class StoneChestplate : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 18;

			item.value = 0;
			item.rare = 1;
			item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stone Chestplate");
			Tooltip.SetDefault("4% increased melee damage");
		}


		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.04f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 75);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}

	}
}
