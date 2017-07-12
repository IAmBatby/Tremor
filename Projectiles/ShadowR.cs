using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class ShadowR : ModProjectile
    {
        public override void SetDefaults()
        {

            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 25;
            projectile.timeLeft = 120;
            projectile.aiStyle = 1;
            projectile.tileCollide = true;
            projectile.ignoreWater = false;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Shadow Reaper");
       
    }

		
		int time2 = 6;
		int time = 6;
		
        public override void AI()
        {
            float max_dist = 300f;
            int ID = -1;
            float min_dist = float.MaxValue;
			if(time > 0)
			{
			time--;
		    }
            for (int k = 0; k < Main.npc.Length; k++)
            {
                if (!Main.npc[k].friendly && Main.npc[k].active && Vector2.Distance(projectile.position, Main.npc[k].position) < min_dist)
                {
                    min_dist = Vector2.Distance(projectile.position, Main.npc[k].position);
                    ID = k;
                }
            }
			float smooth = 12f;
            if (ID != -1 && min_dist <= max_dist && time == 0)
            {
                NPC npc = Main.npc[ID];
                Vector2 From = projectile.position;
                Vector2 To = npc.position;
                float Speed = 15f;
                Vector2 Move = (To - From);
				Vector2 Vel = Move * (Speed / (float)Math.Sqrt(Move.X * Move.X + Move.Y * Move.Y));
                projectile.velocity = projectile.velocity + ((Vel - projectile.velocity) / smooth);
                if (Vector2.Distance(projectile.position, Main.npc[ID].position) < 30f && time2 > 0)
					time2--;
                else if(Vector2.Distance(projectile.position, Main.npc[ID].position) < 30f)
					{
						projectile.Kill();
					}
            }
			CreateDust();
		}

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 17; k++)
            {
                int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType<Dusts.DustV>(), projectile.oldVelocity.X * 0.7f, projectile.oldVelocity.Y * 0.7f);
            }
            Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 7);
        }
		
		public void CreateDust()
		{
			if (Main.rand.Next(2) == 1)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType<Dusts.DustV>());
				Main.dust[dust].scale = 0.9f;
			}
		}		
    }
}
