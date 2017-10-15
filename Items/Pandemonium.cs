using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Pandemonium : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 320;
			item.ranged = true;
			item.width = 52;
			item.height = 34;
			item.useTime = 3;
			item.useAnimation = 12;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 4f;
			item.value = 600000;
			item.rare = 0;
			item.UseSound = SoundID.Item92;
			item.autoReuse = false;
			item.shootSpeed = 25f;
			item.shoot = mod.ProjectileType("PandemoniumBullet");
			item.useAmmo = AmmoID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pandemonium");
			Tooltip.SetDefault("Shoots a burst of bullets\n" +
"Bullets explode into firebals\n" +
"75% chance not to consume ammo");
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			tooltips[0].overrideColor = new Color(238, 194, 73);
		}

		public override bool ConsumeAmmo(Player player)
		{
			if (Main.rand.Next(0, 100) <= 75)
				return false;
			return true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float SpeedX = speedX + Main.rand.Next(-15, 16) * 0.05f;
			float SpeedY = speedY + Main.rand.Next(-15, 16) * 0.05f;
			Projectile.NewProjectile(position.X, position.Y, SpeedX, SpeedY, type, damage, knockBack, player.whoAmI, 0.0f, 0.0f);
			if (Main.rand.Next(2) == 0)
				Projectile.NewProjectile(position.X, position.Y, SpeedX, SpeedY, mod.ProjectileType("PandemoniumBullet"), damage, knockBack, player.whoAmI, 0.0f, 0.0f);
			return false;
		}
	}
}
