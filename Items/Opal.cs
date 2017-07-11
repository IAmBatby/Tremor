using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Opal : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 26;
			item.maxStack = 99;
			item.height = 26;

			item.rare = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Opal");
			Tooltip.SetDefault("'The king of all gems'");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 6));
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Topaz, 1);
			recipe.AddIngredient(ItemID.Amethyst, 1);
			recipe.AddIngredient(ItemID.Emerald, 1);
			recipe.AddIngredient(ItemID.Sapphire, 1);
			recipe.AddIngredient(ItemID.Ruby, 1);
			recipe.AddIngredient(ItemID.Diamond, 1);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
