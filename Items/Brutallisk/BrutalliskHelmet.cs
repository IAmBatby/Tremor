using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items.Brutallisk
{
	[AutoloadEquip(EquipType.Head)]
	public class BrutalliskHelmet : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 22;
			item.value = 150000;
			item.rare = 11;
			item.defense = 20;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brutallisk Helmet");
			Tooltip.SetDefault("Increases maximum life by 40\n" +
"15% increased melee speed");
		}

		public override void UpdateEquip(Player player)
		{
			player.statLifeMax2 += 40;
			player.meleeSpeed += 0.15f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("BrutalliskChestplate") && legs.type == mod.ItemType("BrutalliskGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Greatly increases health regeneration";
			player.lifeRegen = +30;

			if (Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y) > 1f && !player.rocketFrame) // Makes sure the player is actually moving
			{
				for (int k = 0; k < 1; k++)
				{
					int index = Dust.NewDust(new Vector2(player.position.X - player.velocity.X * 2f, player.position.Y - 2f - player.velocity.Y * 2f), player.width, player.height, 13, 0f, 0f, 100, default(Color), 2f);
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
			recipe.AddIngredient(null, "Aquamarine", 10);
			recipe.AddIngredient(null, "NightmareBar", 6);
			recipe.AddIngredient(null, "EvershinyBar", 6);
			recipe.AddIngredient(null, "SteelBar", 3);
			recipe.AddIngredient(null, "Phantaplasm", 2);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
