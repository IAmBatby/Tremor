using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.NPCs.Bosses.AndasBoss
{
	public class SpiritFire : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spirit Fire");
		}

		public override void SetDefaults()
		{
			projectile.width = 6;
			projectile.height = 6;
			projectile.hostile = true;
			projectile.ignoreWater = true;
			projectile.penetrate = -1;
			projectile.extraUpdates = 3;
			projectile.timeLeft = 60;
		}

		public override void AI()
		{
			if (projectile.timeLeft > 60)
			{
				projectile.timeLeft = 60;
			}
			if (projectile.ai[0] > 7f)
			{
				float num296 = 1f;
				if (projectile.ai[0] == 8f)
				{
					num296 = 0.25f;
				}
				else if (projectile.ai[0] == 9f)
				{
					num296 = 0.5f;
				}
				else if (projectile.ai[0] == 10f)
				{
					num296 = 0.75f;
				}
				projectile.ai[0] += 1f;
				int num297 = 6;
				if (Main.rand.NextBool(2))
				{
					for (int num298 = 0; num298 < 1; num298++)
					{
						int num299 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
						if ((num297 == 6 && Main.rand.NextBool(3)))
						{
							Main.dust[num299].noGravity = true;
							Main.dust[num299].scale *= 3f;
							Dust expr_DBEF_cp_0 = Main.dust[num299];
							expr_DBEF_cp_0.velocity.X = expr_DBEF_cp_0.velocity.X * 2f;
							Dust expr_DC0F_cp_0 = Main.dust[num299];
							expr_DC0F_cp_0.velocity.Y = expr_DC0F_cp_0.velocity.Y * 2f;
						}
						else
						{
							Main.dust[num299].scale *= 1.5f;
						}
						Dust expr_DC74_cp_0 = Main.dust[num299];
						expr_DC74_cp_0.velocity.X = expr_DC74_cp_0.velocity.X * 1.2f;
						Dust expr_DC94_cp_0 = Main.dust[num299];
						expr_DC94_cp_0.velocity.Y = expr_DC94_cp_0.velocity.Y * 1.2f;
						Main.dust[num299].scale *= num296;
						if (num297 == 6)
						{
							Main.dust[num299].velocity += projectile.velocity;
							if (!Main.dust[num299].noGravity)
							{
								Main.dust[num299].velocity *= 0.5f;
							}
						}
					}
				}
			}
			else
			{
				projectile.ai[0] += 1f;
			}
			projectile.rotation += 0.3f * projectile.direction;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.Kill();
			return false;
		}
	}
}