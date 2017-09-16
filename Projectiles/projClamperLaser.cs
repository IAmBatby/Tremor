using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class projClamperLaser : ModProjectile
	{
		Vector2 Offset
		{
			get
			{
				float X; float Y;
				switch ((int)Main.npc[(int)projectile.ai[1]].localAI[1])
				{
					case 1: X = -50; Y = 55; break;
					case 2: X = -30; Y = 60; break;
					case 3: X = 30; Y = 60; break;
					default: X = 50; Y = 55; break;
				}
				return new Vector2(X, Y);
			}
		}

		public override void SetDefaults()
		{

			projectile.width = 8;
			projectile.height = 10;
			projectile.timeLeft = 2;
			projectile.penetrate = -1;
			projectile.hostile = true;
			projectile.magic = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Clamper Laser");

		}

		public override void AI()
		{
			projectile.Center = Main.npc[(int)projectile.ai[0]].Center + Offset;
			projectile.localAI[0] += 1f;
			projectile.alpha = (int)projectile.localAI[1];
			if (projectile.localAI[0] > 45f)
			{
				projectile.damage = 0;
			}
			if (projectile.localAI[0] > 60f)
			{
				projectile.Kill();
			}
		}

		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
		{
			float point = 0f;
			Vector2 endPoint = Main.npc[(int)projectile.ai[1]].Center;
			return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), projectile.Center, endPoint, 4f, ref point);
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 endPoint = Main.npc[(int)projectile.ai[1]].Center;
			Vector2 unit = endPoint - projectile.Center;
			float length = unit.Length();
			unit.Normalize();
			for (float k = 0; k <= length; k += 8f)
			{
				Vector2 drawPos = projectile.Center + unit * k - Main.screenPosition;
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, new Color(255, 255, 255, 255), Helper.rotateBetween2Points(drawPos, endPoint), new Vector2(2, 2), 1f, SpriteEffects.None, 0f);
			}
			return false;
		}
	}
}
