using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace Tremor.Projectiles.Minions
{
	public class NecronomiconPro : Minion
	{
		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.CloneDefaults(317);
			aiType = 317;

			projectile.width = 20;
			projectile.height = 30;
			Main.projFrames[projectile.type] = 8;
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
      DisplayName.SetDefault("NecronomiconPro");
       
    }

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.tileCollide = false;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.tileCollide = false;
				}
      return false;
		}

		public override void CheckActive()
		{
			Player player = Main.player[projectile.owner];
			TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			if (player.dead)
			{
				modPlayer.skeletonMinion = false;
			}
			if (modPlayer.skeletonMinion)
			{
				projectile.timeLeft = 2;
			}
		}

	}
}
