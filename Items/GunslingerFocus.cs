using Terraria.ID;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class GunslingerFocus : ModItem
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
			DisplayName.SetDefault("Gunslinger Focus");
			Tooltip.SetDefault("6% increased ranged damage\nIncreases ranged critical strike chance by 12");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 4));
		}


		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.rangedDamage += 0.06f;
			player.rangedCrit += 12;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GunslingerSpark");
			recipe.AddIngredient(null, "FireFragment", 1);
			recipe.AddIngredient(ItemID.Topaz, 16);
			recipe.SetResult(this);
			recipe.AddTile(null, "AltarofEnchantmentsTile");
			recipe.AddRecipe();
		}
	}
}
