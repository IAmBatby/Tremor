using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{

	public class NanoJackhammerPro : ModProjectile
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
        projectile.ownerHitCheck = true;
        projectile.melee = true;
        Main.projFrames[projectile.type] = 3;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Nano Jackhammer");
       
    }

}}
