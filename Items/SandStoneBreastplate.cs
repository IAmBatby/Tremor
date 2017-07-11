using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class SandStoneBreastplate : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 18;

			item.value = 600;
			item.rare = 2;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dune Breastplate");
			Tooltip.SetDefault("10% increased movement speed");
		}


		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.1f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SandstoneBar", 12);
			recipe.AddIngredient(null, "AntlionShell", 1);
			recipe.AddIngredient(null, "PetrifiedSpike", 5);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
