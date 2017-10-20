using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Alchemist
{
	public class AlchemistFocus : ModItem
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
			DisplayName.SetDefault("Alchemist Focus");
			Tooltip.SetDefault("6% increased alchemical damage\n" +
"12% increased alchemical critical strike chance");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 4));
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.06f;
			player.GetModPlayer<MPlayer>(mod).alchemicalCrit += 12;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AlchemistSpark");
			recipe.AddIngredient(null, "GelCube", 25);
			recipe.AddIngredient(ItemID.Amethyst, 16);
			recipe.SetResult(this);
			recipe.AddTile(null, "AltarofEnchantmentsTile");
			recipe.AddRecipe();
		}
	}
}
