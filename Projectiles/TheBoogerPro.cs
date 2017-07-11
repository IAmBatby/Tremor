using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class TheBoogerPro : ModProjectile
    {
        public override void SetDefaults()
        {

            projectile.width = 34;
            projectile.height = 34;
            projectile.friendly = true;
            projectile.penetrate = -1; // Penetrates NPCs infinitely.
            projectile.melee = true; // Deals melee dmg.

            projectile.aiStyle = 15; // Set the aiStyle to that of a flail.
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("The Booger Pro");
       
    }


		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}
		
    public override void AI()
    {
				Vector2 vector63 = Main.player[projectile.owner].Center - projectile.Center;
				if (Main.player[projectile.owner].dead)
				{
					projectile.Kill();
					return;
				}
				if (projectile.ai[0] == 0f && vector63.Length() > 400f)
				{
					projectile.ai[0] = 1f;
				}
				if (projectile.ai[0] == 1f || projectile.ai[0] == 2f)
				{
					float num810 = vector63.Length();
					if (num810 > 1500f)
					{
						projectile.Kill();
						return;
					}
					if (num810 > 600f)
					{
						projectile.ai[0] = 2f;
					}
					float num811 = 20f;
					if (projectile.ai[0] == 2f)
					{
						num811 = 40f;
					}
					if (vector63.Length() < num811)
					{
						projectile.Kill();
						return;
					}
				}
				projectile.ai[1] += 1f;
				if (projectile.ai[1] > 5f)
				{
					projectile.alpha = 0;
				}
				if ((int)projectile.ai[1] % 3 == 0 && projectile.owner == Main.myPlayer)
				{
					Vector2 vector64 = vector63 * -1f;
					vector64.Normalize();
					vector64 *= Main.rand.Next(5, 25) * 0.9f;

					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector64.X, vector64.Y, mod.ProjectileType("TheBoogerBallPro"), projectile.damage/4, projectile.knockBack, projectile.owner, -10f, 0f);
				}
    }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = ModLoader.GetTexture("Tremor/Projectiles/TheBooger_Chain");

            Vector2 position = projectile.Center;
            Vector2 mountedCenter = Main.player[projectile.owner].MountedCenter;
            Rectangle? sourceRectangle = new Rectangle?();
            Vector2 origin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
            float num1 = texture.Height;
            Vector2 vector2_4 = mountedCenter - position;
            float rotation = (float)Math.Atan2(vector2_4.Y, vector2_4.X) - 1.57f;
            bool flag = true;
            if (float.IsNaN(position.X) && float.IsNaN(position.Y))
                flag = false;
            if (float.IsNaN(vector2_4.X) && float.IsNaN(vector2_4.Y))
                flag = false;
            while (flag)
            {
                if (vector2_4.Length() < num1 + 1.0)
                {
                    flag = false;
                }
                else
                {
                    Vector2 vector2_1 = vector2_4;
                    vector2_1.Normalize();
                    position += vector2_1 * num1;
                    vector2_4 = mountedCenter - position;
                    Color color2 = Lighting.GetColor((int)position.X / 16, (int)(position.Y / 16.0));
                    color2 = projectile.GetAlpha(color2);
                    Main.spriteBatch.Draw(texture, position - Main.screenPosition, sourceRectangle, color2, rotation, origin, 1f, SpriteEffects.None, 0.0f);
                }
            }

            return true;
        }
    }
}
