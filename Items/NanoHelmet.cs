using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class NanoHelmet : ModItem
	{




		public override void SetDefaults()
		{

			item.width = 32;
			item.height = 26;


			item.value = 60000;
			item.rare = 6;
			item.defense = 12;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nano Helmet");
			Tooltip.SetDefault("Maximum mana increased by 60\nIncreases critical strike chance by 8%");
		}


		public override void UpdateEquip(Player player)
		{
			player.statManaMax2 += 60;
			player.meleeCrit += 8;
			player.rangedCrit += 8;
			player.magicCrit += 8;
			player.thrownCrit += 8;
			player.GetModPlayer<MPlayer>(mod).alchemistCrit += 8;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("NanoBreastplate") && legs.type == mod.ItemType("NanoGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Summons the nano dron will fight for you";
			player.AddBuff(mod.BuffType("NanoDronBuff"), 2);
			player.nightVision = true;
			if (Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y) > 1f && !player.rocketFrame) // Makes sure the player is actually moving
			{
				for (int k = 0; k < 2; k++)
				{
					int index = Dust.NewDust(new Vector2(player.position.X - player.velocity.X * 2f, player.position.Y - 2f - player.velocity.Y * 2f), player.width, player.height, 226, 0f, 0f, 100, default(Color), 0.4f);
					Main.dust[index].noGravity = true;
					Main.dust[index].noLight = true;
					Dust dust = Main.dust[index];
					dust.velocity.X = dust.velocity.X - player.velocity.X * 0.5f;
					dust.velocity.Y = dust.velocity.Y - player.velocity.Y * 0.5f;
				}
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "NanoBar", 12);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
