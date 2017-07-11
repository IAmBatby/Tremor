using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
    public class projVultureFeather : ModProjectile
    {
        const int TileCollideDustType = DustID.Tin;
        const int TileCollideDustCount = 4;
        const float TileCollideDustSpeedMulti = 0.2f;

        public override void SetDefaults()
        {

            projectile.width = 14;
            projectile.height = 34;
            projectile.timeLeft = 36000;
            projectile.aiStyle = 0;
            projectile.penetrate = -1;
            projectile.hostile = true;
projectile.tileCollide = false;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Vulture Feather");
       
    }


        public override void AI()
        {
            projectile.rotation = Helper.rotateBetween2Points(projectile.position, projectile.position + projectile.velocity) + Helper.GradtoRad(270);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            for (int i = 0; i < TileCollideDustCount; i++)
                Dust.NewDust(projectile.position, projectile.width, projectile.height, TileCollideDustType, projectile.velocity.X * TileCollideDustSpeedMulti, projectile.velocity.Y * TileCollideDustSpeedMulti);
            return true;
        }
    }
}
