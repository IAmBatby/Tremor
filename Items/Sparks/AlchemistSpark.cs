using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Tremor.Items.Sparks
{
	public class AlchemistSpark : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alchemist Spark");
			Tooltip.SetDefault("3% increased alchemical damage\n" +
			                   "8% increased alchemical critical strike chance");
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
			player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.03f;
			player.GetModPlayer<MPlayer>(mod).alchemicalCrit += 8;
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
