using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Items
{
	public class ChargedLamp : ModItem
	{

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float spread = 45f * 0.0174f;
			double startAngle = Math.Atan2(speedX, speedY) - spread / 2;
			double deltaAngle = spread / 8f;
			double offsetAngle;
			int i;
			for (i = 0; i < 4; i++)
			{
				offsetAngle = (startAngle + deltaAngle * (i + i * i) / 2f) + 32f * i;
				Projectile.NewProjectile(position.X, position.Y, (float)(Math.Sin(offsetAngle) * 5f), (float)(Math.Cos(offsetAngle) * 5f), item.shoot, damage, knockBack, item.owner);
				Projectile.NewProjectile(position.X, position.Y, (float)(-Math.Sin(offsetAngle) * 5f), (float)(-Math.Cos(offsetAngle) * 5f), item.shoot, damage, knockBack, item.owner);
			}
			return false;
		}

		public override void SetDefaults()
		{

			item.damage = 60;
			item.magic = true;
			item.mana = 26;
			item.useTime = 60;
			item.useAnimation = 60;
			item.knockBack = 5;
			item.value = 2500;
			item.noUseGraphic = true;
			item.rare = 5;
			item.UseSound = SoundID.Item21;
			item.autoReuse = true;
			item.width = 28;
			item.height = 30;
			item.useStyle = 5;

			item.noMelee = true;
			item.shoot = 709;
			item.shootSpeed = 20f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Charged Lamp");
			Tooltip.SetDefault("Releases electric blasts in all directions");
		}
	}
}
