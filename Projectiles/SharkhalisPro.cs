using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles {
public class SharkhalisPro : ModProjectile
{
    public override void SetDefaults()
    {
			projectile.CloneDefaults(595);

			projectile.width = 100;
			projectile.height = 70;
			aiType = 595;
                                   Main.projFrames[projectile.type] = 28;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("SharkhalisPro");
       
    }


}}
