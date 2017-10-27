using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class BerserkerPro : ModProjectile
	{
		const float RotationSpeed = 0.05f;
		const float Distanse = 48;

		float Rotation;

		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 34;
			projectile.timeLeft = 6;
			projectile.melee = true;
			projectile.aiStyle = -1;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Berserker Sword");
		}

		public override void AI()
		{
			Rotation += RotationSpeed;
			projectile.Center = Helper.PolarPos(Main.player[(int)projectile.ai[0]].Center, Distanse, MathHelper.ToRadians(Rotation));
			projectile.rotation = Helper.rotateBetween2Points(Main.player[(int)projectile.ai[0]].Center, projectile.Center) - MathHelper.ToRadians(90);
		}

		public override bool? CanHitNPC(NPC target)
		{
			return !target.friendly;
		}
	}
}
