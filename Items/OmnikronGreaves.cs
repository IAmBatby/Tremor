using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class OmnikronGreaves : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 22;

			item.value = 0;
			item.rare = 0;
			item.defense = 24;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Omnikron Greaves");
			Tooltip.SetDefault("50% increased movement speed\n" +
"Increases all critical strike chances by 15");
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			tooltips[0].overrideColor = new Color(238, 194, 73);
		}
		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.5f;
			player.meleeCrit += 15;
			player.magicCrit += 15;
			player.rangedCrit += 15;
			player.thrownCrit += 15;
			player.GetModPlayer<MPlayer>(mod).alchemicalCrit += 15;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "OmnikronBar", 18);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}

	}
}
