using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class BrassMask : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 20;


			item.value = 400;
			item.rare = 5;
			item.defense = 8;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brass Mask");
			Tooltip.SetDefault("10% increased ranged damage\nIncreases ranged critical strike chance by 8");
		}


		public override void UpdateEquip(Player player)
		{
			player.rangedCrit += 8;
			player.rangedDamage += 0.1f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("BrassChestplate") && legs.type == mod.ItemType("BrassGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.AddBuff(mod.BuffType("buffSteampunkProbe"), 4);
			player.AddBuff(mod.BuffType("SteamRangerBuff"), 4);
			player.setBonus = "Summons a friendly Steampunk Drone to defend you and increases damage of Brass Chain Repeater";
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BrassBar", 13);
			recipe.AddIngredient(ItemID.Cog, 12);
			recipe.AddIngredient(ItemID.Glass, 6);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
