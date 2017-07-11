using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class TurtleSicklePro : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Turtle Sickle Pro");
        }

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.aiStyle = 18;
            projectile.alpha = 55;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 240;
            projectile.ignoreWater = true;
            aiType = 274;
        }
    }
}