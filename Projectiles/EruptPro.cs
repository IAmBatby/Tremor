using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class EruptPro : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.scale = 1.3f;
			projectile.width = 14;
			projectile.height = 14;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 2;
			projectile.magic = true;
			projectile.ignoreWater = true;
			aiType = 598;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("EruptPro");

		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 60, projectile.oldVelocity.X * 0.7f, projectile.oldVelocity.Y * 0.7f);
			}
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 109);
			if (projectile.owner == Main.myPlayer)
			{
				int num220 = Main.rand.Next(3, 5);
				for (int num221 = 0; num221 < num220; num221++)
				{
					Vector2 value17 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
					value17.Normalize();
					value17 *= Main.rand.Next(10, 201) * 0.01f;
					Projectile.NewProjectile(projectile.position.X, projectile.position.Y, value17.X, value17.Y, 297, projectile.damage, 1f, projectile.owner, 0f, Main.rand.Next(-45, 1));
				}
			}
		}

		public override void AI()
		{
			if (projectile.localAI[0] == 0f)
			{
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 20);
			}
			projectile.localAI[0] += 1f;
			if (projectile.localAI[0] > 3f)
			{
				int num90 = 1;
				if (projectile.localAI[0] > 5f)
				{
					num90 = 2;
				}
				for (int num91 = 0; num91 < num90; num91++)
				{
					int num92 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width, projectile.height, 27, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.1f, 100, default(Color), 0.4f);
					Main.dust[num92].noGravity = true;
					Dust expr_46AC_cp_0 = Main.dust[num92];
					expr_46AC_cp_0.velocity.X = expr_46AC_cp_0.velocity.X * 0.3f;
					Dust expr_46CA_cp_0 = Main.dust[num92];
					expr_46CA_cp_0.velocity.Y = expr_46CA_cp_0.velocity.Y * 0.3f;
					Main.dust[num92].noLight = true;
				}
				if (projectile.wet && !projectile.lavaWet)
				{
					projectile.Kill();
				}
			}
		}

	}
}
