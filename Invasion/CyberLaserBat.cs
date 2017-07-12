using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Invasion
{
	public class CyberLaserBat : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cyber Laser");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(38);
			aiType = 38;
			projectile.width = 20;
			projectile.height = 38;
			projectile.scale = 1f;
		}

		public override void PostAI()
		{
			Vector2 center = projectile.Center;
			Vector2 lookTarget = projectile.Center + projectile.velocity;
			float rotX = lookTarget.X - center.X;
			float rotY = lookTarget.Y - center.Y;
			projectile.rotation = -((float)Math.Atan2(rotX, rotY)) - 1.57f;
			if (Main.netMode != 2)
			{
				int dustID = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType<CyberDust>(), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, Color.White, 0.6f);
				int dustID2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType<CyberDust>(), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, Color.White, 0.8f);
			}
		}
	}
}