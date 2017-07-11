using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace Tremor.Projectiles.Minions
{
	public class AncientPredator : Minion
	{
		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.CloneDefaults(388);
			aiType = 388;

			projectile.width = 36;
			projectile.height = 34;
			Main.projFrames[projectile.type] = 3;
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
      DisplayName.SetDefault("AncientPredator");
       
    }


    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
            target.AddBuff(20, 80, false);
            target.AddBuff(70, 80, false);
            target.AddBuff(39, 80, false);
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
				modPlayer.ancientPredator = false;
			}
			if (modPlayer.ancientPredator)
			{
				projectile.timeLeft = 2;
			}
		}

	}
}
