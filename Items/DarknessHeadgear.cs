using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class DarknessHeadgear : ModItem
	{

		public override void SetDefaults()
		{

			item.defense = 22;
			item.width = 26;


			item.height = 32;
			item.value = 600000;
			item.rare = 11;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Headgear of Darkness");
			Tooltip.SetDefault("Increases life regeneration\n20% chance not consume ammo");
		}


		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("DarknessBreastplate") && legs.type == mod.ItemType("DarknessGreaves");
		}

		public override void UpdateEquip(Player player)
		{
			player.lifeRegen += 5;
			player.ammoCost80 = true;
		}

		public override void UpdateArmorSet(Player player)
		{

			player.setBonus = "Your ranged stats are increased during the night!";

			if (Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y) > 1f && !player.rocketFrame) // Makes sure the player is actually moving
			{
				for (int k = 0; k < 2; k++)
				{
					int index = Dust.NewDust(new Vector2(player.position.X - player.velocity.X * 2f, player.position.Y - 2f - player.velocity.Y * 2f), player.width, player.height, 54, 0f, 0f, 100, default(Color), 2f);
					Main.dust[index].noGravity = true;
					Main.dust[index].noLight = true;
					Dust dust = Main.dust[index];
					dust.velocity.X = dust.velocity.X - player.velocity.X * 0.5f;
					dust.velocity.Y = dust.velocity.Y - player.velocity.Y * 0.5f;
				}
			}

			if (!Main.dayTime)
			{
				player.rangedCrit += 25;
				player.rangedDamage += 0.30f;
			}
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadowLokis = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DarkGel", 32);
			recipe.AddIngredient(null, "DarkMatter", 32);
			recipe.AddIngredient(null, "DarkMass", 1);
			recipe.SetResult(this);
			recipe.AddTile(247);
			recipe.AddRecipe();
		}
	}
}
