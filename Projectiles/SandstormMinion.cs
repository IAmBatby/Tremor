using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class SandstormMinion : ModProjectile
	{
		const int Frames = 6; // Кол-во кадров
		const int AnimationRate = 12; // Частота анимации
		const int ShootRate = 30; // Частота выстрела (1 секунда = 60ед.)
		const float ShootDistance = 300f; // Дальность стрельбы
		const float ShootSpeed = 12f; // Скорость снаряда
		const int ShootDamage = 30; // Урон снаряда
		const float ShootKnockback = 2; // Отброс снаряда
		const int DustType = 19; // Тип дастов
		const float DustChance = 0.09f; // Шанс спавна дастов
		int ShootType = -1; // Тип выстрела (Если из ванильной терки)
		string ShootTypeMod = "Sand"; // Тип выстрела из мода (если указывать это, то нужно чтоб ShootType был -1)
									  // Напрмер, если:
									  // ShootType = 1 а ShootTypeMod = "projVultureFeather" - стрелять будет стрелой (id 1)
									  // Если же:
									  // ShootType = -1 а ShootTypeMod = "projVultureFeather" - стрелять будет пером вультура

		int Frame;
		int TimeToAnimation = AnimationRate;
		int TimeToShoot = ShootRate;

		Rectangle FrameRect;

		public override void SetDefaults()
		{

			projectile.width = 40;
			projectile.height = 38;
			projectile.timeLeft = 5;
			projectile.aiStyle = 62;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			base.SetDefaults();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("SandstormMinion");

		}


		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}

		void Animation()
		{
			if (--TimeToAnimation <= AnimationRate)
			{
				TimeToAnimation = AnimationRate;
				if (++Frame >= Frames)
					Frame = 0;
			}
			FrameRect = new Rectangle(0, projectile.height * Frame, projectile.width, projectile.height);
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

		void Dust()
		{
			if (Main.rand.NextBool((int)DustChance))
				Terraria.Dust.NewDust(projectile.position, projectile.width, projectile.height, DustType);
			foreach (Dust dust in Main.dust)
			{
				if (!dust.active)
					break;
				if (projectile.Distance(dust.position) > Math.Max(projectile.width, projectile.height))
					continue;
				if (dust.type == 217)
				{
					dust.active = false;
					dust.alpha = 0;
				}
			}
		}

		public override void AI()
		{
			Animation();
			Shoot();
			Dust();
			projectile.ai[1] = 1;
			base.AI();
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			spriteBatch.Draw(Main.projectileTexture[projectile.type], new Rectangle((int)(projectile.position.X - Main.screenPosition.X), (int)(projectile.position.Y - Main.screenPosition.Y), projectile.width, projectile.height), FrameRect, lightColor, projectile.rotation, new Vector2(), (projectile.spriteDirection < 0) ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0);
			return false;
		}
	}
}
