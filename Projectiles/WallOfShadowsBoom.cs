using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class WallOfShadowsBoom : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 52;
			projectile.height = 52;
			projectile.penetrate = -1;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.hostile = false;
			projectile.friendly = true;
			Main.projFrames[projectile.type] = 5;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wall Of Shadows Boom");

		}

		public override bool PreAI()
		{
			if (projectile.ai[0] == 0f)
			{
				projectile.Damage();
				projectile.ai[0] = 1f;
			}
			projectile.frameCounter++;
			if (projectile.frameCounter > 10)
			{
				;
				projectile.frameCounter = 0;
				projectile.frame++;
				if (projectile.frame > Main.projFrames[projectile.type])
				{
					projectile.Kill();
				}
			}
			return false;
		}

		public override void AI()
		{
			Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 173, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(153, 300);
		}
	}
}
