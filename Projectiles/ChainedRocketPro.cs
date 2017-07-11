using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class ChainedRocketPro : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 22;
			projectile.height = 34;
			projectile.friendly = true;
			projectile.penetrate = -5; // Penetrates NPCs infinitely.
			projectile.melee = true; // Deals melee dmg.

			projectile.aiStyle = 15; // Set the aiStyle to that of a flail.
			projectile.timeLeft = 500;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chained Rocket");

		}


		public override void AI()
		{
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 136, default(Color), 0.9f);
			Main.dust[dust].noGravity = true;
			Vector2 vector63 = Main.player[projectile.owner].Center - projectile.Center;
			projectile.rotation = vector63.ToRotation() - 1.57f;
			if (Main.player[projectile.owner].dead)
			{
				projectile.Kill();
				return;
			}
			Main.player[projectile.owner].itemAnimation = 10;
			Main.player[projectile.owner].itemTime = 10;
			if (vector63.X < 0f)
			{
				Main.player[projectile.owner].ChangeDir(1);
				projectile.direction = 1;
			}
			else
			{
				Main.player[projectile.owner].ChangeDir(-1);
				projectile.direction = -1;
			}
			Main.player[projectile.owner].itemRotation = (vector63 * -1f * (float)projectile.direction).ToRotation();
			projectile.spriteDirection = ((vector63.X > 0f) ? -1 : 1);
			if (projectile.ai[0] == 0f && vector63.Length() > 800f)
			{
				projectile.ai[0] = 1f;
			}
			if (projectile.ai[0] == 1f || projectile.ai[0] == 2f)
			{
				float num810 = vector63.Length();
				if (num810 > 3000f)
				{
					projectile.Kill();
					return;
				}
				if (num810 > 1200f)
				{
					projectile.ai[0] = 2f;
				}
				projectile.tileCollide = false;
				float num811 = 20f;
				if (projectile.ai[0] == 2f)
				{
					num811 = 40f;
				}
				projectile.velocity = Vector2.Normalize(vector63) * num811;
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
				vector64 *= (float)Main.rand.Next(45, 65) * 0.1f;
				vector64 = vector64.RotatedBy((Main.rand.NextDouble() - 0.5) * 1.5707963705062866, default(Vector2));
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector64.X, vector64.Y, mod.ProjectileType("nichego"), projectile.damage, projectile.knockBack, projectile.owner, -10f, 0f);
			}
		}

		public override bool PreDraw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture = ModLoader.GetTexture("Tremor/Projectiles/ChainedRocket_Chain");

			Vector2 position = projectile.Center;
			Vector2 mountedCenter = Main.player[projectile.owner].MountedCenter;
			Microsoft.Xna.Framework.Rectangle? sourceRectangle = new Microsoft.Xna.Framework.Rectangle?();
			Vector2 origin = new Vector2((float)texture.Width * 0.5f, (float)texture.Height * 0.5f);
			float num1 = (float)texture.Height;
			Vector2 vector2_4 = mountedCenter - position;
			float rotation = (float)Math.Atan2((double)vector2_4.Y, (double)vector2_4.X) - 1.57f;
			bool flag = true;
			if (float.IsNaN(position.X) && float.IsNaN(position.Y))
				flag = false;
			if (float.IsNaN(vector2_4.X) && float.IsNaN(vector2_4.Y))
				flag = false;
			while (flag)
			{
				if ((double)vector2_4.Length() < (double)num1 + 1.0)
				{
					flag = false;
				}
				else
				{
					Vector2 vector2_1 = vector2_4;
					vector2_1.Normalize();
					position += vector2_1 * num1;
					vector2_4 = mountedCenter - position;
					Microsoft.Xna.Framework.Color color2 = Lighting.GetColor((int)position.X / 16, (int)((double)position.Y / 16.0));
					color2 = projectile.GetAlpha(color2);
					Main.spriteBatch.Draw(texture, position - Main.screenPosition, sourceRectangle, color2, rotation, origin, 1f, SpriteEffects.None, 0.0f);
				}
			}

			return true;
		}
	}
}
