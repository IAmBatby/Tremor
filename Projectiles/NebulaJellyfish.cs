using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class NebulaJellyfish : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.ZephyrFish);

			aiType = ProjectileID.ZephyrFish;
			Main.projFrames[projectile.type] = 4;
                        projectile.width = 34;
                        projectile.height = 34;
			Main.projPet[projectile.type] = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Nebula Jellyfish");
       
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
				modPlayer.nebulaJellyfish = false;
			}
			if (modPlayer.nebulaJellyfish)
			{
				projectile.timeLeft = 2;
			}
		}
	}
}
