using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Ice.Items {
public class FrostLancePro : ModProjectile
{
    public override void SetDefaults()
    {
			projectile.CloneDefaults(66);
			aiType = 66;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Frost Lance");
    }


}}
