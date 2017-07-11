using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace Tremor.Projectiles
{
    public class WallOfShadowsFlask_Proj : ModProjectile
    {
        public override void SetDefaults()
        {

            projectile.width = 26;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.aiStyle = 2;
            projectile.timeLeft = 1200;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Flask of Shadows");
       
    }


        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 107);
            Gore.NewGore(projectile.position, -projectile.oldVelocity * 0.2f, 99, 1f);
            Gore.NewGore(projectile.position, -projectile.oldVelocity * 0.2f, 99, 1f);
            if (projectile.owner == Main.myPlayer)
            {
                int num220 = Main.rand.Next(4, 10);
                for (int num221 = 0; num221 < num220; num221++)
                {
                    Vector2 value17 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                    value17.Normalize();
                    value17 *= (float)Main.rand.Next(10, 201) * 0.01f;
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, value17.X, value17.Y, mod.ProjectileType("WallOfShadowsBoom"), projectile.damage, 1f, projectile.owner, 0f, (float)Main.rand.Next(-45, 1));
                }
            }
        }
    }
}
