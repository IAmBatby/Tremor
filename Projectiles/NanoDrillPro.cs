using Terraria.ModLoader;

namespace Tremor.Projectiles
{

	public class NanoDrillPro : ModProjectile
{
    public override void SetDefaults()
    {

        projectile.width = 22;
        projectile.height = 22;
        projectile.aiStyle = 20;
        projectile.friendly = true;
        projectile.penetrate = -1;
        projectile.tileCollide = false;
        projectile.hide = true;
        projectile.frame = 0;
        projectile.ownerHitCheck = true;
        projectile.melee = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Nano Drill");
       
    }

}}
