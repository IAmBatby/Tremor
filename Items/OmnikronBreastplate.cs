using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class OmnikronBreastplate : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;
			item.value = 0;

			item.rare = 0;
			item.defense = 40;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Omnikron Breastplate");
			Tooltip.SetDefault("20% increased damage");
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			tooltips[0].overrideColor = new Color(238, 194, 73);
		}

		public override void UpdateEquip(Player player)
		{
			player.magicDamage += 0.2f;
			player.minionDamage += 0.2f;
			player.meleeDamage += 0.2f;
			player.rangedDamage += 0.2f;
			player.thrownDamage += 0.2f;
			player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.2f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "OmnikronBar", 26);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
