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
	public class MarbleHelmet : ModItem
	{

		public override void SetDefaults()
		{


			item.defense = 2;
			item.width = 26;
			item.height = 32;
			item.value = 2500;
			item.rare = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Marble Helmet");
			Tooltip.SetDefault("10% increased throwing velocity");
		}


		public override void UpdateEquip(Player p)
		{
			p.thrownVelocity += 0.1f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("MarbleBreastplate") && legs.type == mod.ItemType("MarbleLeggings");
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadowSubtle = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MarbleBlock, 25);
			recipe.AddIngredient(null, "StoneofLife", 1);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
