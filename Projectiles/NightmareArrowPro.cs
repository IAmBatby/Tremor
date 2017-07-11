using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles {
//ported from my tAPI mod because I don't want to make artwork
public class NightmareArrowPro : ModProjectile
{
    public override void SetDefaults()
    {

        projectile.width = 16;
        projectile.height = 40;
        projectile.aiStyle = 1;
        projectile.friendly = true;
        projectile.penetrate = -2;
        projectile.tileCollide = true;
        projectile.melee = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Nightmare Arrow");
       
    }


    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
        if(Main.rand.Next(2) == 0)
        {
            target.AddBuff(mod.BuffType("DeathFear"), 480, false);
        }
    }

    public override void Kill(int timeLeft)
    {
        for(int k = 0; k < 5; k++)
        {
                       int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("NightmareFlame"), projectile.oldVelocity.X * 0.1f, projectile.oldVelocity.Y * 0.1f);
        }
        Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 0);
    }

    public override void OnHitPvp(Player target, int damage, bool crit)
    {
        if(Main.rand.Next(2) == 0)
        {
            target.AddBuff(mod.BuffType("DeathFear"), 480, false);
        }
    }
}}
