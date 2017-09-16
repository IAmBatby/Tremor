using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class TrebleClef : ModItem
	{
		public override void SetDefaults()
		{

			item.mana = 6;
			item.noMelee = true;
			item.useStyle = 5;
			item.damage = 362;
			item.autoReuse = true;
			item.useAnimation = 12;
			item.useTime = 12;
			item.width = 40;
			item.height = 40;
			item.shoot = 76;
			item.shootSpeed = 6f;
			item.knockBack = 6f;
			item.value = Item.sellPrice(0, 40, 0, 0);
			item.magic = true;
			item.noMelee = true;
			item.rare = 0;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treble Clef");
			Tooltip.SetDefault("");
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			tooltips[0].overrideColor = new Color(238, 194, 73);
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-28, -9);
		}
	}
}
