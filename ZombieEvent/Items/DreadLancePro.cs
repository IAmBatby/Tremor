using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Items {
public class DreadLancePro : ModProjectile
{
    public override void SetDefaults()
    {
			projectile.CloneDefaults(66);
			aiType = 66;
    }

    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
        if(Main.rand.Next(1) == 0)
        {
            target.AddBuff(39, 180, false);
        }
    }

}}
