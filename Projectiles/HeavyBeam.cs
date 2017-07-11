using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tremor.Projectiles
{
    public class HeavyBeam : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(455);

	    aiType = 455;
            projectile.width = 16;
            projectile.height = 16;
            projectile.timeLeft = 2;
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.alpha = 100;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Heavy Beam");
       
    }

    }
}
