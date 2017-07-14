using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles.Alchemic
{
	public class HealthSupportCloudPro : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 40;
			projectile.height = 40;
			projectile.penetrate = 8;
			projectile.aiStyle = 92;
			projectile.hostile = true;
			projectile.timeLeft = 600;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (Main.rand.Next(1, 101) <= Main.player[projectile.owner].GetModPlayer<MPlayer>(mod).alchemistCrit)
			{
				crit = true;
			}
		}

		public override void AI()
		{
			projectile.rotation = 0f;
		}


		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			int newLife = Main.rand.Next(5) + 5;
			target.statLife += newLife;
			target.HealEffect(newLife);
		}

	}
}