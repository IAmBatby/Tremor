using Terraria.ID;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class MagmoniumBreastplate : ModItem
	{

		public override void SetDefaults()
		{


			item.defense = 25;
			item.width = 22;
			item.height = 30;
			item.value = 60000;
			item.rare = 8;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magmonium Breastplate");
			Tooltip.SetDefault("12% increased all damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.12f;
			player.thrownDamage += 0.12f;
			player.rangedDamage += 0.12f;
			player.magicDamage += 0.12f;
			player.minionDamage += 0.12f;
			player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.12f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "MagmoniumBar", 25);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
