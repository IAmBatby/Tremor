using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs.Bosses.CogLord.Projectiles
{
	public class CogLordCog : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cog");
		}

		public override void SetDefaults()
		{
			projectile.Size = originalSize;
			projectile.tileCollide = false;
			projectile.alpha = 244;
			projectile.scale = 0.25f;
			projectile.hostile = true;
			projectile.light = projectile.scale * 1.5f;
		}

		Vector2 originalSize = new Vector2(42, 46);

		public override void AI()
		{
			if (projectile.ai[0] == 0) // First update/spawn sequence.
			{
				projectile.localAI[0] = Main.rand.Next(1, 11) * Main.rand.NextBool().ToDirectionInt();
				projectile.ai[0] = 1;
			}
			else if (projectile.ai[0] == 1) // 'Appear' sequence.
			{
				if (projectile.alpha > 0)
				{
					projectile.alpha = Math.Max(projectile.alpha - 4, 0);
					projectile.scale = Math.Min(projectile.scale + 0.0123f, 1);
				}
				if (projectile.alpha <= 0 && projectile.ai[1]++ >= 120)
					projectile.ai[0] = 2;
			}
			else if (projectile.ai[0] == 2) // 'Disappear' sequence.
			{
				if (projectile.alpha < 255)
				{
					projectile.alpha = Math.Min(projectile.alpha + 4, 255);
					projectile.scale = Math.Max(projectile.scale - 0.0125f, 0);
				}
				if (projectile.alpha >= 255)
					projectile.timeLeft = 0;
			}

			projectile.rotation += projectile.localAI[0] * 0.05f / projectile.Opacity;
			projectile.position = projectile.Center;
			projectile.Size = originalSize * projectile.scale;
			projectile.Center = projectile.position;
			projectile.light = projectile.scale * 1.5f;
			drawOriginOffsetY = (projectile.height - (int)originalSize.Y) / 2;
			drawOffsetX = (projectile.width - (int)originalSize.X) / 2;
		}

		public override Color? GetAlpha(Color lightColor) => Color.White * projectile.Opacity;
		public override bool PreKill(int timeLeft) => false;
		public override bool CanHitPlayer(Player target) => projectile.alpha <= 125;
	}
}