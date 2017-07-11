using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class MudDoll : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.MiniMinotaur);

			aiType = ProjectileID.MiniMinotaur;
			Main.projFrames[projectile.type] = 10;
                        projectile.width = 24;
                        projectile.height = 34;
			Main.projPet[projectile.type] = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Mud Doll");
       
    }


		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			player.bunny = false; // Relic from aiType
			return true;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			if (player.dead)
			{
				modPlayer.mudDoll = false;
			}
			if (modPlayer.mudDoll)
			{
				projectile.timeLeft = 2;
			}
		}
	}
}
