using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class Bounce : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 5;
			projectile.timeLeft = 99999;
			projectile.aiStyle = 1;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bounce");

		}


		float smooth = 2f;

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}
			else
			{
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.velocity.Y = -oldVelocity.Y;
				}
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
			}
			return false;
		}

		public override void AI()
		{
			CreateDust();
		}

		public void CreateDust()
		{
			if (Main.rand.Next(2) == 1)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("Slime"));
				Main.dust[dust].scale = 0.9f;
			}
		}
	}
}
