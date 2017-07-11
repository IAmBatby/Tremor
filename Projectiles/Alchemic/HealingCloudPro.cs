using Terraria;
using System.Linq;
using Terraria.ModLoader;

namespace Tremor.Projectiles.Alchemic
{
	public class HealingCloudPro : ModProjectile
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
            if (Main.player[Main.myPlayer].buffType.Contains<int>(mod.BuffType("ConcentratedTinctureBuff")))
            {
		int newLife = 2;
		Main.player[projectile.owner].statLife += newLife;
		Main.player[projectile.owner].HealEffect(newLife);
            }
             else
            {
		int newLife = 1;
		Main.player[projectile.owner].statLife += newLife;
		Main.player[projectile.owner].HealEffect(newLife);
            }
	}

	}
}