using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class FlamesofDespair : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 22;
			item.damage = 152;
			item.magic = true;
			item.mana = 15;
			item.value = 100000;
			item.useTime = 38;
			item.useAnimation = 38;
			item.shoot = mod.ProjectileType("FlamesofDespairPro");
			item.shootSpeed = 30f;
			item.useStyle = 5;
			item.rare = 11;
			item.UseSound = SoundID.Item117;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.knockBack = 3;
			item.autoReuse = false;

			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flames of Despair");
			Tooltip.SetDefault("'Summons homing flames of oblivion'");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.Yellow;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 1; ++i) // Will shoot 3 bullets.
			{
				Projectile.NewProjectile(position.X, position.Y, speedX + 1, speedY + 1, type, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX - 1, speedY - 1, type, damage, knockBack, Main.myPlayer);
			}
			return false;
		}
	}
}
