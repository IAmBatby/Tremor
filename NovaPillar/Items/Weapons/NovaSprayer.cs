using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NovaPillar.Items.Weapons
{
	public class NovaSprayer : AlchemistItem
	{
		public override void SetDefaults()
		{

			item.damage = 84;
			item.width = 62;
			item.height = 32;
			item.useTime = 6;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 100000;
			item.rare = 10;
			item.UseSound = SoundID.Item11;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("NovaFlask_ProjBall");
			item.shootSpeed = 15f;
			item.crit = 12;
			item.reuseDelay = 60;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nova Sprayer");
			Tooltip.SetDefault("Shoots a burst of nova balls which explode into flames when hit enemy or after some time,\n flames explode into damaging bursts when hit enemy or after some time.");
		}


		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-15, 0);
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void UpdateInventory(Player player)
		{
			if (player.FindBuffIndex(mod.BuffType("FlaskCoreBuff")) != -1)
			{
				item.autoReuse = true;
			}
			if (player.FindBuffIndex(mod.BuffType("FlaskCoreBuff")) < 1)
			{
				item.autoReuse = false;
			}
			if (player.FindBuffIndex(mod.BuffType("LongFuseBuff")) != -1)
			{
				item.shootSpeed = 21f;
			}
			if (player.FindBuffIndex(mod.BuffType("LongFuseBuff")) < 1)
			{
				item.shootSpeed = 15f;
			}
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			MPlayer modPlayer = player.GetModPlayer<MPlayer>(mod);
			if (modPlayer.glove)
			{
				for (int i = 0; i < 1; ++i)
				{
					if (player.FindBuffIndex(mod.BuffType("BottledSpirit")) != -1)
					{
						Projectile.NewProjectile(position.X, position.Y, speedX + 2, speedY + 2, 297, damage, knockBack, Main.myPlayer);
					}
					if (player.FindBuffIndex(mod.BuffType("BigBottledSpirit")) != -1)
					{
						Projectile.NewProjectile(position.X, position.Y, speedX + 3, speedY + 3, 297, damage, knockBack, Main.myPlayer);
						Projectile.NewProjectile(position.X, position.Y, speedX + 2, speedY + 2, 297, damage, knockBack, Main.myPlayer);
					}
					Projectile.NewProjectile(position.X, position.Y, speedX + 1, speedY + 1, type, damage, knockBack, Main.myPlayer);
					Projectile.NewProjectile(position.X, position.Y, speedX + 1, speedY + 1, type, damage, knockBack, Main.myPlayer);
					int k = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
					Main.projectile[k].friendly = true;
				}
				return false;
			}
			if (player.FindBuffIndex(mod.BuffType("BottledSpirit")) != -1 && !modPlayer.glove)
			{
				for (int i = 0; i < 1; ++i)
				{
					Projectile.NewProjectile(position.X, position.Y, speedX + 1, speedY + 1, 297, damage, knockBack, Main.myPlayer);
					int k = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
					Main.projectile[k].friendly = true;
				}
				return false;
			}
			if (player.FindBuffIndex(mod.BuffType("BigBottledSpirit")) != -1 && !modPlayer.glove)
			{
				for (int i = 0; i < 1; ++i)
				{
					Projectile.NewProjectile(position.X, position.Y, speedX + 2, speedY + 2, 297, damage, knockBack, Main.myPlayer);
					Projectile.NewProjectile(position.X, position.Y, speedX + 1, speedY + 1, 297, damage, knockBack, Main.myPlayer);
					int k = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
					Main.projectile[k].friendly = true;
				}
				return false;
			}
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "NovaFragment", 18);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
