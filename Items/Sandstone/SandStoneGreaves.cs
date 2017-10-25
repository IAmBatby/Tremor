using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items.Sandstone
{
	[AutoloadEquip(EquipType.Legs)]
	public class SandStoneGreaves : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 18;
			item.value = 500;

			item.rare = 2;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dune Greaves");
			Tooltip.SetDefault("10% increased movement speed");
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.1f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SandstoneBar", 10);
			recipe.AddIngredient(null, "AntlionShell", 1);
			recipe.AddIngredient(null, "PetrifiedSpike", 4);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
