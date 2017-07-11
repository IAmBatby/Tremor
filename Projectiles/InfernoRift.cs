using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class InfernoRift : ModProjectile
	{
		const int ShootRate = 20; // ����� ����५� (1 ᥪ㭤� = 60��.)
		const float ShootDistance = 500f; // ���쭮��� ��५��
		const float ShootSpeed = 12f; // ������� ᭠�鸞
		const int ShootDamage = 450; // �஭ ᭠�鸞
		const float ShootKnockback = 2; // ���� ᭠�鸞
		int ShootType = 668; // ��� ����५� (�᫨ �� �����쭮� �ન)
		int TimeToShoot = ShootRate;
		string ShootTypeMod;

		public override void SetDefaults()
		{

			projectile.width = 38;
			projectile.height = 38;
			projectile.scale = 1.1f;
			projectile.aiStyle = 0;
			aiType = 16;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.melee = true;
			projectile.penetrate = 1;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Inferno Rift");

		}


		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, Color.White, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, projectile.oldVelocity.X * 0.1f, projectile.oldVelocity.Y * 0.1f);
			}
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 109);
		}

		void Shoot()
		{
			if (--TimeToShoot <= 0)
			{
				TimeToShoot = ShootRate;
				if (ShootType == -1)
					ShootType = mod.ProjectileType(ShootTypeMod);

				float NearestNPCDist = ShootDistance;
				int NearestNPC = -1;
				foreach (NPC npc in Main.npc)
				{
					if (!npc.active)
						continue;
					if (npc.friendly || npc.lifeMax <= 5)
						continue;
					if (NearestNPCDist == -1 || npc.Distance(projectile.Center) < NearestNPCDist && Collision.CanHitLine(projectile.Center, 16, 16, npc.Center, 16, 16))
					{
						NearestNPCDist = npc.Distance(projectile.Center);
						NearestNPC = npc.whoAmI;
					}
				}
				if (NearestNPC == -1)
					return;
				Vector2 Velocity = Helper.VelocityToPoint(projectile.Center, Main.npc[NearestNPC].Center, ShootSpeed);
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Velocity.X, Velocity.Y, ShootType, ShootDamage, ShootKnockback, projectile.owner);
			}
		}

		public override void AI()
		{
			Shoot();
			projectile.ai[1] = 1;
			base.AI();
			projectile.light = 0.9f;
			int DustID1 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 120, default(Color), 1.75f);
			int DustID2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 120, default(Color), 1.75f);
			int DustID3 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 120, default(Color), 1.75f);
			Main.dust[DustID1].noGravity = true;
			Main.dust[DustID2].noGravity = true;
			Main.dust[DustID3].noGravity = true;
			if (Main.myPlayer == projectile.owner && projectile.ai[0] == 0f)
			{
				if (Main.player[projectile.owner].channel)
				{
					float num146 = 12f;
					Vector2 vector10 = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
					float num147 = Main.mouseX + Main.screenPosition.X - vector10.X;
					float num148 = Main.mouseY + Main.screenPosition.Y - vector10.Y;
					if (Main.player[projectile.owner].gravDir == -1f)
					{
						num148 = Main.screenPosition.Y + Main.screenHeight - Main.mouseY - vector10.Y;
					}
					float num149 = (float)Math.Sqrt(num147 * num147 + num148 * num148);
					num149 = (float)Math.Sqrt(num147 * num147 + num148 * num148);
					if (num149 > num146)
					{
						num149 = num146 / num149;
						num147 *= num149;
						num148 *= num149;
						int num150 = (int)(num147 * 1000f);
						int num151 = (int)(projectile.velocity.X * 1000f);
						int num152 = (int)(num148 * 1000f);
						int num153 = (int)(projectile.velocity.Y * 1000f);
						if (num150 != num151 || num152 != num153)
						{
							projectile.netUpdate = true;
						}
						projectile.velocity.X = num147;
						projectile.velocity.Y = num148;
					}
					else
					{
						int num154 = (int)(num147 * 1000f);
						int num155 = (int)(projectile.velocity.X * 1000f);
						int num156 = (int)(num148 * 1000f);
						int num157 = (int)(projectile.velocity.Y * 1000f);
						if (num154 != num155 || num156 != num157)
						{
							projectile.netUpdate = true;
						}
						projectile.velocity.X = num147;
						projectile.velocity.Y = num148;
					}
				}
				else
				{
					if (projectile.ai[0] == 0f)
					{
						projectile.ai[0] = 1f;
						projectile.netUpdate = true;
						float num158 = 12f;
						Vector2 vector11 = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
						float num159 = Main.mouseX + Main.screenPosition.X - vector11.X;
						float num160 = Main.mouseY + Main.screenPosition.Y - vector11.Y;
						if (Main.player[projectile.owner].gravDir == -1f)
						{
							num160 = Main.screenPosition.Y + Main.screenHeight - Main.mouseY - vector11.Y;
						}
						float num161 = (float)Math.Sqrt(num159 * num159 + num160 * num160);
						if (num161 == 0f)
						{
							vector11 = new Vector2(Main.player[projectile.owner].position.X + Main.player[projectile.owner].width / 2, Main.player[projectile.owner].position.Y + Main.player[projectile.owner].height / 2);
							num159 = projectile.position.X + projectile.width * 0.5f - vector11.X;
							num160 = projectile.position.Y + projectile.height * 0.5f - vector11.Y;
							num161 = (float)Math.Sqrt(num159 * num159 + num160 * num160);
						}
						num161 = num158 / num161;
						num159 *= num161;
						num160 *= num161;
						projectile.velocity.X = num159;
						projectile.velocity.Y = num160;
						if (projectile.velocity.X == 0f && projectile.velocity.Y == 0f)
						{
							projectile.Kill();
						}
					}
				}
			}
			if (projectile.velocity.Y > 16f)
			{
				projectile.velocity.Y = 16f;
			}
		}
	}
}
