using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class TheCadenceProj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 4;
			projectile.height = 4;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.ranged = true;
			projectile.alpha = 255;
			projectile.penetrate = 1;
			projectile.extraUpdates = 2;
			projectile.timeLeft = 600;
		}

		public override void AI()
		{
			if (projectile.ai[1] == 0f)
			{
				projectile.ai[1] = 1f;
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 12);
			}
			if (projectile.alpha > 0)
			{
				projectile.alpha -= 15;
			}
			if (projectile.alpha < 0)
			{
				projectile.alpha = 0;
			}
			for (int num121 = 0; num121 < 5; num121++)
			{
				Dust dust4 = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, 172, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1f)];
				dust4.velocity = Vector2.Zero;
				dust4.position -= projectile.velocity / 5f * num121;
				dust4.noGravity = true;
				dust4.scale = 0.8f;
				dust4.noLight = true;
			}
		}
	}
}