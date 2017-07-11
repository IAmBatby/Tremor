using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ChaoticCross : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 28;


			item.value = 150000;
			item.rare = 6;
			item.accessory = true;
			item.defense = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chaotic Cross");
			Tooltip.SetDefault("The less health, the more critical strike chance...\nThe less health, the more damage...");
		}


		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			if (player.statLife < 50)
			{
				player.magicCrit += 20;
				player.meleeCrit += 20;
				player.rangedCrit += 20;
				player.magicDamage += 0.20f;
				player.meleeDamage += 0.20f;
				player.rangedDamage += 0.20f;
			}
			if (player.statLife < 100)
			{
				player.magicCrit += 15;
				player.meleeCrit += 15;
				player.rangedCrit += 15;
				player.magicDamage += 0.15f;
				player.meleeDamage += 0.15f;
				player.rangedDamage += 0.15f;
			}
			if (player.statLife < 200)
			{
				player.magicCrit += 10;
				player.meleeCrit += 10;
				player.rangedCrit += 10;
				player.magicDamage += 0.10f;
				player.meleeDamage += 0.10f;
				player.rangedDamage += 0.10f;
			}
			if (player.statLife < 300)
			{
				player.magicCrit += 5;
				player.meleeCrit += 5;
				player.rangedCrit += 5;
				player.magicDamage += 0.05f;
				player.meleeDamage += 0.05f;
				player.rangedDamage += 0.05f;
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ChaoticAmplifier", 1);
			recipe.AddIngredient(null, "Stigmata", 1);
			recipe.SetResult(this);
			recipe.AddTile(114);
			recipe.AddRecipe();
		}
	}
}
