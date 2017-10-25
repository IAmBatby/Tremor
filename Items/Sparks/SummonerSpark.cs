using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Tremor.Items.Sparks
{
	public class SummonerSpark : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Summoner Spark");
			Tooltip.SetDefault("5% increased minion damage\n" +
			                   "Increases your max number of minions");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 4));
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.rare = 1;
			item.accessory = true;
			item.value = Item.buyPrice(silver: 1);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.minionDamage += 0.05f;
			player.maxMinions += 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AdventurerSpark");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
