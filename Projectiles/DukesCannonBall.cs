using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.IO;

namespace Tremor.Projectiles
{
    public class DukesCannonBall : ModProjectile
    {
        const int LifePerHit = 10;
        int Life = 0;
        int Hits = 5;
        bool NeedAddLife = true;
        public override void SetDefaults()
        {

            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 25;
            projectile.timeLeft = 99999999;
            projectile.aiStyle = -1;
            projectile.tileCollide = true;
            projectile.ignoreWater = false;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Cannon Ball");
       
    }


        int time = 45;             //Сам счетчик, впринципе просто целочисленная переменная, 60 = 1 сек, то есть тут 0.75 сек

        /*public override void AI()    Этот ИИ направляет прожектайл к игроку через 0.75 сек после выстрела
        
            //if(time != -1)                                             
            //Main.player[projectile.owner].position = Main.MouseWorld;       //Телепортирует игрока к курсору
            if (time > 0)
                time--;        //Наш таймер, если он еще не истек, то от него будет отниматься по единице в милисекунду, когда он истечет он начнет наводиться к игроку
            else
            {
                Vector2 From = projectile.position;   //Откуда будет двигаться прожектайл, здесь от своего собственного расположения
                Vector2 To = Main.player[projectile.owner].position;   //Куда будет двигаться прожектайл, здесь к расположению игрока который запустил прожектайл
                float Speed = 15f;          //С какой скоростью он будет двигаться к монстру

                Vector2 Move = (To - From);
                projectile.velocity = Move * (Speed / (float)Math.Sqrt(Move.X * Move.X + Move.Y * Move.Y));
            }
            if (Vector2.Distance(projectile.position, Main.player[projectile.owner].position) < 30f && time < 35)  //Когда прожектайл будет рядом с игроком, то исчезнет
            {
                projectile.Kill();
            }
        }*/

		int time2 = 4;
		
        public override void AI()                   //Этот ИИ направляет прожектайл к ближайшим монстрам
        {
            float max_dist = 300f;                  //На каком максимальном расстоянии прожектайл будет наводиться на монстра
            int ID = -1;
            float min_dist = float.MaxValue;        //На каком минимальном расстоянии прожектайл будет наводиться на монстра
            for (int k = 0; k < Main.npc.Length; k++)
            {
                if (!Main.npc[k].friendly && Main.npc[k].active && Vector2.Distance(projectile.position, Main.npc[k].position) < min_dist)    //Если монстр не дружелюбный и жив, а также на расстоянии меньше максимального для самонаведения
                {
                    min_dist = Vector2.Distance(projectile.position, Main.npc[k].position);
                    ID = k;
                }
            }
			float smooth = 12f; // Плавность смены скорости
            if (ID != -1 && min_dist <= max_dist)
            {
                NPC npc = Main.npc[ID];
                Vector2 From = projectile.position;  //Сам код наведения к монстру //Откуда будет двигаться прожектайл, здесь от своего собственного расположения
                Vector2 To = npc.position;           //Куда будет двигаться прожектайл, здесь к расположению монстров
                float Speed = 15f;                   //С какой скоростью он будет двигаться к монстру
                Vector2 Move = (To - From);
				Vector2 Vel = Move * (Speed / (float)Math.Sqrt(Move.X * Move.X + Move.Y * Move.Y));
                projectile.velocity = projectile.velocity + ((Vel - projectile.velocity) / smooth);
                if (Vector2.Distance(projectile.position, Main.npc[ID].position) < 30f && time2 > 0)  //Когда прожектайл попадет по монстру, ему дастся 2 милисекунды чтобы нанести урон
					time2--;
                else if(Vector2.Distance(projectile.position, Main.npc[ID].position) < 30f)   //Если прожектайл попал по монстру, то он исчезает
					{
						projectile.Kill();
					}
                }
			else
			{
				projectile.velocity -= projectile.velocity / smooth;
			}
		}

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 10; k++)
            {
                int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Ball"), projectile.oldVelocity.X * 0.9f, projectile.oldVelocity.Y * 0.9f);
            }
        }
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}
			else
			{
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.velocity.Y = -oldVelocity.Y;
				}
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
			}
			return false;
		}
    }
}
