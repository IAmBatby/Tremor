using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class HellStorm : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 220;
			item.ranged = true;
			item.width = 32;
			item.height = 78;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.channel = true;
			item.knockBack = 5f;
			item.value = 10000000;
			item.rare = 0;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("HellStormProj");
			item.shootSpeed = 20f;

			item.useAmmo = AmmoID.Arrow;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hell Storm");
			Tooltip.SetDefault("Shoots out homing hell arrows\nThe amount of arrows shot increases when used for longer time");
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			tooltips[0].overrideColor = new Color(238, 194, 73);
		}
		/*
				public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
				{
					Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("HellStormProj"), damage, knockBack, player.whoAmI, 0.0f, 0.0f);
					return false;
				}
		*/

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = mod.ProjectileType("HellStormProj");
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

	}
}
