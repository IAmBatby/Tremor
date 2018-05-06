using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Enums;
using Terraria.IO;

namespace Tremor.NPCs.Bosses.CogLord.Projectiles
{
    public class ClockworkLaserCutter : ModProjectile
    {
		float MaxLength = 1000f;
		float Speed = 25f;
		int MaxLife = 300;
		int FadeTime = 30;

		float LaserFrame
		{
			get { return projectile.localAI[1]; }
			set { projectile.localAI[1] = value; }
		}

		float LaserLength
		{
			get { return projectile.localAI[0]; }
			set { projectile.localAI[0] = value; }
		}

		NPC CogLordBoss => Main.npc[(int)projectile.ai[0]];
		float LaserNumber => projectile.ai[1];

		public override void SetDefaults()
        {
            projectile.width = projectile.height = 18;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.ignoreWater = true;
            projectile.hostile = true;
            projectile.timeLeft = MaxLife;
        }

		public override void AI()
        {
			if (projectile.ai[0] < 0 || projectile.ai[0] >= 200 || !CogLordBoss.active || CogLordBoss.type != mod.NPCType<CogLord>())
			{
				projectile.timeLeft = 0;
				return;
			}

			projectile.velocity = Vector2.UnitY.RotatedBy(MathHelper.PiOver2 * LaserNumber + CogLordBoss.ai[3]);
			projectile.Center = CogLordBoss.Center + (Vector2.UnitY * 30f).RotatedBy(CogLordBoss.rotation) + projectile.velocity * 15;
            projectile.rotation = projectile.velocity.ToRotation() - MathHelper.PiOver2;

			if (++LaserFrame <= FadeTime)
				projectile.scale = LaserFrame / FadeTime;
			else if (LaserFrame > MaxLife - FadeTime)
				projectile.scale = (FadeTime - (LaserFrame - (MaxLife - FadeTime))) / FadeTime;
			else
				projectile.scale = 1f;

			if (LaserLength < MaxLength)
				LaserLength = Math.Min(LaserLength + Speed, MaxLength);

			DelegateMethods.v3_1 = Color.Yellow.ToVector3();
            Utils.PlotTileLine(projectile.Center, projectile.Center + projectile.velocity * LaserLength, projectile.width * projectile.scale, new Utils.PerLinePoint(DelegateMethods.CastLight));
        }

		public override bool ShouldUpdatePosition() => false;

		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            float collisionPoint = 0f;
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), projectile.Center, projectile.Center + projectile.velocity * LaserLength, projHitbox.Width, ref collisionPoint);
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (LaserFrame == 0)
                return false;

            Texture2D texture = Main.projectileTexture[projectile.type];
            float cLenght = LaserLength;
            Color color = new Color(255, 255, 255, 0) * 0.8f;
            Vector2 drawPosition = projectile.Center.Floor() + new Vector2(0, CogLordBoss.gfxOffY);
            Rectangle frame = new Rectangle(0, 0, texture.Width, 17);
            spriteBatch.Draw(texture, drawPosition - Main.screenPosition, frame, color, projectile.rotation, frame.Size() * 0.5f, projectile.scale, SpriteEffects.None, 0f);
            if (LaserLength != MaxLength)
                cLenght -= (frame.Height / 2 + frame.Height) * projectile.scale;
            drawPosition += projectile.velocity * projectile.scale * frame.Height * 0.5f;
            frame = new Rectangle(0, 21, texture.Width, 22);

            if (cLenght > 0f)
            {
                float step = 0f;
                while (step + 1f < cLenght)
                {
                    if (cLenght - step < frame.Height)
                        frame.Height = (int)(cLenght - step);

                    spriteBatch.Draw(texture, drawPosition - Main.screenPosition, frame, color, projectile.rotation, new Vector2(frame.Width / 2, 0f), projectile.scale, SpriteEffects.None, 0f);
                    step += frame.Height * projectile.scale;
                    drawPosition += projectile.velocity * frame.Height * projectile.scale;
                }
            }

            frame = new Rectangle(0, 49, texture.Width, 19);
            spriteBatch.Draw(texture, drawPosition - Main.screenPosition, frame, color, projectile.rotation, new Vector2(frame.Width / 2, 0f), projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
    }
}