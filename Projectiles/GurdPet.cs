using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class GurdPet : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Bunny);

			aiType = ProjectileID.Bunny;
			Main.projFrames[projectile.type] = 8;
                        projectile.width = 46;
                        projectile.height = 38;
			Main.projPet[projectile.type] = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Gurd Pet");
       
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
				modPlayer.gurdPet = false;
			}
			if (modPlayer.gurdPet)
			{
				projectile.timeLeft = 2;
			}
		}
	}
}
