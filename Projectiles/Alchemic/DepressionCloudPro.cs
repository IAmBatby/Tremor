using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles.Alchemic
{
	public class DepressionCloudPro : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 40;
			projectile.height = 40;
			projectile.magic = true;
			projectile.penetrate = 8;
			projectile.aiStyle = 92;
			projectile.friendly = true;
			projectile.timeLeft = 600;
		}



		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("Sad"), 180, false);
		}

	}
}