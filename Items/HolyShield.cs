using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Shield)]
	public class HolyShield : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 26;
			item.value = 12000;

			item.rare = 7;
			item.accessory = true;
			item.defense = 6;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Holy Shield");
			Tooltip.SetDefault("Prolonged after hit invincibility");
		}

		public override void UpdateEquip(Player player)
		{
			player.longInvince = true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PaladinsShield, 1);
			recipe.AddIngredient(ItemID.CrossNecklace, 1);
			recipe.SetResult(this);
			recipe.AddTile(114);
			recipe.AddRecipe();
		}
	}
}
