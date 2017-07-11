using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class RavenHeadgear : ModItem
	{


		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;
			item.value = 10000;


			item.rare = 4;
			item.defense = 9;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Raven Headgear");
			Tooltip.SetDefault("5% increased melee damage\nIncreases melee critical strike chance by 5");
		}


		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.05f;
			player.meleeCrit += 5;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("RavenBreastplate") && legs.type == mod.ItemType("RavenGreaves");
		}

		public override void UpdateArmorSet(Player p)
		{
			p.setBonus = "Increases player defense by 3, 8% increased melee speed, increases melee critical strike chance by 6";
			p.statDefense += 3;
			p.meleeCrit += 6;
			p.meleeSpeed += 0.8f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MoltenHelmet);
			recipe.AddIngredient(ItemID.IronBar, 8);
			recipe.AddIngredient(null, "RavenFeather", 11);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MoltenHelmet);
			recipe.AddIngredient(ItemID.LeadBar, 8);
			recipe.AddIngredient(null, "RavenFeather", 11);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}

	}
}
