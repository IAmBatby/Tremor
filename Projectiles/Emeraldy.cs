using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class Emeraldy : ModProjectile
	{
		public override void SetDefaults()
		{
			//Player player = new Player();
			projectile.aiStyle = 26;

			projectile.width = 24;
			projectile.height = 20;
			projectile.netImportant = true;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			aiType = 380;
			ProjectileID.Sets.TrailingMode[projectile.type] = 2;
			ProjectileID.Sets.Homing[projectile.type] = true;
			Main.projFrames[projectile.type] = 1;
			ProjectileID.Sets.LightPet[projectile.type] = true;
			Main.projPet[projectile.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Emeraldy");

		}


		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			player.zephyrfish = false;
			return true;
		}

		public override void AI()
		{
			if (Main.rand.Next(5) == 0)
			{
				Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 61, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, default(Color), 1f);
			}
			Player player = Main.player[projectile.owner];
			TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
			if (player.dead)
			{
				modPlayer.emeraldy = false;
			}
			if (modPlayer.emeraldy)
			{
				projectile.timeLeft = 2;
			}
			Lighting.AddLight(projectile.position, 0.0f, 1.27f, 0.64f);
		}
	}
}
