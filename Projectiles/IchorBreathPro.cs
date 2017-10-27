using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{

	public class IchorBreathPro : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 22;
			projectile.height = 22;
			projectile.aiStyle = 6;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.tileCollide = true;
			projectile.magic = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ichor Breath Pro");

		}

		public override void AI()
		{
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 64, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1.9f);
			Main.dust[dust].noGravity = true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextBool(5))
			{
				target.AddBuff(69, 60);
			}
		}

		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			if (Main.rand.NextBool(5))
			{
				target.AddBuff(69, 60);
			}
		}
	}
}
