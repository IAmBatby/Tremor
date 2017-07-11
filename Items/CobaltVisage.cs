using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class CobaltVisage : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 22;

			item.value = 400;
			item.rare = 4;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cobalt Visage");
			Tooltip.SetDefault("Increases alchemic damage by 18%");
		}


		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.18f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 374 && legs.type == 375;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases alchemic critical strike chance by 12%";
			player.GetModPlayer<MPlayer>(mod).alchemistCrit += 12;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CobaltBar, 10);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
