using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace Tremor.Projectiles
{
	public class FungusYellowSword : ModProjectile
	{
		const float RotationSpeed = 0.08f;
		const float Distanse = 100;

		float Rotation = 0;

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}
		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 44;
			projectile.timeLeft = 6;
			projectile.melee = true;
			projectile.aiStyle = -1;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fungus Yellow Sword");
		}

		public override void AI()
		{
			Rotation += RotationSpeed;
			projectile.Center = Helper.PolarPos(Main.LocalPlayer.Center, Distanse, Helper.GradtoRad(Rotation));
			projectile.rotation = Helper.rotateBetween2Points(Main.LocalPlayer.Center, projectile.Center) - Helper.GradtoRad(90);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(4) == 0)
			{
				target.AddBuff(72, 180, false);
			}
		}

		public override bool? CanHitNPC(NPC target)
		{
			return !target.friendly;
		}
	}
}
