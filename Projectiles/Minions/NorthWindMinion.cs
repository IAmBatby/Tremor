using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace Tremor.Projectiles.Minions
{
	public class NorthWindMinion : Minion
	{

        const int ShootRate = 30; // ������� �������� (1 ������� = 60��.)
        const float ShootDistance = 300f; // ��������� ��������
        const float ShootSpeed = 12f; // �������� �������
        const int ShootDamage = 20; // ���� �������
        const float ShootKnockback = 2; // ������ �������
        int ShootType = 118; // ��� �������� (���� �� ��������� �����)
        int TimeToShoot = ShootRate;

		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.CloneDefaults(317);
                         projectile.aiStyle = 62;

			projectile.width = 20;
			projectile.height = 30;
			Main.projFrames[projectile.type] = 8;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = 1;
			projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			projectile.ignoreWater = true;
                                   projectile.tileCollide = false;
                        ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("North");
       
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
            base.AI();
        }

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.tileCollide = false;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.tileCollide = false;
				}
      return false;
		}

		public override void CheckActive()
		{
			Player player = Main.player[projectile.owner];
			TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			if (player.dead)
			{
				modPlayer.northWind = false;
			}
			if (modPlayer.northWind)
			{
				projectile.timeLeft = 2;
			}
		}

	}
}
