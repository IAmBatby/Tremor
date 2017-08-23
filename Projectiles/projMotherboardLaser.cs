using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class projMotherboardLaser : ModProjectile
	{
		const float YOffset = 95f;
		Color LaserColor = Color.Purple;

		public override void SetDefaults()
		{
			projectile.width = 2;
			projectile.height = 2;
			projectile.timeLeft = 30;
			projectile.penetrate = -1;
			projectile.hostile = true;
			projectile.magic = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Motherboard Laser");
		}
		
		public override void AI()
		{
			projectile.Center = new Vector2(Main.npc[(int)projectile.ai[0]].Center.X, Main.npc[(int)projectile.ai[0]].Center.Y + ((projectile.localAI[1] == 1) ? YOffset : 0));
			projectile.localAI[0] += 1f;
			projectile.alpha = (int)projectile.localAI[0] * 4;
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

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			PlayZapSound();
			return base.OnTileCollide(oldVelocity);
		}

		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			PlayZapSound();
		}

		private void PlayZapSound()
		{
			var zapSound = new LegacySoundStyle(SoundID.Trackable, TremorUtils.GetIdForSoundName($"dd2_lightning_bug_zap_{Main.rand.Next(3)}"));
			Main.PlayTrackedSound(zapSound.WithPitchVariance(Main.rand.NextFloat() * .5f).WithVolume(Main.soundVolume * 0.5f));
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 endPoint = Main.npc[(int)projectile.ai[1]].Center;
			Vector2 unit = endPoint - projectile.Center;
			float length = unit.Length();
			unit.Normalize();
			for (float k = 0; k <= length; k += 5f)
			{
				Vector2 drawPos = projectile.Center + unit * k - Main.screenPosition;
				Color alpha = new Color(LaserColor.R, LaserColor.G, LaserColor.B, projectile.alpha);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, alpha, MathHelper.ToDegrees(Main.rand.Next(0, 181)), new Vector2(2, 2), 1f, SpriteEffects.None, 0f);
			}
			return false;
		}
	}
}
