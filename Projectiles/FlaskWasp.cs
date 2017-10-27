using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class FlaskWasp : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.CloneDefaults(388);
			aiType = 388;

			projectile.width = 40;
			projectile.height = 36;
			Main.projFrames[projectile.type] = 3;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 600;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flask Wasp");

		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Poisoned, 80, false);
		}

		public override void AI()
		{
			projectile.spriteDirection = projectile.direction;
			projectile.rotation = 0f;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (projectile.velocity.X != oldVelocity.X)
			{
				projectile.velocity.X = oldVelocity.X;
			}
			if (projectile.velocity.Y != oldVelocity.Y)
			{
				projectile.velocity.Y = oldVelocity.Y;
			}
			return false;
		}
	}
}
