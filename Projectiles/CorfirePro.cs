using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class CorfirePro : ModProjectile
	{
		public override void SetDefaults()
		{
                        projectile.CloneDefaults(553);

			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("CorfirePro");
       
    }


    public override void AI()
    {
	projectile.rotation = (float)System.Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
        if(Main.rand.Next(1) == 0)
        {
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 74, projectile.velocity.X * 0.9f, projectile.velocity.Y * 0.9f);
        }
    }
    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
        if(Main.rand.Next(2) == 0)
        {
            target.AddBuff(39, 280, false);
        }
    }

    public override void OnHitPvp(Player target, int damage, bool crit)
    {
        if(Main.rand.Next(2) == 0)
        {
            target.AddBuff(39, 280, false);
        }
    }
	}
}
