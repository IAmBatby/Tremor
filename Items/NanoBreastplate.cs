using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class NanoBreastplate : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 18;


			item.value = 60000;
			item.rare = 6;
			item.defense = 17;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nano Breastplate");
			Tooltip.SetDefault("8% increased all damage\n10% increases melee speed");
		}


		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.08f;
			player.magicDamage += 0.08f;
			player.minionDamage += 0.08f;
			player.thrownDamage += 0.08f;
			player.rangedDamage += 0.08f;
			player.meleeSpeed += 0.10f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "NanoBar", 20);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
