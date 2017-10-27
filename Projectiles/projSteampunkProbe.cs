using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class projSteampunkProbe : ModProjectile
	{
		const int ShootType = ProjectileID.HeatRay;
		const float ShootRange = 600.0f;
		const float ShootKN = 1.0f;
		const int ShootRate = 30;
		const int ShootCount = 2;
		const float ShootSpeed = 20f;
		const int spread = 45;
		const float spreadMult = 0.045f;

		const int STATIC_DAMAGE = 30; 
									  // (10 * ((int)Main.player[projectile.owner].magicDamage + (int)Main.player[projectile.owner].meleeDamage + (int)Main.player[projectile.owner].minionDamage + (int)Main.player[projectile.owner].rangedDamage + (int)Main.player[projectile.owner].thrownDamage)) + 15
									  

		int TimeToShoot = ShootRate;

		public override void SetDefaults()
		{

			projectile.width = 32;
			projectile.height = 32;
			projectile.timeLeft = 6;
			projectile.tileCollide = false;
			projectile.aiStyle = 54;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Steampunk Probe");

		}

		public override void AI()
		{
			projectile.ai[0] = -1;
			projectile.ai[1] = 0;
			if (--TimeToShoot <= 0)
			{
				TimeToShoot = ShootRate;
				int Target = GetTarget();
				if (Target != -1) Shoot(Target, GetDamage());
			}
		}

		int GetTarget()
		{
			int Target = -1;
			for (int k = 0; k < Main.npc.Length; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].Distance(projectile.Center) <= ShootRange && Collision.CanHitLine(projectile.Center, 4, 4, Main.npc[k].Center, 4, 4))
				{
					Target = k;
					break;
				}
			}
			return Target;
		}

		int GetDamage()
		{
			if (STATIC_DAMAGE == -1)
				return (10 * ((int)Main.player[projectile.owner].magicDamage + (int)Main.player[projectile.owner].meleeDamage + (int)Main.player[projectile.owner].minionDamage + (int)Main.player[projectile.owner].rangedDamage + (int)Main.player[projectile.owner].thrownDamage)) + 15;
			return STATIC_DAMAGE;
		}

		void Shoot(int Target, int Damage)
		{
			Vector2 velocity = Helper.VelocityToPoint(projectile.Center, Main.npc[Target].Center, ShootSpeed);
			for (int l = 0; l < ShootCount; l++)
			{
				velocity.X = velocity.X + Main.rand.Next(-spread, spread + 1) * spreadMult;
				velocity.Y = velocity.Y + Main.rand.Next(-spread, spread + 1) * spreadMult;
				int i = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, velocity.X, velocity.Y, ShootType, Damage, ShootKN, projectile.owner);
			}
		}
	}
}
