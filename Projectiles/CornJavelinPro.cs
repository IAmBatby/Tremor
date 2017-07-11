using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class CornJavelinPro : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 4;
			projectile.height = 4;
			projectile.friendly = true;
			projectile.aiStyle = 1;
			projectile.timeLeft = 1200;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Corn Javelin Pro");

		}


		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 1, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 2f, 100, default(Color), 2f);
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 0);

			if (Main.rand.Next(5) == 0)
			{
				Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("CornJavelin"));
			};
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.ai[0] += 0.1f;
			projectile.velocity *= 0.75f;
		}
	}
}
