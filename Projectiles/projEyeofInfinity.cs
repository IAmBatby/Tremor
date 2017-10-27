using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

////////////////////

namespace Tremor.Projectiles
{
	public class projEyeofInfinity : ModProjectile
	{
		const float Distanse = 25f; // Дистанция на которой вращяются половины друг от друга
		const int DrawCount = 10; // кол-во "шлейфов" за одной половиной
		const float AngleStep = 0.005f; // Поворот за кадр
		int TimeToReturn = 20; // Время, через которое бумеранг возворотится к игроку
		const int SpeedMulti = 2; // Увеличение скорости при возвращении

		float AngleLeft = 0.005f; // Начальный поворот первой половины
		float AngleRight = 0.050f; // Начальный поворот второй половины (Должон быть ровно в 10 раз больше чем AngleLeft)

		public override void SetDefaults()
		{

			projectile.width = 42;
			projectile.height = 42;
			projectile.aiStyle = 0;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.magic = true;
			projectile.timeLeft = 3600;
			projectile.tileCollide = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eye of Infinity");

		}

		void TryToReturn()
		{
			if (--TimeToReturn <= 0)
			{
				projectile.aiStyle = 3;
				projectile.ai[0] = 1;
			}
		}

		void Angle()
		{
			AngleLeft -= AngleStep;
			AngleRight += AngleStep;
		}

		void ImproveSpeed()
		{
			projectile.position += (projectile.aiStyle == 3) ? projectile.velocity * (SpeedMulti - 1) : new Vector2(0, 0);
		}

		//////////////////////////////////////////////////////////////////////////////////
		List<Vector2> OldPositionsLeft = new List<Vector2>();
		List<Vector2> OldPositionsRight = new List<Vector2>();
		List<float> OldRotations = new List<float>();
		const int SavePosRate = 1;
		int TimeToSavePos;
		void TestDrawing()
		{
			if (--TimeToSavePos <= 0)
			{
				TimeToSavePos = SavePosRate;
				List<Vector2> newOldPositions = new List<Vector2>();
				newOldPositions.Add(Helper.PolarPos(projectile.position, Distanse, AngleLeft, 0, 0) - Main.screenPosition);
				for (int i = 0; i < OldPositionsLeft.Count && i < DrawCount - 1; i++)
					newOldPositions.Add(OldPositionsLeft[i]);
				OldPositionsLeft = newOldPositions;

				newOldPositions = new List<Vector2>();
				newOldPositions.Add(Helper.PolarPos(projectile.position, Distanse, AngleRight, 0, 0) - Main.screenPosition - projectile.Size / 2);
				for (int i = 0; i < OldPositionsRight.Count && i < DrawCount - 1; i++)
					newOldPositions.Add(OldPositionsRight[i]);
				OldPositionsRight = newOldPositions;

				List<float> newOldRotations = new List<float>();
				newOldRotations.Add(projectile.rotation);
				for (int i = 0; i < OldRotations.Count && i < DrawCount - 1; i++)
					newOldRotations.Add(OldRotations[i]);
				OldRotations = newOldRotations;
			}
		}
		//////////////////////////////////////////////////////////////////////////////////

		public override void AI()
		{
			TryToReturn(); // Пытаемся вернутся
			Angle(); // Поворачиваем
			ImproveSpeed(); // Изменяем скорость

			TestDrawing(); //////////////////////////////////////////////////////////////////////////////////
		}

		/*
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            for (int i = 0; i < DrawCount; i++)
            {
                Vector2 pP = Helper.PolarPos(projectile.position, Distanse, AngleLeft - (AngleStep * i * 1.5f), 0, 0);
                projHitbox = new Rectangle((int)pP.X, (int)pP.Y, projectile.width, projectile.height);
                if (projHitbox.Intersects(targetHitbox))
                    return true;
                pP = Helper.PolarPos(projectile.position, Distanse, AngleRight - (AngleStep * i * 1.5f), 0, 0) - projectile.Size / 2;
                projHitbox = new Rectangle((int)pP.X, (int)pP.Y, projectile.width, projectile.height);
                if (projHitbox.Intersects(targetHitbox))
                    return true;
            }
            return false;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Color color = new Color(250, 250, 250, 0);
            Color color2 = new Color(0, 0, 0, 250);
            for (int i = 0; i < DrawCount; i++)
            {
                spriteBatch.Draw(Main.projectileTexture[projectile.type], Helper.PolarPos(projectile.position, Distanse, AngleLeft - (AngleStep * i * 1.5f), 0, 0) - Main.screenPosition, null, color, AngleLeft, new Vector2(2, 2), 1, SpriteEffects.None, 0f);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], Helper.PolarPos(projectile.position, Distanse, AngleRight - (AngleStep * i * 1.5f), 0, 0) - Main.screenPosition - projectile.Size / 2, null, color, AngleRight, new Vector2(2, 2), 1, SpriteEffects.None, 0f);
                color = new Color(color.R - 250 / DrawCount, color.G - 250 / DrawCount, color.B - 250 / DrawCount, color.A + 250 / DrawCount);
                color2 = new Color(color2.R + 250 / DrawCount, color.G + 250 / DrawCount, color.B + 250 / DrawCount, color.A - 250 / DrawCount);
            }
            return false;
        }
        */

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Color color = new Color(250, 250, 250, 0);
			for (int i = 0; i < OldPositionsLeft.Count; i++)
			{
				color = new Color(color.R - 250 / DrawCount, color.G - 250 / DrawCount, color.B - 250 / DrawCount, color.A + 250 / (OldPositionsLeft.Count * 2));
				spriteBatch.Draw(Main.projectileTexture[projectile.type], OldPositionsLeft[i], null, color, OldRotations[i], new Vector2(2, 2), 1, SpriteEffects.None, 0);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], OldPositionsRight[i], null, color, -OldRotations[i], new Vector2(2, 2), 1, SpriteEffects.None, 0);
			}
			return false;
		}
	}
}
