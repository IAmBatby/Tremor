using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class MagusBall : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 12;
			projectile.height = 12;
			projectile.hostile = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.extraUpdates = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rune Ball");

		}

		public override bool PreAI()
		{
			for (int i = 0; i < 10; i++)
			{
				float x = projectile.Center.X - projectile.velocity.X / 10f * i;
				float y = projectile.Center.Y - projectile.velocity.Y / 10f * i;
				int dust = Dust.NewDust(new Vector2(x, y), 1, 1, 68, 0f, 0f, 0, default(Color), 1f);
				Main.dust[dust].alpha = projectile.alpha;
				Main.dust[dust].position.X = x;
				Main.dust[dust].position.Y = y;
				Main.dust[dust].velocity *= 0f;
				Main.dust[dust].noGravity = true;
			}
			if (projectile.localAI[1] == 0f)
			{
				projectile.localAI[1] = 1f;
			}
			if (projectile.ai[0] == 0f || projectile.ai[0] == 2f)
			{
				projectile.scale += 0.01f;
				projectile.alpha -= 50;
				if (projectile.alpha <= 0)
				{
					projectile.ai[0] = 1f;
					projectile.alpha = 0;
				}
			}
			else if (projectile.ai[0] == 1f)
			{
				projectile.scale -= 0.01f;
				projectile.alpha += 50;
				if (projectile.alpha >= 255)
				{
					projectile.ai[0] = 2f;
					projectile.alpha = 255;
				}
			}
			return false;
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
			Helper.Explode(projectile.whoAmI, 120, 120, delegate
			{
				for (int i = 0; i < 40; i++)
				{
					int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, 68, 0f, -2f, 0, default(Color), 2f);
					Main.dust[num].noGravity = true;
					Dust expr_62_cp_0 = Main.dust[num];
					expr_62_cp_0.position.X = expr_62_cp_0.position.X + (Main.rand.Next(-50, 51) / 20 - 1.5f);
					Dust expr_92_cp_0 = Main.dust[num];
					expr_92_cp_0.position.Y = expr_92_cp_0.position.Y + (Main.rand.Next(-50, 51) / 20 - 1.5f);
					if (Main.dust[num].position != projectile.Center)
					{
						Main.dust[num].velocity = projectile.DirectionTo(Main.dust[num].position) * 6f;
					}
				}
			});
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Helper.DrawAroundOrigin(projectile.whoAmI, lightColor);
			return false;
		}
	}
}
