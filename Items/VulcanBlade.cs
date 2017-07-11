using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class VulcanBlade : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 545;
			item.melee = true;
			item.width = 46;
			item.height = 48;
			item.useTime = 45;
			item.useAnimation = 45;
			item.useStyle = 1;
			item.knockBack = 3;
			item.shoot = mod.ProjectileType("VulcanBladePro");
			item.shootSpeed = 12f;
			item.value = 600000;
			item.rare = 0;
			item.UseSound = SoundID.Item71;
			item.autoReuse = false;
			item.useTurn = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vulcan Blade");
			Tooltip.SetDefault("Shoots a molten bolt that leaves molten spheres behind\nSpheres home on enemies, explode on contact and set enemies on fire");
		}


		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			tooltips[0].overrideColor = new Color(238, 194, 73);
		}
	}
}
