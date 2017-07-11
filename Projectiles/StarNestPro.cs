using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles {
public class StarNestPro : ModProjectile
{
    public override void SetDefaults()
    {
			projectile.CloneDefaults(566);

			aiType = 566;
                        projectile.tileCollide = false;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("StarNest");
       
    }


    public override void AI()
    {
	projectile.rotation = (float)System.Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
        if(Main.rand.Next(1) == 0)
        {
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 57, projectile.velocity.X * 0.9f, projectile.velocity.Y * 0.9f);
        }
    }
}}
