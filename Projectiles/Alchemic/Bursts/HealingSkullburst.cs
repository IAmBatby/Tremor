using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles.Alchemic.Bursts
{
	public class HealingSkullburst : ModProjectile
{
    public override void SetDefaults()
    {
              projectile.timeLeft = 420;
			projectile.width = 52;
			projectile.height = 52;
                        projectile.friendly = true;
            Main.projFrames[projectile.type] = 12;
				projectile.tileCollide = false;
				projectile.penetrate = -1;
    }

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}
		
				public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (Main.rand.Next(1, 101) <= Main.player[projectile.owner].GetModPlayer<MPlayer>(mod).alchemistCrit)
            {
                crit = true;
            }
        }

	public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
            if (Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("ConcentratedTinctureBuff")))
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
        public override void AI()
        {													
			projectile.frameCounter++;
			if (projectile.frameCounter > 2)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
			}
			if (projectile.frame >= 7)
                        {projectile.velocity.X = 0f; projectile.velocity.Y = 0f;}
			if (projectile.frame >= 12)
                        {projectile.Kill();}
        }

}}