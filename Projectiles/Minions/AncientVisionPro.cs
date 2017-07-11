using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles.Minions
{
	public class AncientVisionPro : Minion
	{

        const int ShootRate = 30; // ����� ����५� (1 ᥪ㭤� = 60��.)
        const float ShootDistance = 300f; // ���쭮��� ��५��
        const float ShootSpeed = 12f; // ������� ᭠�鸞
        const int ShootDamage = 80; // �஭ ᭠�鸞
        const float ShootKnockback = 2; // ���� ᭠�鸞
        int ShootType = 122; // ��� ����५� (�᫨ �� �����쭮� �ન)
        int TimeToShoot = ShootRate;

		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.CloneDefaults(317);
                         projectile.aiStyle = 62;

			projectile.width = 44;
			projectile.height = 38;
			Main.projFrames[projectile.type] = 1;
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
      DisplayName.SetDefault("Ancient Vision");
       
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

public override Color? GetAlpha(Color lightColor) 
{ 
return Color.White; 
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
				modPlayer.ancientVision = false;
			}
			if (modPlayer.ancientVision)
			{
				projectile.timeLeft = 2;
			}
		}

	}
}
