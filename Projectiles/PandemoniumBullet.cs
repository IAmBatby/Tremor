using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class PandemoniumBullet : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(14);

			projectile.light = 0.5f;
			projectile.width = 1;
			projectile.height = 1;
			projectile.extraUpdates = 1;
			projectile.alpha = 255;
			projectile.friendly = true;
			projectile.ranged = true;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
			aiType = ProjectileID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pandemonium Bullet");

		}

		const int ShootDirection = 7;
		public override void Kill(int timeLeft)
		{
			int a = Projectile.NewProjectile(projectile.position.X + 40, projectile.position.Y + 40, -ShootDirection, 0, 711, 50, 1f, Main.myPlayer, 0f, 0f);
			int b = Projectile.NewProjectile(projectile.position.X + 40, projectile.position.Y + 40, ShootDirection, 0, 711, 50, 1f, Main.myPlayer, 0f, 0f);
			int c = Projectile.NewProjectile(projectile.position.X + 40, projectile.position.Y + 40, 0, ShootDirection, 711, 50, 1f, Main.myPlayer, 0f, 0f);
			int d = Projectile.NewProjectile(projectile.position.X + 40, projectile.position.Y + 40, 0, -ShootDirection, 711, 50, 1f, Main.myPlayer, 0f, 0f);
			int e = Projectile.NewProjectile(projectile.position.X + 40, projectile.position.Y + 40, -ShootDirection, -ShootDirection, 711, 50, 1f, Main.myPlayer, 0f, 0f);
			int f = Projectile.NewProjectile(projectile.position.X + 40, projectile.position.Y + 40, ShootDirection, -ShootDirection, 711, 50, 1f, Main.myPlayer, 0f, 0f);
			int g = Projectile.NewProjectile(projectile.position.X + 40, projectile.position.Y + 40, -ShootDirection, ShootDirection, 711, 50, 1f, Main.myPlayer, 0f, 0f);
			int h = Projectile.NewProjectile(projectile.position.X + 40, projectile.position.Y + 40, ShootDirection, ShootDirection, 711, 50, 1f, Main.myPlayer, 0f, 0f);

			Main.projectile[a].friendly = true;
			Main.projectile[b].friendly = true;
			Main.projectile[c].friendly = true;
			Main.projectile[d].friendly = true;
			Main.projectile[e].friendly = true;
			Main.projectile[f].friendly = true;
			Main.projectile[g].friendly = true;
			Main.projectile[h].friendly = true;

			Main.projectile[a].tileCollide = false;
			Main.projectile[b].tileCollide = false;
			Main.projectile[c].tileCollide = false;
			Main.projectile[d].tileCollide = false;
			Main.projectile[e].tileCollide = false;
			Main.projectile[f].tileCollide = false;
			Main.projectile[g].tileCollide = false;
			Main.projectile[h].tileCollide = false;

			Main.projectile[a].timeLeft = 120;
			Main.projectile[b].timeLeft = 120;
			Main.projectile[c].timeLeft = 120;
			Main.projectile[d].timeLeft = 120;
			Main.projectile[e].timeLeft = 120;
			Main.projectile[f].timeLeft = 120;
			Main.projectile[g].timeLeft = 120;
			Main.projectile[h].timeLeft = 120;
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}
	}
}
