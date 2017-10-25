using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items.Flesh
{
	[AutoloadEquip(EquipType.Body)]
	public class FleshBreastplate : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 22;

			item.value = 18000;
			item.rare = 1;
			item.defense = 7;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flesh Breastplate");
			Tooltip.SetDefault("5% increased minion damage\n" +
"Increases your max number of minions");
		}

		public override void UpdateEquip(Player player)
		{
			player.maxMinions += 1;
			player.minionDamage += 0.05f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "PieceofFlesh", 7);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}

	}
}
