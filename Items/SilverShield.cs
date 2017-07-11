using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Shield)]
	public class SilverShield : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 30;
			item.value = 110;
			item.rare = 0;
			item.accessory = true;
			item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Silver Shield");
			Tooltip.SetDefault("");
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed -= 0.30f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SilverBar, 15);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
