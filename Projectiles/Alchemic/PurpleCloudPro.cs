using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles.Alchemic
{
	public class PurpleCloudPro : ModProjectile
	{
		public override void SetDefaults()
		{
  			projectile.width = 16;
			projectile.height = 16;
			projectile.magic = true;
			projectile.penetrate = 8;
                        projectile.aiStyle = 92;
                        projectile.friendly = true;
			projectile.timeLeft = 600;
		}
		
		        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (Main.rand.Next(1, 101) <= Main.player[projectile.owner].GetModPlayer<MPlayer>(mod).alchemistCrit)
            {
                crit = true;
            }
        }

        public override void AI()
        {
            projectile.rotation = 0f;
        }


    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
        if(Main.rand.Next(3) == 0)
        {
            target.AddBuff(70, 180, false);
        }

    }

	}
}