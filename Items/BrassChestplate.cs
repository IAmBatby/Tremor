using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class BrassChestplate : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 18;

			item.value = 600;
			item.rare = 5;
			item.defense = 22;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brass Chestplate");
			Tooltip.SetDefault("Increases maximum life by 50");
		}


		public override void UpdateEquip(Player player)
		{
			player.statLifeMax2 += 50;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BrassBar", 18);
			recipe.AddIngredient(ItemID.Cog, 16);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
