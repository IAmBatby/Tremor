using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles {
public class VoidBladePro : ModProjectile
{
    public override void SetDefaults()
    {

        projectile.width = 54;
        projectile.height = 54;
        projectile.aiStyle = 27;
        projectile.friendly = true;
        projectile.ranged = true;
        projectile.penetrate = 5;
        projectile.timeLeft = 600;
        projectile.light = 0.8f;
        projectile.extraUpdates = 1;
        ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
        ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        aiType = ProjectileID.Bullet;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("VoidBladePro");
       
    }


    public override void Kill(int timeLeft)
    {
		for (int num158 = 0; num158 < 20; num158++)
		{
			int num159 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 226, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, default(Color), 1.5f);
			if (Main.rand.Next(3) == 0)
			{
				Main.dust[num159].fadeIn = 1.1f + (float)Main.rand.Next(-10, 11) * 0.01f;
				Main.dust[num159].scale = 0.35f + (float)Main.rand.Next(-10, 11) * 0.01f;
				Main.dust[num159].type++;
			}
			else
			{
				Main.dust[num159].scale = 1.2f + (float)Main.rand.Next(-10, 11) * 0.01f;
			}
			Main.dust[num159].noGravity = true;
			Main.dust[num159].velocity *= 2.5f;
			Main.dust[num159].velocity -= projectile.oldVelocity / 10f;
		}
		if (Main.myPlayer == projectile.owner)
		{
			int num160 = Main.rand.Next(0, 0);
			for (int num161 = 0; num161 < num160; num161++)
			{
				Vector2 value12 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
				while (value12.X == 0f && value12.Y == 0f)
				{
					value12 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
				}
				value12.Normalize();
				value12 *= (float)Main.rand.Next(70, 101) * 0.1f;
				Projectile.NewProjectile(projectile.oldPosition.X + (float)(projectile.width / 2), projectile.oldPosition.Y + (float)(projectile.height / 2), value12.X, value12.Y, 400, (int)((double)projectile.damage * 0.8), projectile.knockBack * 2.8f, projectile.owner, 0f, 0f);
			}
		}
    }

    public override void AI()
    {
		if (projectile.scale > 1f)
        projectile.scale = 1f;
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
					vector64 *= (float)Main.rand.Next(5, 25) * 0.9f;

					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector64.X, vector64.Y, mod.ProjectileType("VoidRingPro"), projectile.damage/2, projectile.knockBack, projectile.owner, -10f, 0f);
				}
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
}}
