using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Invasion
{
	public class CyberLaser : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.scale = 1.5f;
			projectile.width = 14;
			projectile.height = 14;
			projectile.aiStyle = 1;
			projectile.light = 0.5f;
			projectile.damage = 50;
			projectile.friendly = true;
			projectile.penetrate = 2;
			projectile.magic = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			aiType = 598;
		}

		public override void OnHitNPC(NPC target1, int damage, float knockback, bool crit)
		{
			Player target = Main.player[Main.myPlayer];
			if (Main.rand.NextBool(2))
				target.AddBuff(mod.BuffType("Light"), 300);
		}

		public override void AI()
		{
			if (projectile.localAI[0] == 0f)
			{
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 20);
			}
			projectile.localAI[0] += 1f;
			if (projectile.localAI[0] > 3f)
			{
				int num90 = 1;
				if (projectile.localAI[0] > 5f)
				{
					num90 = 2;
				}
				for (int num91 = 0; num91 < num90; num91++)
				{
					int num92 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width, projectile.height, mod.DustType<CyberDust>(), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.1f, 100, default(Color), 0.4f);
					Main.dust[num92].noGravity = true;
					Dust expr_46AC_cp_0 = Main.dust[num92];
					expr_46AC_cp_0.velocity.X = expr_46AC_cp_0.velocity.X * 0.3f;
					Dust expr_46CA_cp_0 = Main.dust[num92];
					expr_46CA_cp_0.velocity.Y = expr_46CA_cp_0.velocity.Y * 0.3f;
					Main.dust[num92].noLight = true;
				}
				if (projectile.wet && !projectile.lavaWet)
				{
					projectile.Kill();
				}
			}
		}

	}
}
