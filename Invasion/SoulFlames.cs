using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Invasion
{
	public class SoulFlames : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 200;
			item.magic = true;
			item.width = 28;
			item.height = 30;
			item.useTime = 5;
			item.useAnimation = 5;
			item.shoot = 400;
			item.shootSpeed = 31f;
			item.mana = 6;
			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 150000;
			item.rare = 11;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul Flames");
			Tooltip.SetDefault("");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 1; ++i)
			{
				Projectile.NewProjectile(position.X, position.Y, speedX + 1, speedY + 1, type, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX - 1, speedY - 1, type, damage, knockBack, Main.myPlayer);
			}
			return false;
		}

	}
}
