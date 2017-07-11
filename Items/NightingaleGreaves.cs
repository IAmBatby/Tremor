using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class NightingaleGreaves : ModItem
	{


		public override void SetDefaults()
		{
			item.defense = 6;
			item.width = 22;
			item.height = 18;
			item.value = 2500;
			item.rare = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nightingale Greaves");
			Tooltip.SetDefault("Increases movement speed by 10%");
		}


		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.10f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SteelBar", 10);
			recipe.AddIngredient(null, "PhantomSoul", 3);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
