using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class SorcererSpark : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 22;
			item.rare = 1;
			item.accessory = true;
			item.value = 20000;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sorcerer Spark");
			Tooltip.SetDefault("3% increased magic damage\nIncreases magic critical strike chance by 8\nIncreases maximum mana by 20");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 4));
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statManaMax2 += 20;
			player.magicDamage += 0.03f;
			player.magicCrit += 8;
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
