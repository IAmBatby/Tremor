using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles.Alchemic.Blasts
{
	public class ClusterBlast : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 10;
		}

		public override void SetDefaults()
		{
			projectile.timeLeft = 420;
			projectile.width = 60;
			projectile.height = 60;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void Kill(int timeLeft)
		{
			if (projectile.scale > 0.85f)
			{
				Vector2 valuekok = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
				valuekok.Normalize();
				valuekok *= Main.rand.Next(10, 201) * 0.01f;
				int proj = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, valuekok.X, valuekok.Y, mod.ProjectileType("ClusterBlastPro"), projectile.damage, 0.8f, projectile.owner, 2f, Main.rand.Next(-45, 45));
				Main.projectile[proj].scale = 0.8f;
			}
		}

		public override void AI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter > 2)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
			}
			if (projectile.frame >= 10)
			{ projectile.Kill(); }
		}
	}
}