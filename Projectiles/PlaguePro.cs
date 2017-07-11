using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class PlaguePro : ModProjectile
{
    public override void SetDefaults()
    {
			projectile.CloneDefaults(566);

			aiType = 566;
                        projectile.tileCollide = false;
            Main.projFrames[projectile.type] = 4;
            projectile.width = 20;
            projectile.height = 16;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("PlaguePro");
       
    }


		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}


        public override void Kill(int timeLeft)
        {
                    int ses=Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("PlagueBlast"), projectile.damage * 2, 0.7f, projectile.owner);
                    Main.projectile[ses].scale = projectile.scale;
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
                        {projectile.frame = 0;}


        }
}}
