using Microsoft.Xna.Framework;
using Terraria;

namespace Tremor.Projectiles.Minions
{
	public class GoblinStaffPro : Minion
	{
		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.CloneDefaults(394);
			aiType = 394;

			projectile.width = 26;
			projectile.height = 30;
			Main.projFrames[projectile.type] = 4;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = 1;
			projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			projectile.ignoreWater = true;
                        projectile.tileCollide = false;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Goblin Staff");
       
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
				modPlayer.goblinMinion = false;
			}
			if (modPlayer.goblinMinion)
			{
				projectile.timeLeft = 2;
			}
		}

	}
}
