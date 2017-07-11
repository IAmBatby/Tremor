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
	[AutoloadEquip(EquipType.Head)]
	public class LuxoriousHelmet : ModItem
	{

		public override void SetDefaults()
		{

			item.defense = 15;
			item.width = 26;
			item.height = 32;
			item.value = 2500;
			item.rare = 8;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Luxorious Helmet");
			Tooltip.SetDefault("Increases mining speed by 12%");
		}


		public override void UpdateEquip(Player player)
		{
			player.pickSpeed -= 0.12f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("LuxoriousBreastplate") && legs.type == mod.ItemType("LuxoriousLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Allows to detect treasures, ores and traps";
			player.findTreasure = true;
			player.AddBuff(111, 2);
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true;
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "EvershinyBar", 15);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
