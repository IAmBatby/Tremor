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
	public class NightmareHelmet : ModItem
	{

		public override void SetDefaults()
		{

			item.defense = 24;
			item.width = 26;
			item.height = 32;
			item.value = 25000;
			item.rare = 10;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nightmare Helmet");
			Tooltip.SetDefault("");
		}


		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("NightmareBreastplate") && legs.type == mod.ItemType("NightmarePants");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Minor improvements to all stats when health below 50";
			if (player.statLife < 50)
			{
				player.AddBuff(mod.BuffType("ConcentrationofFear"), 2);
			}
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadowLokis = true;
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "NightmareBar", 15);
			recipe.AddIngredient(null, "PurpleQuartz", 5);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
