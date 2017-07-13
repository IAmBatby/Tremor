using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NovaPillar.Projectiles
{
	public class NovaBottle : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nova Flask");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 2;
		}
		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 28;
			projectile.aiStyle = 2;
			projectile.timeLeft = 1200;
			projectile.hostile = true;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 107);
			Gore.NewGore(projectile.position, -projectile.oldVelocity * 0.2f, 704, 1f);
			Gore.NewGore(projectile.position, -projectile.oldVelocity * 0.2f, 705, 1f);
			Gore.NewGore(projectile.position, -projectile.oldVelocity * 0.2f, 705, 1f);
			if (projectile.owner == Main.myPlayer)
			{
				int num220 = Main.rand.Next(5, 8);
				for (int num221 = 0; num221 < num220; num221++)
				{
					Vector2 value17 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
					value17.Normalize();
					value17 *= Main.rand.Next(10, 201) * 0.01f;
					int k = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, value17.X, value17.Y, mod.ProjectileType("NovaBottleCloud"), projectile.damage, 1f, projectile.owner, 0f, Main.rand.Next(-45, 1));
					Main.projectile[k].friendly = false;
				}
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.Kill();
		}
	}
}