using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.NovaPillar.Projectiles
{
	public class NovaCauldron_Fire : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 12;
			projectile.height = 12;
			projectile.hostile = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.extraUpdates = 1;
			projectile.friendly = true;
			projectile.hostile = false;
		}

		public override bool PreAI()
		{
			for (int i = 0; i < 10; i++)
			{
				float x = projectile.Center.X - projectile.velocity.X / 10f * i;
				float y = projectile.Center.Y - projectile.velocity.Y / 10f * i;
				int dust = Dust.NewDust(new Vector2(x, y), 1, 1, 57, 0f, 0f, 0, default(Color), 1f);
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

		public override void AI()
		{
			projectile.localAI[0] += 1f;
			float num472 = projectile.Center.X;
			float num473 = projectile.Center.Y;
			float num474 = 400f;
			bool flag17 = false;
			for (int num475 = 0; num475 < 200; num475++)
			{
				if (Main.npc[num475].CanBeChasedBy(projectile, false) && Collision.CanHit(projectile.Center, 1, 1, Main.npc[num475].Center, 1, 1))
				{
					float num476 = Main.npc[num475].position.X + Main.npc[num475].width / 2;
					float num477 = Main.npc[num475].position.Y + Main.npc[num475].height / 2;
					float num478 = Math.Abs(projectile.position.X + projectile.width / 2 - num476) + Math.Abs(projectile.position.Y + projectile.height / 2 - num477);
					if (num478 < num474)
					{
						num474 = num478;
						num472 = num476;
						num473 = num477;
						flag17 = true;
					}
				}
			}
			if (flag17)
			{
				float num483 = 10f;
				Vector2 vector35 = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
				float num484 = num472 - vector35.X;
				float num485 = num473 - vector35.Y;
				float num486 = (float)Math.Sqrt(num484 * num484 + num485 * num485);
				num486 = num483 / num486;
				num484 *= num486;
				num485 *= num486;
				projectile.velocity.X = (projectile.velocity.X * 20f + num484) / 21f;
				projectile.velocity.Y = (projectile.velocity.Y * 20f + num485) / 21f;
			}
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
			Helper.Explode(projectile.whoAmI, 120, 120, delegate
			{
				for (int i = 0; i < 40; i++)
				{
					int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, 57, 0f, -2f, 0, default(Color), 2f);
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
