using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace Tremor.Projectiles.Minions
{
	public class StarfishPro : Minion
	{
		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.CloneDefaults(388);
			aiType = 388;

			projectile.width = 24;
			projectile.height = 24;
			Main.projFrames[projectile.type] = 1;
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
      DisplayName.SetDefault("StarfishPro");
       
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

		public override void CheckActive()
		{
			Player player = Main.player[projectile.owner];
			TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			if (player.dead)
			{
				modPlayer.starfishMinion = false;
			}
			if (modPlayer.starfishMinion)
			{
				projectile.timeLeft = 2;
			}
		}

	}
}
