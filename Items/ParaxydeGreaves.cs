using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class ParaxydeGreaves : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 22;

			item.value = 10000;
			item.rare = 5;
			item.defense = 17;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paraxyde Greaves");
			Tooltip.SetDefault("Increases maximum mana by 40");
		}

		public override void UpdateEquip(Player player)
		{
			player.statManaMax2 += 40;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ParaxydeShard", 15);
			recipe.SetResult(this);
			recipe.AddTile(null, "AlchematorTile");
			recipe.AddRecipe();
		}

	}
}
