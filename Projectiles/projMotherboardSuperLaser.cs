using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class projMotherboardSuperLaser : ModProjectile
	{
		const int XOffsetMax = 300;
		const int XOffsetStep = 10;
		const int DustCount = 5;
		Color LaserColor = Color.Purple;
		int XOffsetNow;

		Vector2 endPoint
		{
			get
			{
				float X = Main.npc[(int)projectile.ai[0]].Center.X + XOffsetNow;
				float Y = Main.npc[(int)projectile.ai[0]].Center.Y;
				while (!WorldGen.SolidTile((int)X / 16, (int)Y / 16))
					if (Y + 8 > 8000)
						break;
					else
						Y += 8;
				return new Vector2(X, Y);
			}
		}

		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.timeLeft = 2;
			projectile.penetrate = -1;
			projectile.hostile = true;
			projectile.magic = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.alpha = 100;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Motherboard Super Laser");
		}
		
		bool flag = true;
		public override void AI()
		{
			if (flag)
			{
				flag = false;
				XOffsetNow = (projectile.ai[1] != 0) ? XOffsetMax : -XOffsetMax;
			}
			projectile.Center = new Vector2(Main.npc[(int)projectile.ai[0]].Center.X - 4, Main.npc[(int)projectile.ai[0]].Center.Y + 88f);
			//for (int i = 0; i < DustCount; i++)
			//	Dust.NewDust(new Vector2(endPoint.X - 10, endPoint.Y + 10), 20, 20, DustID.Shadowflame);
			if (projectile.ai[1] != 0)
			{
				XOffsetNow -= XOffsetStep;
				if (XOffsetNow <= -XOffsetMax)
					projectile.active = false;
				else
					projectile.timeLeft = 2;
				return;
			}
			XOffsetNow += XOffsetStep;
			if (XOffsetNow >= XOffsetMax)
				projectile.active = false;
			else
				projectile.timeLeft = 2;
		}

		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
		{
			float point = 0f;
			return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), projectile.Center, endPoint, 4f, ref point);
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			for (int i = 0; i < DustCount; i++)
				Dust.NewDust(new Vector2(endPoint.X - 10, endPoint.Y + 10), 20, 20, DustID.Shadowflame);

			PlayCollidingSound();

			return base.OnTileCollide(oldVelocity);
		}

		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			PlayCollidingSound();
		}

		private void PlayCollidingSound()
		{
			var zapSound = new LegacySoundStyle(SoundID.Trackable, TremorUtils.GetIdForSoundName($"dd2_sky_dragons_fury_circle_{Main.rand.Next(3)}"));
			Main.PlayTrackedSound(zapSound.WithPitchVariance(Main.rand.NextFloat()).WithVolume(Main.soundVolume * 1.5f));
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 unit = endPoint - projectile.Center;
			float length = unit.Length();
			unit.Normalize();
			for (float k = 0; k <= length; k += 1f)
			{
				Vector2 drawPos = projectile.Center + unit * k - Main.screenPosition;
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, new Color(LaserColor.R, LaserColor.G, LaserColor.B, projectile.alpha), Helper.rotateBetween2Points(Main.npc[(int)projectile.ai[0]].Center, endPoint), new Vector2(2, 2), 1f, SpriteEffects.None, 0f);
			}
			return false;
		}
	}
}
