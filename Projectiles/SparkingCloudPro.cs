using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class SparkingCloudPro : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 16;
			projectile.height = 16;
			projectile.magic = true;
			projectile.penetrate = 8;
			projectile.aiStyle = 92;
			projectile.hostile = true;
			projectile.timeLeft = 600;
			projectile.light = 1.0f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("SparkingCloudPro");

		}

		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			if (Main.rand.NextBool(2))
			{
				target.AddBuff(24, 180, false);
			}
		}

	}
}
