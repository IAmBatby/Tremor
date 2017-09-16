using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class projGenie : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 38;
			projectile.height = 60;
			projectile.aiStyle = 26;
			projectile.penetrate = -1;
			projectile.timeLeft = 10;
			projectile.ignoreWater = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Genie");

		}

		public override void AI()
		{
			Lighting.AddLight(projectile.Center, new Vector3(0, 0, 1.5f));
			projectile.alpha = 0;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			spriteBatch.Draw(Main.projectileTexture[projectile.type], new Rectangle((int)(projectile.position.X - Main.screenPosition.X), (int)(projectile.position.Y - Main.screenPosition.Y), 38, 60), null, Color.White, 0, new Vector2(2, 2), ((Main.player[projectile.owner].position.X < projectile.position.X) ? SpriteEffects.FlipHorizontally : SpriteEffects.None), 0);
			return false;
		}
	}
}
