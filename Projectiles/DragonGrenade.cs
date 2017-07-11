using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles {
public class DragonGrenade : ModProjectile
{
    public override void SetDefaults()
    {
			projectile.CloneDefaults(139);

			aiType = 139;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("DragonGrenade");
       
    }


}}
