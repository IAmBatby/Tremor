using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ThrowerFocus : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 22;


			item.rare = 2;
			item.accessory = true;
			item.value = 100000;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thrower Focus");
			Tooltip.SetDefault("6% increased thrown  damage\nIncreases thrown critical strike chance by 12");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 4));
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.thrownDamage += 0.06f;
			player.thrownCrit += 12;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ThrowerSpark");
			recipe.AddIngredient(3380, 15);
			recipe.AddIngredient(ItemID.Amber, 16);
			recipe.SetResult(this);
			recipe.AddTile(null, "AltarofEnchantmentsTile");
			recipe.AddRecipe();
		}
	}
}
