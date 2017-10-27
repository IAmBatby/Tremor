using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class DesertSigil : ModProjectile
	{
		const int ShootRate = 22; 
		const float ShootDistance = 300f; 
		const float ShootSpeed = 25f; 
		const int ShootDamage = 38; 
		const float ShootKnockback = 10; 
		int ShootType = 122; 
		int TimeToShoot = ShootRate;

		public override void SetDefaults()
		{
			projectile.CloneDefaults(226);

			projectile.width = 34;
			Main.projFrames[projectile.type] = 1;
			projectile.height = 34;
			projectile.timeLeft = 5;
			projectile.aiStyle = 62;
			aiType = 226;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Desert Sigil");

		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}

		void Shoot()
		{
			if (--TimeToShoot <= 0)
			{
				TimeToShoot = ShootRate;

				float NearestNPCDist = ShootDistance;
				int NearestNPC = -1;
				foreach (NPC npc in Main.npc)
				{
					if (!npc.active)
						continue;
					if (npc.friendly || npc.lifeMax <= 5)
						continue;
					if (NearestNPCDist == -1 || npc.Distance(projectile.Center) < NearestNPCDist && Collision.CanHitLine(projectile.Center, 16, 16, npc.Center, 16, 16))
					{
						NearestNPCDist = npc.Distance(projectile.Center);
						NearestNPC = npc.whoAmI;
					}
				}
				if (NearestNPC == -1)
					return;
				Vector2 Velocity = Helper.VelocityToPoint(projectile.Center, Main.npc[NearestNPC].Center, ShootSpeed);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Velocity.X, Velocity.Y, ShootType, ShootDamage, ShootKnockback, projectile.owner);
			}
		}

		public override void AI()
		{
			Shoot();
			projectile.ai[1] = 1;
			base.AI();
			if (projectile.localAI[0] == 0f)
			{
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 20);
			}
			projectile.localAI[0] += 1f;
			if (projectile.localAI[0] > 3f)
			{
				int num90 = 1;
				if (projectile.localAI[0] > 5f)
				{
					num90 = 2;
				}
				if (projectile.wet && !projectile.lavaWet)
				{
					projectile.Kill();
				}
			}
		}

	}
}
