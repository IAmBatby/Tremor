using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Revolwar : ModItem
	{
		public override void SetDefaults()
		{
			item.useStyle = 5;
			item.useAnimation = 16;
			item.useTime = 16;

			item.width = 24;
			item.height = 28;
			item.shoot = 14;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item11;
			item.damage = 450;
			item.shootSpeed = 12f;
			item.noMelee = true;
			item.value = 500000;
			item.scale = 0.9f;
			item.rare = 0;
			item.ranged = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Revolwar");
			Tooltip.SetDefault("");
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			tooltips[0].overrideColor = new Color(238, 194, 73);
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-12, -2);
		}
	}
}
