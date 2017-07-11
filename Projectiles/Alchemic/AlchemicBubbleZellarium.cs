using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles.Alchemic
{
    public class AlchemicBubbleZellarium : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(405);
            aiType = 405;
            projectile.friendly = true;
            projectile.timeLeft = 150;
            projectile.light = 0.8f;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zellarium Bubble");
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

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 107);
            int k = Main.rand.Next(3, 4);
            Main.player[projectile.owner].statLife += k;
            Main.player[projectile.owner].HealEffect(k);
            if (projectile.owner == Main.myPlayer)
            {
                int num220 = Main.rand.Next(1, 3);
                for (int num221 = 0; num221 < num220; num221++)
                {
                    Vector2 value17 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                    value17.Normalize();
                    value17 *= (float)Main.rand.Next(10, 201) * 0.01f;
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, value17.X, value17.Y, mod.ProjectileType("ZellariumCloudPro"), projectile.damage, 1f, projectile.owner, 0f, (float)Main.rand.Next(-45, 1));
                }
            }
        }
    }
}
