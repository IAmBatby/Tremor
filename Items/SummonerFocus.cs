using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class SummonerFocus : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 22;

			item.rare = 2;
			item.accessory = true;
			item.value = 50000;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Summoner Focus");
			Tooltip.SetDefault("Increases minion damage by 8%\n" +
"Increases your max number of minions");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 4));
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.maxMinions += 1;
			player.minionDamage += 0.08f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SummonerSpark");
			recipe.AddIngredient(null, "EarthFragment", 1);
			recipe.AddIngredient(ItemID.Emerald, 16);
			recipe.SetResult(this);
			recipe.AddTile(null, "AltarofEnchantmentsTile");
			recipe.AddRecipe();
		}
	}
}
