using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Ice.Items
{
	public class FrostLiquidFlaskPro : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 28;
			projectile.friendly = true;
			projectile.aiStyle = 2;
			projectile.timeLeft = 1200;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frost Liquid Flask Pro");
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 107);
			Gore.NewGore(projectile.position, -projectile.oldVelocity * 0.2f, 704, 1f);
			Gore.NewGore(projectile.position, -projectile.oldVelocity * 0.2f, 705, 1f);
			Gore.NewGore(projectile.position, -projectile.oldVelocity * 0.2f, 705, 1f);
			Gore.NewGore(projectile.position, -projectile.oldVelocity * 0.2f, 705, 1f);
			if (projectile.owner == Main.myPlayer)
			{
				int num220 = Main.rand.Next(6, 20);
				for (int num221 = 0; num221 < num220; num221++)
				{
					Vector2 value17 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
					value17.Normalize();
					value17 *= Main.rand.Next(10, 201) * 0.01f;
					Projectile.NewProjectile(projectile.position.X, projectile.position.Y, value17.X, value17.Y, 118, projectile.damage, 1f, projectile.owner, 0f, Main.rand.Next(-45, 1));
				}
			}
		}

	}
}
