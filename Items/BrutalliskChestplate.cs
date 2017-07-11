using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class BrutalliskChestplate : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 22;
			item.value = 150000;
			item.rare = 11;
			item.defense = 32;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brutallisk Chestplate");
			Tooltip.SetDefault("Increases maximum life by 40\n15% increased melee speed\n25% increased all damage");
		}


		public override void UpdateEquip(Player player)
		{
			player.statLifeMax2 += 40;
			player.meleeSpeed += 0.15f;
			player.meleeDamage += 0.25f;
			player.minionDamage += 0.25f;
			player.rangedDamage += 0.25f;
			player.magicDamage += 0.25f;
			player.thrownDamage += 0.25f;
			player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.25f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Aquamarine", 10);
			recipe.AddIngredient(null, "NightmareBar", 6);
			recipe.AddIngredient(null, "EvershinyBar", 8);
			recipe.AddIngredient(null, "SteelBar", 2);
			recipe.AddIngredient(null, "Phantaplasm", 4);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
