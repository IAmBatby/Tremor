using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Tremor.Items;

namespace Tremor
{
	public abstract class AlchemistProjectile : ModProjectile
	{
		// todo: this can PROBABLY be removed when tmodloader updates
		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			Player owner = null;
			if (projectile.owner != -1)
				owner = Main.player[projectile.owner];
			else if (projectile.owner == 255)
				owner = Main.LocalPlayer;

			ModItem mItem = owner?.HeldItem.modItem;
			if (mItem != null)
			{
				int cc = owner.HeldItem.crit;
				(mItem as AlchemistItem)?.GetWeaponCrit(owner, ref cc);
				crit = crit || Main.rand.Next(1, 101) <= cc;
			}
		}
	}

	public abstract class AlchemistItem : ModItem
	{
		// make-safe
		public override void SetDefaults()
		{
			item.melee = false;
			item.ranged = false;
			item.magic = false;
			item.thrown = false;
			item.summon = false;
			item.crit = 4;
		}

		public override void GetWeaponKnockback(Player player, ref float knockback)
		{
			MPlayer modPlayer = player.GetModPlayer<MPlayer>(mod);
			knockback += modPlayer.alchemicalKbAddition;
			knockback *= modPlayer.alchemicalKbMult;
		}

		// todo: borked, tml requires update, manual work still needed
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
			damage = (int)(damage * modPlayer.alchemicalDamage + 5E-06f);
		}

		// todo: this can be removed when tmodloader updates
		public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
		{
			int cc = item.crit;
			GetWeaponCrit(player, ref cc);
			crit = crit || Main.rand.Next(1, 101) <= cc;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			var tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
			if (tt != null)
			{
				// take reverse for 'damage',  grab translation
				string[] split = tt.text.Split(' ');
				// todo: translation alchemical
				tt.text = split.First() + " alchemical " + split.Last();
			}
			
			// todo: this can be removed when tmodloader updates
			if (item.crit > 0)
			{
				int crit = item.crit;
				GetWeaponCrit(Main.LocalPlayer, ref crit);
				tt = tooltips.FirstOrDefault(x => x.Name == "CritChance" && x.mod == "Terraria");
				if (tt != null)
				{
					tt.text = crit + "% " + string.Join(" ", tt.text.Split(' ').Skip(1).ToArray());
				}
				else
				{
					TooltipLine ttl = new TooltipLine(mod, "CritChance", crit + "% critical strike chance");
					int index = tooltips.FindIndex(x => x.Name == "Damage" && x.mod == "Terraria");
					if (index != -1)
					{
						tooltips.Insert(index + 1, ttl);
					}
				}
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
