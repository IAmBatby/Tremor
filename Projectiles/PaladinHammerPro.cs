using System;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;

namespace Tremor.Projectiles
{
    public class PaladinHammerPro : ModProjectile
    {
        const float RotationSpeed = 0.05f;
        const float Distanse = 48;

        float Rotation = 0;

        public override void SetDefaults()
        {

            projectile.width = 18;
            projectile.height = 34;
            projectile.timeLeft = 6;
            projectile.melee = true;
            projectile.aiStyle = -1;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("PaladinHammerPro");
       
    }


		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

        public override void AI()
        {
            Rotation += RotationSpeed;
            projectile.Center = Helper.PolarPos(Main.LocalPlayer.Center, Distanse, Helper.GradtoRad(Rotation));
            projectile.rotation = Helper.rotateBetween2Points(Main.LocalPlayer.Center, projectile.Center) - Helper.GradtoRad(90);
        }

        public override bool? CanHitNPC(NPC target)
        {
            return !target.friendly;
        }

    public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
    {
        Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
        for(int k = 0; k < projectile.oldPos.Length; k++)
        {
            Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
            Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
            spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
        }
        return true;
    }
    }
}
