using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Invasion
{
	public class RelayxProj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 28;
			projectile.height = 28;
			projectile.aiStyle = 27;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 1;
			projectile.extraUpdates = 1;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
			aiType = ProjectileID.Bullet;
		}

		public override void AI()
		{
			if (Main.rand.NextBool(3))
			{
				int dust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 59, 0f, 0f, 100, default(Color), 1f);
				Main.dust[dust2].noGravity = true;
				Main.dust[dust2].velocity *= 0f;
			}

			float CenterX = projectile.Center.X;
			float CenterY = projectile.Center.Y;
			float Distanse = 400f;
			bool CheckDistanse = false;
			for (int MobCounts = 0; MobCounts < 200; MobCounts++)
			{
				if (Main.npc[MobCounts].CanBeChasedBy(projectile, false) && Collision.CanHit(projectile.Center, 1, 1, Main.npc[MobCounts].Center, 1, 1))
				{
					float Position1 = Main.npc[MobCounts].position.X + Main.npc[MobCounts].width / 2;
					float Position2 = Main.npc[MobCounts].position.Y + Main.npc[MobCounts].height / 2;
					float Position3 = Math.Abs(projectile.position.X + projectile.width / 2 - Position1) + Math.Abs(projectile.position.Y + projectile.height / 2 - Position2);
					if (Position3 < Distanse)
					{
						Distanse = Position3;
						CenterX = Position1;
						CenterY = Position2;
						CheckDistanse = true;
					}
				}
			}
			if (CheckDistanse)
			{
				float Speed = 8f;
				Vector2 FinalPos = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
				float NewPosX = CenterX - FinalPos.X;
				float NewPosY = CenterY - FinalPos.Y;
				float FinPos = (float)Math.Sqrt(NewPosX * NewPosX + NewPosY * NewPosY);
				FinPos = Speed / FinPos;
				NewPosX *= FinPos;
				NewPosY *= FinPos;
				projectile.velocity.X = (projectile.velocity.X * 20f + NewPosX) / 21f;
				projectile.velocity.Y = (projectile.velocity.Y * 20f + NewPosY) / 21f;
			}
		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 59, projectile.oldVelocity.X * 0.7f, projectile.oldVelocity.Y * 0.7f);
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			for (int k = 0; k < 5; k++)
			{
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 59, projectile.oldVelocity.X * 0.7f, projectile.oldVelocity.Y * 0.7f);
			}
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			for (int k = 0; k < 5; k++)
			{
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 59, projectile.oldVelocity.X * 0.7f, projectile.oldVelocity.Y * 0.7f);
				projectile.Kill();
			}
			return true;
		}
	}
}