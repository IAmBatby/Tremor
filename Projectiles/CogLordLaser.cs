using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Tremor.NovaPillar;

namespace Tremor.Projectiles
{
	public class CogLordLaser : ModProjectile
	{
		private const float length = 2400f;

		public override void SetDefaults()
		{

			projectile.width = 48;
			projectile.height = 48;
			projectile.hostile = true;
			projectile.penetrate = -1;
			projectile.magic = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			cooldownSlot = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cog Lord Laser");

		}

		public override void AI()
		{
			projectile.localAI[0] += 1f;
			if (projectile.localAI[0] > 3f)
			{
				for (int num449 = 0; num449 < 4; num449++)
				{
					Vector2 vector34 = projectile.position;
					vector34 -= projectile.velocity * (num449 * 0.25f);
					projectile.alpha = 255;
					int num450 = Dust.NewDust(vector34, 1, 1, 162, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num450].position = vector34;
					Dust expr_13F6C_cp_0 = Main.dust[num450];
					expr_13F6C_cp_0.position.X = expr_13F6C_cp_0.position.X + projectile.width / 2;
					Dust expr_13F90_cp_0 = Main.dust[num450];
					expr_13F90_cp_0.position.Y = expr_13F90_cp_0.position.Y + projectile.height / 2;
					Main.dust[num450].scale = Main.rand.Next(70, 110) * 0.013f;
					Main.dust[num450].velocity *= 0.2f;
				}
			}
			for (int k = 0; k < 200; k++)
			{
				if (NovaHandler.ShieldStrength > 0)
				{
					if (Main.npc[k].Hitbox.Intersects(projectile.Hitbox))
					{
						if (Main.npc[k].type == mod.NPCType("NovaPillar"))
						{
							NovaHandler.ShieldStrength--;
							projectile.Kill();
						}
					}
				}
				if (Main.npc[k].Hitbox.Intersects(projectile.Hitbox))
				{
					if (Main.npc[k].type == mod.NPCType("CogLord"))
					{
						projectile.Kill();
					}
				}
			}
		}
	}
}
