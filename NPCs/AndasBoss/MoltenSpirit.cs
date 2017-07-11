using Terraria;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs.AndasBoss
{
    public class MoltenSpirit : ModNPC
    {

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Molten Spirit");
			Main.npcFrameCount[npc.type] = 4;
		}

        public override void SetDefaults()
        {
            npc.width = 102;
            npc.height = 88;
            npc.damage = 80;
            npc.defense = 95;
            npc.knockBackResist = 0f;
            npc.lifeMax = 4500;
            npc.HitSound = SoundID.NPCHit54;
            npc.DeathSound = SoundID.NPCDeath52;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.npcSlots = 0.75f;
	    npc.buffImmune[24] = true;
	    npc.buffImmune[67] = true;
            npc.lavaImmune = true;
        }

        int AnimationRate = 6;
        int CurrentFrame = 0;
        int TimeToAnimation = 6;

        Rectangle GetFrame(int Number)
        {
            return new Rectangle(0, npc.frame.Height * (Number - 1), npc.frame.Width, npc.frame.Height);
        }

        public override bool PreAI()
        {
            npc.spriteDirection = npc.direction;
            if (--TimeToAnimation <= 0)
            {
                if (++CurrentFrame > 4)
                    CurrentFrame = 1;
                TimeToAnimation = AnimationRate;
                npc.frame = GetFrame(CurrentFrame);
            }
            float velMax = 1f;
            float acceleration = 0.011f;
            npc.TargetClosest(true);
            Vector2 center = npc.Center;
            float deltaX = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - center.X;
            float deltaY = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - center.Y;
            float distance = (float)Math.Sqrt((double)deltaX * (double)deltaX + (double)deltaY * (double)deltaY);
            npc.ai[1] += 1f;
            if ((double)npc.ai[1] > 600.0)
            {
                acceleration *= 8f;
                velMax = 4f;
                if ((double)npc.ai[1] > 650.0)
                {
                    npc.ai[1] = 0f;
                }
            }
            else if ((double)distance < 250.0)
            {
                npc.ai[0] += 0.9f;
                if (npc.ai[0] > 0f)
                {
                    npc.velocity.Y = npc.velocity.Y + 0.019f;
                }
                else
                {
                    npc.velocity.Y = npc.velocity.Y - 0.019f;
                }
                if (npc.ai[0] < -100f || npc.ai[0] > 100f)
                {
                    npc.velocity.X = npc.velocity.X + 0.019f;
                }
                else
                {
                    npc.velocity.X = npc.velocity.X - 0.019f;
                }
                if (npc.ai[0] > 200f)
                {
                    npc.ai[0] = -200f;
                }
            }
            if ((double)distance > 350.0)
            {
                velMax = 5f;
                acceleration = 0.3f;
            }
            else if ((double)distance > 300.0)
            {
                velMax = 3f;
                acceleration = 0.2f;
            }
            else if ((double)distance > 250.0)
            {
                velMax = 1.5f;
                acceleration = 0.1f;
            }
            float stepRatio = velMax / distance;
            float velLimitX = deltaX * stepRatio;
            float velLimitY = deltaY * stepRatio;
            if (Main.player[npc.target].dead)
            {
                velLimitX = (float)((double)((float)npc.direction * velMax) / 2.0);
                velLimitY = (float)((double)(-(double)velMax) / 2.0);
            }
            if (npc.velocity.X < velLimitX)
            {
                npc.velocity.X = npc.velocity.X + acceleration;
            }
            else if (npc.velocity.X > velLimitX)
            {
                npc.velocity.X = npc.velocity.X - acceleration;
            }
            if (npc.velocity.Y < velLimitY)
            {
                npc.velocity.Y = npc.velocity.Y + acceleration;
            }
            else if (npc.velocity.Y > velLimitY)
            {
                npc.velocity.Y = npc.velocity.Y - acceleration;
            }
            if ((double)velLimitX > 0.0)
            {
                npc.spriteDirection = -1;
                npc.rotation = (float)Math.Atan2((double)velLimitY, (double)velLimitX);
            }
            if ((double)velLimitX < 0.0)
            {
                npc.spriteDirection = 1;
                npc.rotation = (float)Math.Atan2((double)velLimitY, (double)velLimitX) + 3.14f;
            }
            Player target = Main.player[npc.target];
            int distance2 = (int)Math.Sqrt((npc.Center.X - target.Center.X) * (npc.Center.X - target.Center.X) + (npc.Center.Y - target.Center.Y) * (npc.Center.Y - target.Center.Y));
            if (distance2 < 320)
            {
                float num867 = 6f;
                int num869 = mod.ProjectileType("SpiritFire");
                Vector2 vector86 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                float num864 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector86.X;
                float num865 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector86.Y;
                float num866 = (float)Math.Sqrt((double)(num864 * num864 + num865 * num865));
                num866 = num867 / num866;
                num864 *= num866;
                num865 *= num866;
                num865 += (float)Main.rand.Next(-40, 41) * 0.01f;
                num864 += (float)Main.rand.Next(-40, 41) * 0.01f;
                num865 += npc.velocity.Y * 0.5f;
                num864 += npc.velocity.X * 0.5f;
                vector86.X -= num864 * 1f;
                vector86.Y -= num865 * 1f;
                Projectile.NewProjectile(vector86.X, vector86.Y, num864, num865, num869, npc.damage, 0f, Main.myPlayer, 0f, 0f);
            }
            return false;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D drawTexture = Main.npcTexture[npc.type];
            Vector2 origin = new Vector2((drawTexture.Width / 2) * 0.5F, (drawTexture.Height / Main.npcFrameCount[npc.type]) * 0.5F);

            Vector2 drawPos = new Vector2(
                npc.position.X - Main.screenPosition.X + (npc.width / 2) - (Main.npcTexture[npc.type].Width / 2) * npc.scale / 2f + origin.X * npc.scale,
                npc.position.Y - Main.screenPosition.Y + npc.height - Main.npcTexture[npc.type].Height * npc.scale / Main.npcFrameCount[npc.type] + 4f + origin.Y * npc.scale + npc.gfxOffY);

            SpriteEffects effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(drawTexture, drawPos, npc.frame, Color.White, npc.rotation, origin, npc.scale, effects, 0);

            return false;
        }
    }
}
