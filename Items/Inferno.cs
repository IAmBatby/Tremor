using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Tremor.Items
{
	public class Inferno : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 520;
			item.width = 62;
			item.height = 62;
			item.noUseGraphic = true;
			item.melee = true;
			item.useTime = 20;
			item.shoot = mod.ProjectileType("InfernoPro");
			item.shootSpeed = 12f;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.knockBack = 4;
			item.value = 600000;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Inferno");
			Tooltip.SetDefault("");
		}


		public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> tooltips)
		{
			tooltips[0].overrideColor = new Color(238, 194, 73);
		}
	}
}
