using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	[AutoloadBossHead]
	public class Alchemaster : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alchemaster");
		}

		#region "Константы"
		const int FlameShootRate = 250; // Частота выстрела
		const int FlameShootDamage = 60; // Урон от лазера.
		const float FlameShootKN = 1.0f; // Отбрасывание
		const int FlameShootType = 100; // Тип проджектайла которым будет произведён выстрел.
		const float FlameShootSpeed = 4; // Это, я так понимаю, влияет на дальность выстрела

		int TimeToFlameShoot = FlameShootRate; // Время до выстрела.
		const int AnimationRate = 8; // Частота смены кадров (То, сколько кадров не будет сменятся кадр)
		const int FrameCount = 4; // Кол-во кадров

		const int ShootRate = 50; // Частота выстрела. Будет производить 60/ShootRate выстрелов в секунду
		const int ShootDamage = 75; // Урон от выстрела
		int ShootType; // Тип выстрела (задаётся в SetDefaults())
		const float ShootKnockback = 1; // Отбрасование от выстрела
		const float ShootSpeed = 10; // Скорость выстрела

		const float DistortPercent = 0.15f; // Процент деформации статов (неточности) (1.0 == 100%)

		const int MinionsID = 61; // ID вуртулек
		const int MinionsCount = 6; // Кол-во вуртулек которых заспавнит

		const int StateTime_Flying = 600; // Сколько будет летать в воздухе до призыва миньонов
		const int StateTime_Minions = 120; // Сколько времени будет спавнить вуртулек

		const int FlyingAI = 2;
		const int MinionsAI = 0;

		const float MinionsState_XDeaccelerationPower = 0.05f; // Скорость замедления по X
		const float MinionsState_YMaxSpeed = 2.80f; // Макс. скорость взлёта во время спавна миньонов
		const float MinionsStete_YSpeedStep = 0.02f; // Скорость увеличения скорости по Y во время спавна миньонов

		const int States = 2;
		#endregion

		#region "Переменные"
		int TimeToAnimation = AnimationRate;
		int Frame;
		bool Shoots = true;
		int TimeToShoot = ShootRate;
		int State;
		int TimeToState = StateTime_Flying;
		bool runAway;
		#endregion

		public override void SetDefaults()
		{
			npc.lifeMax = 30000;
			npc.damage = 82;
			npc.defense = 40;
			npc.knockBackResist = 0f;
			npc.width = 190;
			npc.height = 210;
			npc.aiStyle = 2;
			npc.noGravity = true;
			music = 17;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath42;
			npc.value = Item.buyPrice(0, 9, 75, 0);
			npc.boss = true;
			ShootType = mod.ProjectileType("PlagueFlaskEvil");
			bossBag = mod.ItemType("AlchemasterTreasureBag");
			npc.noTileCollide = true;
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 74, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 74, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 74, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AlchemasterGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AlchemasterGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AlchemasterGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AlchemasterGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AlchemasterGore4"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AlchemasterGore4"), 1f);
				Dust.NewDust(npc.position, npc.width, npc.height, 74, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 74, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 74, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 74, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 74, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 74, 2.5f * hitDirection, -2.5f, 0, default(Color), 3.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 74, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 74, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
			}
		}

		public override void AI()
		{
			if (--TimeToFlameShoot <= 0 && npc.target != -1) FlameShoot(); // В этой строке из переменной TimeToShot отнимается 1, и если TimeToShot < или = 0, то вызывается метод FlameShoot()
			PlayAnimation(); // Проигрывание анимации
			if (CheckRunConditions())
				return;
			ChangeState(); // Смена стадии
			Shoot(); // Выстрел
			DoAI(); // Сам искуственный интеллект
		}

		void PlayAnimation()
		{
			if (--TimeToAnimation <= 0)
			{
				TimeToAnimation = (int)Helper.DistortFloat(AnimationRate, DistortPercent);
				if (++Frame >= FrameCount)
					Frame = 0;
			}
		}

		Vector2 VelocityFPTP(Vector2 pos1, Vector2 pos2, float speed)
		{
			Vector2 move = pos2 - pos1;
			return move * (speed / (float)Math.Sqrt(move.X * move.X + move.Y * move.Y));
		}

		void FlameShoot()
		{
			TimeToFlameShoot = FlameShootRate; // Устанавливаем кулдаун выстрелу
			Vector2 velocity = VelocityFPTP(npc.Center, Main.player[npc.target].Center, FlameShootSpeed); // Тут мы получим нужную velocity (пояснение аргументов ниже)
																										  // 1 аргумент - позиция из которой будет вылетать выстрел
																										  // 2 аргумент - позиция в которую он должен полететь 
																										  // 3 аргумент - скорость выстрела
			Projectile.NewProjectile(npc.Center.X, npc.Center.Y, velocity.X, velocity.Y, mod.ProjectileType("SparkingFlaskEvil"), FlameShootDamage, FlameShootKN);
		}

		bool CheckRunConditions()
		{
			if (runAway)
			{
				npc.aiStyle = 0;
				if (npc.velocity.Y >= 0)
					npc.velocity.Y = -1f;
				npc.velocity.Y *= 1.01f;
				return true;
			}
			int Target = Helper.GetNearestPlayer(npc.Center, true);
			if (Target == -1)
			{ runAway = true; return true; }
			return false;
		}

		void ChangeState()
		{
			if (--TimeToState < 0)
			{
				State++;
				if (State >= States)
					State = 0;
				switch (State)
				{
					case 0:
						Shoots = true;
						npc.aiStyle = FlyingAI;
						TimeToState = StateTime_Flying;
						break;
					case 1:
						Shoots = false;
						npc.aiStyle = MinionsAI;
						TimeToState = StateTime_Minions;
						break;
				}
			}
		}

		void Shoot()
		{
			if (!Shoots && npc.target < 0)
				return;
			if (--TimeToShoot > 0)
				return;
			TimeToShoot = (int)Helper.DistortFloat(ShootRate, DistortPercent);
			for (int i = 0; i < ((Main.expertMode) ? 3 : 1); i++)
			{
				Vector2 Velocity = Helper.VelocityToPoint(npc.Center, Helper.RandomPointInArea(new Vector2(Main.player[npc.target].Center.X - 10, Main.player[npc.target].Center.Y - 10), new Vector2(Main.player[npc.target].Center.X + 20, Main.player[npc.target].Center.Y + 20)), ShootSpeed);
				int Proj = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Velocity.X, Velocity.Y, ShootType, (int)Helper.DistortFloat(ShootDamage, DistortPercent), Helper.DistortFloat(ShootKnockback, DistortPercent));
				Main.projectile[Proj].Center = npc.Center;
			}
		}

		void DoAI()
		{
			switch (State)
			{
				case 1:
					npc.velocity.Y -= MinionsStete_YSpeedStep;
					if (npc.velocity.Y < -MinionsState_YMaxSpeed)
						npc.velocity.Y = MinionsState_YMaxSpeed;
					if (TimeToState % StateTime_Minions / MinionsCount == 0)
					{
						Vector2 Position = Helper.RandomPointInArea(npc.Hitbox);
						int index = NPC.NewNPC((int)Position.X, (int)Position.Y, mod.NPCType("PlagueSoul"));
						Main.npc[index].Center = Position;
					}
					break;
			}
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			SpriteEffects Direction = (npc.target == -1) ? SpriteEffects.None : ((Main.player[npc.target].position.X < npc.position.X) ? SpriteEffects.None : SpriteEffects.FlipHorizontally);
			spriteBatch.Draw(Main.npcTexture[npc.type], new Rectangle((int)(npc.position.X - Main.screenPosition.X), (int)(npc.position.Y - Main.screenPosition.Y), 248, 240), new Rectangle(0, Frame * 240, 248, 240), drawColor, 0, new Vector2(0, 0), Direction, 0);
			return false;
		}

		public override void NPCLoot()
		{

			if (Main.expertMode)
			{
				npc.DropBossBags();
			}

			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + npc.width / 2) / 16;
				int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
				int halfLength = npc.width / 2 / 16 + 1;

				if (!Main.expertMode && Main.rand.NextBool(7))
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AlchemasterMask"));
				}
				if (Main.rand.Next(10) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AlchemasterTrophy"));
				}
				if (!Main.expertMode && Main.rand.NextBool())
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PlagueFlask"), Main.rand.Next(30, 78));
				}
				if (!Main.expertMode && Main.rand.NextBool())
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PlagueFlask"), Main.rand.Next(30, 78));
				}
				if (!Main.expertMode && Main.rand.NextBool())
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LongFuse"));
				}
				if (!Main.expertMode && Main.rand.NextBool(3))
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TheGlorch"));
				}
				if (!Main.expertMode && Main.rand.NextBool(3))
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BadApple"));
				}
				TremorWorld.Boss.Alchemaster.Downed();

			}
		}
	}
}