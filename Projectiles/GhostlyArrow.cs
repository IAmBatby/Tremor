using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	//ported from my tAPI mod because I don't want to make artwork
	public class GhostlyArrow : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 16;
			projectile.height = 40;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = -2;
			projectile.tileCollide = true;
			projectile.melee = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ghostly Arrow");

		}



		public override void Kill(int timeLeft)
		{
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 93);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("GhostlyExplosion"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
		}

	}
}
