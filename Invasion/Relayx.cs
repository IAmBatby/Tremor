using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Invasion
{
	public class Relayx : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 95;
			item.melee = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.shoot = mod.ProjectileType("RelayxProj");
			item.shootSpeed = 6f;
			item.knockBack = 6;
			item.value = 1000000;
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.expert = true;

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Relayx");
			Tooltip.SetDefault("Feel the power of the Titan");
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 59);
			}
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (Main.rand.NextBool(8))
			{
				if (Main.rand.NextBool(3))
				{
					Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("RelayxDragonBig"), item.damage + 200, 10, Main.myPlayer);
				}
				else
				{
					Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("RelayxDragon"), item.damage + 100, 10, Main.myPlayer);
				}
			}
			else
			{
				Projectile.NewProjectile(position.X, position.Y, speedX + 1, speedY + 1, type, item.damage - 20, knockBack, Main.myPlayer);
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, item.damage - 20, knockBack, Main.myPlayer);
			}
			return false;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			TooltipLine tip = new TooltipLine(mod, "Tremor:Tooltip", "-Donator Items-");
			tip.overrideColor = new Color(119, 200, 203);
			tooltips.Insert(3, tip);
		}
	}
}
