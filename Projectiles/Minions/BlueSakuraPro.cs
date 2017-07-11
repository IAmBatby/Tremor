using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace Tremor.Projectiles.Minions
{
	public class BlueSakuraPro : Minion
	{
		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.CloneDefaults(388);
			aiType = 388;

			projectile.width = 18;
			projectile.height = 18;
			Main.projFrames[projectile.type] = 4;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = 1;
			projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			projectile.ignoreWater = true;
                        projectile.tileCollide = false;
                        ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Blue Sakura");
       
    }


		public override bool OnTileCollide(Vector2 oldVelocity)
		{
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.velocity.Y = oldVelocity.Y;
				}
      return false;
		}

    public override void AI()
    {
        if(Main.rand.Next(8) == 0)
        {
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 41, projectile.velocity.X * 0.9f, projectile.velocity.Y * 0.9f);
        }
    }

		public override void CheckActive()
		{
			Player player = Main.player[projectile.owner];
			TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			if (player.dead)
			{
				modPlayer.blueSakuraMinion = false;
			}
			if (modPlayer.blueSakuraMinion)
			{
				projectile.timeLeft = 2;
			}
		}

	}
}
