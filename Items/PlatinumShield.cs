using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Shield)]
	public class PlatinumShield : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 28;
			item.height = 28;
			item.value = 110;
			item.rare = 0;
			item.accessory = true;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Platinum Shield");
			Tooltip.SetDefault("");
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed -= 0.40f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PlatinumBar, 15);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
