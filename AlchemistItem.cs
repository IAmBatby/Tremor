using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor
{
	public abstract class AlchemistItem : ModItem
	{
		public override void GetWeaponKnockback(Player player, ref float knockback)
		{
			MPlayer modPlayer = player.GetModPlayer<MPlayer>(mod);
			knockback += modPlayer.alchemicalKbAddition;
			knockback *= modPlayer.alchemicalKbMult;
		}

		public override void GetWeaponCrit(Player player, ref int crit)
		{
			MPlayer modPlayer = player.GetModPlayer<MPlayer>(mod);
			crit += modPlayer.alchemicalCrit;
		}

		public override void GetWeaponDamage(Player player, ref int damage)
		{
			MPlayer modPlayer = player.GetModPlayer<MPlayer>(mod);
			// We want to multiply the damage we do by our alchemicalDamage modifier.
			// todo: ? do we want magic damage to also have effect here?
			damage = (int)(damage * modPlayer.alchemicalDamage);
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			var tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
			if (tt != null)
			{
				// take reverse for 'damage',  grab translation
				var split = tt.text.Split(' ');
				// todo: translation alchemical
				tt.text = split.First() + " alchemical " + split.Last();
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
						Projectile.NewProjectile(position.X, position.Y, speedX - 1, speedY - 1, 297, damage, knockBack, Main.myPlayer);
					}
					if (player.FindBuffIndex(mod.BuffType("BigBottledSpirit")) != -1)
					{
						Projectile.NewProjectile(position.X, position.Y, speedX + 3, speedY + 3, 297, damage, knockBack, Main.myPlayer);
						Projectile.NewProjectile(position.X, position.Y, speedX + 2, speedY + 2, 297, damage, knockBack, Main.myPlayer);
						Projectile.NewProjectile(position.X, position.Y, speedX - 1, speedY - 1, 297, damage, knockBack, Main.myPlayer);
						Projectile.NewProjectile(position.X, position.Y, speedX - 2, speedY - 2, 297, damage, knockBack, Main.myPlayer);
					}
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
					Projectile.NewProjectile(position.X, position.Y, speedX - 1, speedY - 1, 297, damage, knockBack, Main.myPlayer);
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
					Projectile.NewProjectile(position.X, position.Y, speedX - 1, speedY - 1, 297, damage, knockBack, Main.myPlayer);
					Projectile.NewProjectile(position.X, position.Y, speedX - 2, speedY - 2, 297, damage, knockBack, Main.myPlayer);
					Main.projectile[k].friendly = true;
				}
				return false;
			}
			return true;
		}
	}
}
