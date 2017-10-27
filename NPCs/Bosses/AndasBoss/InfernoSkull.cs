using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.NPCs.Bosses.AndasBoss
{
	public class InfernoSkull : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Inferno Skull");
		}

		int target;
		const int ShootType = 258;
		const int ShootDamage = 55;
		const float ShootKnockback = 2f;
		const int ShootDirection = 7;

		public override void SetDefaults()
		{
			projectile.width = 26;
			projectile.height = 52;
			projectile.hostile = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 175;
			Main.projFrames[projectile.type] = 2;
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
			Projectile.NewProjectile(projectile.position.X + 40, projectile.position.Y + 40, -ShootDirection, 0, ShootType, ShootDamage, ShootKnockback, Main.myPlayer, 0f, 0f);
			Projectile.NewProjectile(projectile.position.X + 40, projectile.position.Y + 40, ShootDirection, 0, ShootType, ShootDamage, ShootKnockback, Main.myPlayer, 0f, 0f);
			Projectile.NewProjectile(projectile.position.X + 40, projectile.position.Y + 40, 0, ShootDirection, ShootType, ShootDamage, ShootKnockback, Main.myPlayer, 0f, 0f);
			Projectile.NewProjectile(projectile.position.X + 40, projectile.position.Y + 40, 0, -ShootDirection, ShootType, ShootDamage, ShootKnockback, Main.myPlayer, 0f, 0f);
		}

		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			projectile.Kill();
		}

		public override bool PreAI()
		{
			projectile.spriteDirection = projectile.direction;
			projectile.frameCounter++;
			if (projectile.frameCounter >= 3)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
				if (projectile.frame >= 2)
				{
					projectile.frame = 0;
				}
			}

			projectile.rotation = projectile.velocity.ToRotation() + 1.57F;

			if (projectile.ai[0] == 0 && Main.netMode != 1)
			{
				target = -1;
				float distance = 2000f;
				for (int k = 0; k < 255; k++)
				{
					if (Main.player[k].active && !Main.player[k].dead)
					{
						Vector2 center = Main.player[k].Center;
						float currentDistance = Vector2.Distance(center, projectile.Center);
						if (currentDistance < distance || target == -1)
						{
							distance = currentDistance;
							target = k;
						}
					}
				}
				if (target != -1)
				{
					projectile.ai[0] = 1;
					projectile.netUpdate = true;
				}
			}
			Player targetPlayer = Main.player[target];
			Vector2 direction = targetPlayer.Center - projectile.Center;
			direction.Normalize();
			projectile.velocity *= 0.98f;
			int dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6);
			Main.dust[dust2].noGravity = true;
			Main.dust[dust2].velocity *= 0f;
			Main.dust[dust2].velocity *= 0f;
			Main.dust[dust2].scale = 0.9f;
			if (Math.Sqrt((projectile.velocity.X * projectile.velocity.X) + (projectile.velocity.Y * projectile.velocity.Y)) < 14f)
			{
				if (Main.rand.Next(24) == 1)
				{
					direction.X = direction.X * Main.rand.Next(20, 24);
					direction.Y = direction.Y * Main.rand.Next(20, 24);
					projectile.velocity.X = direction.X;
					projectile.velocity.Y = direction.Y;
				}
			}
			return false;
		}

		public override void SendExtraAI(BinaryWriter writer)
		{
			writer.Write(target);
		}

		public override void ReceiveExtraAI(BinaryReader reader)
		{
			target = reader.Read();
		}
	}
}
