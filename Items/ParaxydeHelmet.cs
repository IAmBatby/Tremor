using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class ParaxydeHelmet : ModItem
	{



		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 22;


			item.value = 10000;
			item.rare = 5;
			item.defense = 15;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paraxyde Helmet");
			Tooltip.SetDefault("Increases magic damage by 12%\nIncreases melee damage by 16%");
		}


		public override void UpdateEquip(Player player)
		{
			player.magicDamage += 0.12f;
			player.meleeDamage += 0.16f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("ParaxydeBreastplate") && legs.type == mod.ItemType("ParaxydeGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Shadow knives will fall on your target for extra damage";
			player.GetModPlayer<TremorPlayer>(mod).onHitShadaggers = true;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true; //�।��� ����஢����
			player.armorEffectDrawShadow = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ParaxydeShard", 12);
			recipe.SetResult(this);
			recipe.AddTile(null, "AlchematorTile");
			recipe.AddRecipe();
		}
	}
}
