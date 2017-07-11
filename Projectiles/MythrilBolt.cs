using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class MythrilBolt : ModProjectile
{
    public override void SetDefaults()
    {

        projectile.width = 22;
        projectile.height = 22;
        projectile.friendly = true;
        projectile.magic = true;
        projectile.aiStyle = 1;
        projectile.penetrate = 3;
        projectile.timeLeft = 1200;
        ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
        ProjectileID.Sets.TrailingMode[projectile.type] = 0;
	aiType = ProjectileID.Bullet;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Mythril Bolt");
       
    }


    public override void AI()
    {
	projectile.rotation = (float)System.Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
        if(Main.rand.Next(1) == 0)
        {
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 61, projectile.velocity.X * 0.9f, projectile.velocity.Y * 1.9f);
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


    public override void Kill(int timeLeft)
    {
		Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 64);
		for (int num158 = 0; num158 < 20; num158++)
		{
			int num159 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 61, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, default(Color), 0.5f);
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
				Projectile.NewProjectile(projectile.oldPosition.X + (float)(projectile.width / 2), projectile.oldPosition.Y + (float)(projectile.height / 2), value12.X, value12.Y, 400, (int)((double)projectile.damage * 0.8), projectile.knockBack * 0.8f, projectile.owner, 0f, 0f);
			}
		}
    }

    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
        projectile.ai[0] += 0.1f;
        projectile.velocity *= 0.75f;
    }
}}
