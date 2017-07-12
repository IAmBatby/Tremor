using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class CrSpear : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(507);

			projectile.width = 14;
			projectile.height = 14;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 99999;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.aiStyle = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Spear");

		}


		public override void AI()
		{
			CreateDust();
		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 10; k++)
			{
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 16, projectile.oldVelocity.X * 0.7f, projectile.oldVelocity.Y * 0.7f);
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 0);
		}

		public void CreateDust()
		{
			if (Main.rand.Next(2) == 1)
			{
				/* TODO: CrystalD does not exist
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType<Dusts.CrystalD>());
				Main.dust[dust].scale = 0.9f;
				*/
			}
		}
	}
}
