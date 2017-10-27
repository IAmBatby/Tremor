using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class FungusBlueSword : ModProjectile
	{
		const float RotationSpeed = 0.05f;
		const float Distanse = 100;

		float Rotation;

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
			DisplayName.SetDefault("Fungus Blue Sword");
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextBool(3))
			{
				target.AddBuff(31, 180, false);
			}
		}

		public override void AI()
		{
			Rotation += RotationSpeed;
			projectile.Center = Helper.PolarPos(Main.LocalPlayer.Center, Distanse, MathHelper.ToRadians(Rotation));
			projectile.rotation = Helper.rotateBetween2Points(Main.LocalPlayer.Center, projectile.Center) - MathHelper.ToRadians(90);
		}

		public override bool? CanHitNPC(NPC target)
		{
			return !target.friendly;
		}
	}
}
