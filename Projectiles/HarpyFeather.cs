using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class HarpyFeather : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 6;
			projectile.aiStyle = 1;
			projectile.timeLeft = 600;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Harpy");

		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(6, (int)projectile.position.X, (int)projectile.position.Y, 0);
		}

	}
}
