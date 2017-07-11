using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class VoidKnifeExplosion : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.timeLeft = 420;
            projectile.width = 52;
            projectile.height = 52;
            projectile.melee = true;
            projectile.friendly = true;
            Main.projFrames[projectile.type] = 5;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override void AI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter > 6)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 5)
            {
                projectile.Kill();
            }
        }
    }
}