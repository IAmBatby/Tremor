using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace Tremor.Items
{
	public class CursedCauldron : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 44;
			item.value = 100000;
			item.rare = 5;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Cauldron");
			Tooltip.SetDefault("Increases alchemic damage by 15\nIncreases alchemic critical strike chance by 20\nAlchemic weapons confuse enemies");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 4));
		}


		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.15f;
			player.AddBuff(mod.BuffType("CursedCloudBuff"), 2);
			player.GetModPlayer<MPlayer>(mod).alchemistCrit += 20;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BlackCauldron", 1);
			recipe.AddIngredient(null, "DeathFormula", 1);
			recipe.SetResult(this);
			recipe.AddTile(114);
			recipe.AddRecipe();
		}
	}
}
