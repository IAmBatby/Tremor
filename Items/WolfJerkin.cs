using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class WolfJerkin : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 26;
			item.rare = 1;

			item.value = 100;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wolf Jerkin");
			Tooltip.SetDefault("6% increased minion damage\n" +
"Increases your max number of minions");
		}

		public override void UpdateEquip(Player player)
		{
			player.maxMinions += 1;
			player.minionDamage += 0.06f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "WolfPelt", 16);
			recipe.AddIngredient(null, "AlphaClaw", 2);
			recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.AddRecipe();
		}
	}
}
