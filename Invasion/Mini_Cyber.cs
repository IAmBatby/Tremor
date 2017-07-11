using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Invasion
{
	public class Mini_Cyber : Minion
	{
        const int ShootRate = 30;
        const float ShootDistance = 450f;
        const float ShootSpeed = 20f;
        const int ShootDamage = 40;
        const float ShootKnockback = 4;

        int TimeToShoot = ShootRate;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mini-Cyber");
		}

        public override void SetDefaults()
		{
            projectile.netImportant = true;
            projectile.CloneDefaults(388);
            aiType = 388;
            projectile.light = 2f;
            projectile.width = 26;
			projectile.height = 30;
			Main.projFrames[projectile.type] = 3;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = 1;
			projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			projectile.ignoreWater = true;
                        projectile.tileCollide = false;
                        ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.velocity.Y = oldVelocity.Y;
				}
      return false;
		}
		public override void CheckActive()
		{
			Player player = Main.player[projectile.owner];
			TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			if (player.dead)
			{
				modPlayer.miniCyber = false;
			}
			if (modPlayer.miniCyber)
			{
				projectile.timeLeft = 2;
			}
		}


        void Shoot()
        {
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
                if (Main.mouseLeft)
                    if ((int)(Main.time % 60) == 0)
                    {
                        Player player = Main.player[Main.myPlayer];
                        Vector2 Velocity = Helper.VelocityToPoint(projectile.Center, Main.npc[NearestNPC].Center, ShootSpeed);
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Velocity.X, Velocity.Y, mod.ProjectileType("CyberLaser"), ShootDamage, ShootKnockback, projectile.owner);
                    }
        }

        public override void AI()
        {
            Shoot();
            base.AI();
        }
    }
}