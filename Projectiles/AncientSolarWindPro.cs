using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class AncientSolarWindPro : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(66);

			aiType = 66;
			projectile.tileCollide = false;
			projectile.light = 0.8f;
			projectile.penetrate = -1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Solar Wind");

		}

		public override void AI()
		{
			projectile.light = 0.9f;
			int DustID = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width, projectile.height, 6, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 0.5f);
			Main.player[projectile.owner].direction = projectile.direction;
			Main.player[projectile.owner].heldProj = projectile.whoAmI;
			Main.player[projectile.owner].itemTime = Main.player[projectile.owner].itemAnimation;
			projectile.position.X = Main.player[projectile.owner].position.X + Main.player[projectile.owner].width / 2 - projectile.width / 2;
			projectile.position.Y = Main.player[projectile.owner].position.Y + Main.player[projectile.owner].height / 2 - projectile.height / 2;
			projectile.position += projectile.velocity * projectile.ai[0];
			if (projectile.ai[0] == 0f)
			{
				projectile.ai[0] = 3f;
				projectile.netUpdate = true;
			}
			if (Main.player[projectile.owner].itemAnimation < Main.player[projectile.owner].itemAnimationMax / 3)
			{
				projectile.ai[0] -= 1.0f; //How far back it goes
				if (projectile.localAI[0] == 0f && Main.myPlayer == projectile.owner)
				{
					projectile.localAI[0] = 1f;
					if (Collision.CanHit(Main.player[projectile.owner].position, Main.player[projectile.owner].width, Main.player[projectile.owner].height, new Vector2(projectile.Center.X + projectile.velocity.X * projectile.ai[0], projectile.Center.Y + projectile.velocity.Y * projectile.ai[0]), projectile.width, projectile.height))
					{
						Projectile.NewProjectile(projectile.Center.X + projectile.velocity.X, projectile.Center.Y + projectile.velocity.Y, projectile.velocity.X * 1.5f, projectile.velocity.Y * 1.5f, 85, projectile.damage, projectile.knockBack * 0.85f, projectile.owner, 0f, 0f);
					}
				}
			}
			else
			{
				projectile.ai[0] += 0.65f; //How far it goes
			}

			//Kills projectile once item is done animating
			if (Main.player[projectile.owner].itemAnimation == 0)
			{
				projectile.Kill();
			}

			//Rotate spear
			projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 2.355f;
			if (projectile.spriteDirection == -1)
			{
				projectile.rotation -= 1.57f;
			}
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextBool(2))
			{
				target.AddBuff(24, 180, false);
			}
		}
	}
}
