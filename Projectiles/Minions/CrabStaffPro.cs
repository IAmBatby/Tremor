using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace Tremor.Projectiles.Minions
{
	public class CrabStaffPro : Minion
	{
		public override void SetDefaults()
		{

            projectile.width = 32;
            projectile.height = 24;
            projectile.netImportant = true;
            projectile.friendly = true;
            projectile.minionSlots = 1;
            projectile.aiStyle = 26;
            projectile.timeLeft = 18000;
            Main.projFrames[projectile.type] = 1;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            projectile.penetrate = -1;
            projectile.timeLeft *= 5;
            projectile.minion = true;
            aiType = 266;
            projectile.tileCollide = false;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Crab Staff");
       
    }


public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) 
{ 
fallThrough = false; 
return true; 
}

        public override void CheckActive()
		{
			Player player = Main.player[projectile.owner];
            TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			if (player.dead)
			{
				modPlayer.crabStaff = false;
			}
			if (modPlayer.crabStaff)
			{
				projectile.timeLeft = 2;
			}
		}


        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.penetrate == 0)
            {
                projectile.Kill();
            }
            return false;
        }
    }
}
