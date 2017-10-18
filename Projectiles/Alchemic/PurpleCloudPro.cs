using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles.Alchemic
{
	public class PurpleCloudPro : AlchemistProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.magic = true;
			projectile.penetrate = 8;
			projectile.aiStyle = 92;
			projectile.friendly = true;
			projectile.timeLeft = 600;
		}

		public override void AI()
		{
			projectile.rotation = 0f;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextBool(3))
			{
				target.AddBuff(70, 180, false);
			}
		}
	}
}