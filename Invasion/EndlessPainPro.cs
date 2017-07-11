using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Invasion
{
	public class EndlessPainPro : ModProjectile
	{

		const int ShootRate = 20; // ����� ����५� (1 ᥪ㭤� = 60��.)
		const float ShootDistance = 300f; // ���쭮��� ��५��
		const float ShootSpeed = 12f; // ������� ᭠�鸞
		const int ShootDamage = 210; // �஭ ᭠�鸞
		const float ShootKnockback = 2; // ���� ᭠�鸞
		int ShootType = 496; // ��� ����५� (�᫨ �� �����쭮� �ન)
		int TimeToShoot = ShootRate;
		string ShootTypeMod;

		public override void SetDefaults()
		{

			projectile.friendly = true;
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 0;
			Main.projFrames[projectile.type] = 4;
			projectile.timeLeft = 1200;
			projectile.penetrate = -1;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Pain");

		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 27, projectile.oldVelocity.X * 0.1f, projectile.oldVelocity.Y * 0.1f);
			}
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 109);
		}

		void Shoot()
		{
			if (--TimeToShoot <= 0)
			{
				TimeToShoot = ShootRate;
				if (ShootType == -1)
					ShootType = mod.ProjectileType(ShootTypeMod);

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
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 27, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 136, default(Color), 0.9f);
			Main.dust[dust].noGravity = true;

			if (projectile.frameCounter < 5)
				projectile.frame = 0;
			else if (projectile.frameCounter >= 5 && projectile.frameCounter < 10)
				projectile.frame = 1;
			else if (projectile.frameCounter >= 10 && projectile.frameCounter < 15)
				projectile.frame = 2;
			else if (projectile.frameCounter >= 15 && projectile.frameCounter < 20)
				projectile.frame = 3;
			else
				projectile.frameCounter = 0;
			projectile.frameCounter++;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}


	}
}
