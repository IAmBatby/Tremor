using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles {
public class HornedWarhammerPro : ModProjectile
{
    public override void SetDefaults()
    {
			projectile.CloneDefaults(595);

			aiType = 595;
        projectile.width = 70;
        projectile.light = 0.8f;
        projectile.height = 70;
                                   Main.projFrames[projectile.type] = 28;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("HornedWarhammerPro");
       
    }


}}
