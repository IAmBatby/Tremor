using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class BrassGreaves : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 18;
			item.value = 500;

			item.rare = 5;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brass Greaves");
			Tooltip.SetDefault("15% increased movement speed");
		}


		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.15f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BrassBar", 15);
			recipe.AddIngredient(ItemID.Cog, 14);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
