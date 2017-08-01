using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.NovaPillar.Projectiles
{
	public class NovaFlierProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nova Stinger");
		}
		public override void SetDefaults()
		{
			projectile.CloneDefaults(348);
			projectile.timeLeft = 500;
			aiType = 348;
			projectile.friendly = false;
			projectile.tileCollide = true;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
		}


		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, 57, Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(-3f, 3f));
			}
			for (int k = 0; k < 5; k++)
			{
				Vector2 Vector = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
				Vector.Normalize();
				Vector *= Main.rand.Next(10, 201) * 0.01f;
				int i = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, Vector.X, Vector.Y, mod.ProjectileType("NovaAlchemistCloud"), 14, 1f, Main.myPlayer, 0f, Main.rand.Next(-45, 1));
				Main.projectile[i].friendly = false;
			}
		}

		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			projectile.Kill();
		}

		public override bool CanHitPlayer(Player target)
		{
			return true;
		}
	}
}