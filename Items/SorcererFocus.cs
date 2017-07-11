using Terraria.ID;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class SorcererFocus : ModItem
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
			DisplayName.SetDefault("Sorcerer Focus");
			Tooltip.SetDefault("6% increased magic damage\nIncreases magic critical strike chance by 12\nIncreases maximum mana by 40");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 4));
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statManaMax2 += 40;
			player.magicDamage += 0.06f;
			player.magicCrit += 12;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SorcererSpark");
			recipe.AddIngredient(null, "SeaFragment", 1);
			recipe.AddIngredient(ItemID.Sapphire, 16);
			recipe.SetResult(this);
			recipe.AddTile(null, "AltarofEnchantmentsTile");
			recipe.AddRecipe();
		}
	}
}
