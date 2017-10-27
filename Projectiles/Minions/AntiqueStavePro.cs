using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles.Minions

{
	public class AntiqueStavePro : ModProjectile
    {
 
        public override void SetDefaults()
        {

            projectile.width = 30;
            projectile.height = 30;  
            projectile.hostile = false;  
            projectile.friendly = false;   
            projectile.ignoreWater = true; 
            Main.projFrames[projectile.type] = 1;
            projectile.timeLeft = 900;  
            projectile.penetrate = -1; 
            projectile.tileCollide = true; 
            projectile.sentry = true;
           ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;

        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Antique Soul");
       
    }

        public override void AI()
        {
            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
 
                float shootToX = target.position.X + target.width * 0.5f - projectile.Center.X;
                float shootToY = target.position.Y + target.height * 0.5f - projectile.Center.Y;
                float distance = (float)Math.Sqrt(shootToX * shootToX + shootToY * shootToY);

                if (distance < 520f && !target.friendly && target.active)
                {
                    if (projectile.ai[0] > 35f) // Time in (60 = 1 second) 
                    {
                        distance = 1.6f / distance;

                        shootToX *= distance * 3;
                        shootToY *= distance * 3;
                        int damage = 30; 
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, 122, damage, 0, Main.myPlayer, 0f, 0f);
                        projectile.ai[0] = 0f;
                    }
                }
            }
            projectile.ai[0] += 1f;
 
        }
    }
}
