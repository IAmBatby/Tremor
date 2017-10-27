using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class TheBoogerBallPro : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.timeLeft = 150;
			projectile.width = 34;
			projectile.height = 34;
			projectile.light = 0.8f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("TheBoogerBallPro");

		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void AI()
		{
			Lighting.AddLight(projectile.Center, new Vector3(0.075f, 0.3f, 0.15f));
			projectile.velocity *= 0.985f;
			projectile.rotation += projectile.velocity.X * 0.2f;
			if (projectile.velocity.X > 0f)
			{
				projectile.rotation += 0.08f;
			}
			else
			{
				projectile.rotation -= 0.08f;
			}
			projectile.ai[1] += 1f;
			if (projectile.ai[1] > 30f)
			{
				projectile.alpha += 10;
				if (projectile.alpha >= 255)
				{
					projectile.alpha = 255;
					projectile.Kill();
				}
			}

		}

	}
}
