using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class GuardianHammerPro : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.CloneDefaults(301);
			projectile.width = 32;
			projectile.height = 32;
			aiType = 301;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("GarnetGlovePro");

		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override bool CanHitPlayer(Player target)
		{
			return false;
		}

		public override bool? CanHitNPC(NPC target)
		{
			return (target.friendly) ? false : true;
		}

		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
			if (Main.rand.NextBool())
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 62, projectile.velocity.X * 0.9f, projectile.velocity.Y * 0.9f);
			}
		}

	}
}
