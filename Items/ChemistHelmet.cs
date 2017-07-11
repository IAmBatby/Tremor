using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class ChemistHelmet : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 22;

			item.value = 10000;
			item.rare = 2;
			item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chemist Helmet");
			Tooltip.SetDefault("Increases alchemic damage by 6%");
		}


		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.06f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("ChemistJacket") && legs.type == mod.ItemType("ChemistPants");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases alchemic critical strike chance by 10%";
			player.GetModPlayer<MPlayer>(mod).alchemistCrit += 10;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "LeatherHat", 1);
			recipe.AddIngredient(null, "ChainCoif", 1);
			recipe.AddIngredient(ItemID.Goggles, 1);
			recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.AddRecipe();
		}

	}
}
