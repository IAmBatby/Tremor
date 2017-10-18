using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class PirahnaPro : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 26;
			projectile.height = 32;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 6;
			Main.projFrames[projectile.type] = 4;
			projectile.aiStyle = 1;
			projectile.timeLeft = 600;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("PirahnaPro");

		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 1);
			Gore.NewGore(projectile.position, projectile.velocity, 85, 1f);
			for (int num158 = 0; num158 < 20; num158++)
			{
				int num159 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 5, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, default(Color), 0.5f);
				if (Main.rand.NextBool(3))
				{
					Main.dust[num159].fadeIn = 1.1f + Main.rand.Next(-10, 11) * 0.01f;
					Main.dust[num159].scale = 0.35f + Main.rand.Next(-10, 11) * 0.01f;
					Main.dust[num159].type++;
				}
				else
				{
					Main.dust[num159].scale = 1.2f + Main.rand.Next(-10, 11) * 0.01f;
				}
				Main.dust[num159].noGravity = true;
				Main.dust[num159].velocity *= 2.5f;
				Main.dust[num159].velocity -= projectile.oldVelocity / 10f;
			}
			if (Main.myPlayer == projectile.owner)
			{
				int num160 = Main.rand.Next(0, 0);
				for (int num161 = 0; num161 < num160; num161++)
				{
					Vector2 value12 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
					while (value12.X == 0f && value12.Y == 0f)
					{
						value12 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
					}
					value12.Normalize();
					value12 *= Main.rand.Next(70, 101) * 0.1f;
					Projectile.NewProjectile(projectile.oldPosition.X + projectile.width / 2, projectile.oldPosition.Y + projectile.height / 2, value12.X, value12.Y, 400, (int)(projectile.damage * 0.8), projectile.knockBack * 0.8f, projectile.owner, 0f, 0f);
				}
			}
		}

	}
}
