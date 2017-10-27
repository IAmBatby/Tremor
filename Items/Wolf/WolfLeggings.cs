using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items.Wolf
{
	[AutoloadEquip(EquipType.Legs)]
	public class WolfLeggings : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 18;
			item.rare = 1;

			item.value = 100;
			item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wolf Leggings");
			Tooltip.SetDefault("6% increased minion damage\n" +
"Increases movement speed");
		}

		public override void UpdateEquip(Player player)
		{
			player.minionDamage += 0.06f;
			player.moveSpeed += 0.10f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "WolfPelt", 10);
			recipe.AddIngredient(null, "AlphaClaw", 1);
			recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.AddRecipe();
		}
	}
}
