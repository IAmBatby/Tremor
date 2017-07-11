using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using System.Linq;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Tremor
{
	public abstract class AlchemistItem : ModItem
	{

		public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> tooltips)
		{
			for (int i = 0; i < tooltips.Count; ++i)
			{
				if (tooltips[i].Name == "Damage")
				{
					MPlayer mp = Main.LocalPlayer.GetModPlayer<MPlayer>(mod);
					tooltips[i].text = ((int)(item.damage * mp.alchemistDamage)).ToString() + " alchemic damage";
				}

				if (tooltips[i].Name == "CritChance")
				{
					MPlayer mp = Main.LocalPlayer.GetModPlayer<MPlayer>(mod);
					tooltips[i].text = ((int)(item.crit + mp.alchemistCrit)).ToString() + "% critical strike chance";
				}
			}
			MPlayer mp2 = Main.LocalPlayer.GetModPlayer<MPlayer>(mod);
			TooltipLine tip = new TooltipLine(mod, "Tremor:Tooltip", ((int)(item.crit + mp2.alchemistCrit)).ToString() + "% critical strike chance");
			tooltips.Insert(2, tip);
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
