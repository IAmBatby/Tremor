using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class HadesBreastplate : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 18;

			item.value = 600;
			item.rare = 250000;
			item.defense = 56;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hades Breastplate");
			Tooltip.SetDefault("Increases maximum life by 50\nIncreases defense when under 100 health\n45% increased damage");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "InfernoSoul", 10);
			recipe.AddIngredient(null, "MagmoniumBreastplate", 1);
			recipe.AddIngredient(null, "FireFragment", 19);
			recipe.AddIngredient(null, "Phantaplasm", 13);
			recipe.AddIngredient(ItemID.LivingFireBlock, 12);
			recipe.SetResult(this);
			recipe.AddTile(null, "StarvilTile");
			recipe.AddRecipe();
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			tooltips[0].overrideColor = new Color(238, 194, 73);
		}

		public override void UpdateEquip(Player player)
		{
			player.statLifeMax2 += 50;

			if (player.statLife < 100)
			{
				player.statDefense += 35;
			}
			player.meleeDamage += 0.45f;
			player.thrownDamage += 0.45f;
			player.rangedDamage += 0.45f;
			player.magicDamage += 0.45f;
			player.minionDamage += 0.45f;
			player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.45f;
		}
	}
}
