using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class Gurumaster : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.friendly = true;
			projectile.width = 4;
			projectile.height = 4;
			projectile.aiStyle = 0;
			Main.projFrames[projectile.type] = 4;
			projectile.timeLeft = 1200;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gurumaster");

		}

		public override void AI()
		{
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 136, default(Color), 0.9f);
			Main.dust[dust].noGravity = true;

			if (projectile.frameCounter < 5)
				projectile.frame = 0;
			else if (projectile.frameCounter >= 5 && projectile.frameCounter < 10)
				projectile.frame = 1;
			else if (projectile.frameCounter >= 10 && projectile.frameCounter < 15)
				projectile.frame = 2;
			else if (projectile.frameCounter >= 15 && projectile.frameCounter < 20)
				projectile.frame = 3;
			else
				projectile.frameCounter = 0;
			projectile.frameCounter++;
		}

		public override void Kill(int timeLeft)
		{

			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 62);
			projectile.position.X = projectile.position.X + projectile.width / 2;
			projectile.position.Y = projectile.position.Y + projectile.height / 2;
			projectile.width = 80;
			projectile.height = 80;
			projectile.position.X = projectile.position.X - projectile.width / 2;
			projectile.position.Y = projectile.position.Y - projectile.height / 2;
			for (int num628 = 0; num628 < 40; num628++)
			{
				int num629 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 2f);
				Main.dust[num629].velocity *= 3f;
				if (Main.rand.Next(2) == 0)
				{
					Main.dust[num629].scale = 0.5f;
					Main.dust[num629].fadeIn = 1f + Main.rand.Next(10) * 0.1f;
				}
			}
			for (int num630 = 0; num630 < 70; num630++)
			{
				int num631 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 3f);
				Main.dust[num631].noGravity = true;
				Main.dust[num631].velocity *= 5f;
				num631 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 2f);
				Main.dust[num631].velocity *= 2f;
			}
			for (int num632 = 0; num632 < 3; num632++)
			{
				float scaleFactor10 = 0.33f;
				if (num632 == 1)
				{
					scaleFactor10 = 0.66f;
				}
				if (num632 == 2)
				{
					scaleFactor10 = 1f;
				}
				int num633 = Gore.NewGore(new Vector2(projectile.position.X + projectile.width / 2 - 24f, projectile.position.Y + projectile.height / 2 - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[num633].velocity *= scaleFactor10;
				Gore expr_13E6D_cp_0 = Main.gore[num633];
				expr_13E6D_cp_0.velocity.X = expr_13E6D_cp_0.velocity.X + 1f;
				Gore expr_13E8D_cp_0 = Main.gore[num633];
				expr_13E8D_cp_0.velocity.Y = expr_13E8D_cp_0.velocity.Y + 1f;
				num633 = Gore.NewGore(new Vector2(projectile.position.X + projectile.width / 2 - 24f, projectile.position.Y + projectile.height / 2 - 24f), default(Vector2), Main.rand.Next(61, 64), 2f);
				Main.gore[num633].velocity *= scaleFactor10;
				Gore expr_13F30_cp_0 = Main.gore[num633];
				expr_13F30_cp_0.velocity.X = expr_13F30_cp_0.velocity.X - 1f;
				Gore expr_13F50_cp_0 = Main.gore[num633];
				expr_13F50_cp_0.velocity.Y = expr_13F50_cp_0.velocity.Y + 1f;
				num633 = Gore.NewGore(new Vector2(projectile.position.X + projectile.width / 2 - 24f, projectile.position.Y + projectile.height / 2 - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[num633].velocity *= scaleFactor10;
				Gore expr_13FF3_cp_0 = Main.gore[num633];
				expr_13FF3_cp_0.velocity.X = expr_13FF3_cp_0.velocity.X + 1f;
				Gore expr_14013_cp_0 = Main.gore[num633];
				expr_14013_cp_0.velocity.Y = expr_14013_cp_0.velocity.Y - 1f;
				num633 = Gore.NewGore(new Vector2(projectile.position.X + projectile.width / 2 - 24f, projectile.position.Y + projectile.height / 2 - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[num633].velocity *= scaleFactor10;
				Gore expr_140B6_cp_0 = Main.gore[num633];
				expr_140B6_cp_0.velocity.X = expr_140B6_cp_0.velocity.X - 1f;
				Gore expr_140D6_cp_0 = Main.gore[num633];
				expr_140D6_cp_0.velocity.Y = expr_140D6_cp_0.velocity.Y - 1f;
			}
			projectile.position.X = projectile.position.X + projectile.width / 2;
			projectile.position.Y = projectile.position.Y + projectile.height / 2;
			projectile.width = 10;
			projectile.height = 10;
			projectile.position.X = projectile.position.X - projectile.width / 2;
			projectile.position.Y = projectile.position.Y - projectile.height / 2;

			if (projectile.owner == Main.myPlayer)
			{
				int num220 = Main.rand.Next(3, 8);
				for (int num221 = 0; num221 < num220; num221++)
				{
					Vector2 value17 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
					value17.Normalize();
					value17 *= Main.rand.Next(10, 201) * 0.01f;
					Projectile.NewProjectile(projectile.position.X, projectile.position.Y, value17.X, value17.Y, mod.ProjectileType("BoomCloudPro"), projectile.damage, 1f, projectile.owner, 0f, Main.rand.Next(-45, 1));
				}
			}
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

	}
}
