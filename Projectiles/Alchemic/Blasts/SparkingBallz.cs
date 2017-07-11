using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles.Alchemic.Blasts
{
	public class SparkingBallz : ModProjectile
{
    public override void SetDefaults()
    {
        projectile.aiStyle = 1;
  			projectile.width = 54;
			projectile.height = 54;
                        projectile.friendly = true;
                        projectile.hostile = false;
            Main.projFrames[projectile.type] = 4;
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

        public override void AI()
        {													
			projectile.frameCounter++;
			if (projectile.frameCounter > 2)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
			}
			if (projectile.frame >= 4)
                        {
				projectile.frame = 0;}
        }

        public override void Kill(int timeLeft)
        {
                    int ses=Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("SparkingBlast"), projectile.damage * 2, 0.7f, projectile.owner);
                    Main.projectile[ses].scale = projectile.scale;
        }
}}