using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles.Alchemic
{
	public class ManaCloudPro : AlchemistProjectile
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

		public override void AI()
		{
			projectile.rotation = 0f;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			int newLife = Main.rand.Next(damage / 2) + 3;
			Main.player[projectile.owner].statMana += newLife;
			Main.player[projectile.owner].ManaEffect(newLife);
		}
	}
}