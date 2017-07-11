using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles {
public class LizardPro : ModProjectile
{
    public override void SetDefaults()
    {

        projectile.width = 26;
        projectile.height = 26;
        projectile.aiStyle = 2;
        projectile.timeLeft = 1200;
        projectile.penetrate = 5;
        ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
        ProjectileID.Sets.TrailingMode[projectile.type] = 2;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("LizardPro");
       
    }



		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}
			else
			{
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.velocity.Y = -oldVelocity.Y;
				}
			}
			return false;
		}

    public override void Kill(int timeLeft)
    {
            NPC.NewNPC((int)projectile.Center.X, (int)projectile.Center.Y, mod.NPCType("Lizard"));
    }


}}
