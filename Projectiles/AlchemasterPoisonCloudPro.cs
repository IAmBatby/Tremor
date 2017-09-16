using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class AlchemasterPoisonCloudPro : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 40;
			projectile.height = 40;
			projectile.magic = true;
			projectile.penetrate = 8;
			projectile.aiStyle = 92;
			projectile.hostile = true;
			projectile.timeLeft = 600;
			projectile.light = 1.0f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("PoisonCloudPro");

		}

		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			if (Main.rand.NextBool())
			{
				target.AddBuff(20, 180, false);
			}
		}

	}
}
