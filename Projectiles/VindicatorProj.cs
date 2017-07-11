using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{

	public class VindicatorProj : ModProjectile
    {
        public override void SetDefaults()
        {

            projectile.width = 26;
            projectile.height = 76;
            //Main.projFrames[projectile.type] = 6;
            //projectile.aiStyle = 20;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.hide = true;
            projectile.ownerHitCheck = true;
            projectile.ranged = true;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Vindicator");
       
    }


        public override void AI()
        {
            Vector2 vector22;
            float num263;
            Vector2 vector23;
            float num264;
            float num265;
            float num266;
            int num267;
            vector22 = Main.player[projectile.owner].RotatedRelativePoint(Main.player[projectile.owner].MountedCenter, true);
            if (Main.myPlayer == projectile.owner)
            {
                if (Main.player[projectile.owner].channel)
                {
                    num263 = Main.player[projectile.owner].inventory[Main.player[projectile.owner].selectedItem].shootSpeed * projectile.scale;
                    vector23 = vector22;
                    num264 = (float)Main.mouseX + Main.screenPosition.X - vector23.X - 20;
                    num265 = (float)Main.mouseY + Main.screenPosition.Y - vector23.Y;
                    if (Main.player[projectile.owner].gravDir == -1f)
                    {
                        num265 = (float)(Main.screenHeight - Main.mouseY) + Main.screenPosition.Y - vector23.Y;
                    }
                    num266 = (float)Math.Sqrt((double)(num264 * num264 + num265 * num265));
                    num266 = (float)Math.Sqrt((double)(num264 * num264 + num265 * num265));
                    num266 = num263 / num266;
                    num264 *= num266;
                    num265 *= num266;
                    if (num264 != projectile.velocity.X || num265 != projectile.velocity.Y)
                    {
                        projectile.netUpdate = true;
                    }
                    projectile.velocity.X = num264;
                    projectile.velocity.Y = num265;
                }
                else
                {
                    projectile.Kill();
                }
            }
            if (projectile.velocity.X > 0f)
            {
                Main.player[projectile.owner].ChangeDir(1);
            }
            else if (projectile.velocity.X < 0f)
            {
                Main.player[projectile.owner].ChangeDir(-1);
            }
            projectile.spriteDirection = projectile.direction;
            Main.player[projectile.owner].ChangeDir(projectile.direction);
            Main.player[projectile.owner].heldProj = projectile.whoAmI;
            Main.player[projectile.owner].itemTime = 2;
            Main.player[projectile.owner].itemAnimation = 2;
            projectile.position.X = vector22.X - (float)(projectile.width / 2);
            projectile.position.Y = vector22.Y - (float)(projectile.height / 2);
            projectile.rotation = (float)(Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.5700000524520874);
            if (Main.player[projectile.owner].direction == 1)
            {
                Main.player[projectile.owner].itemRotation = (float)Math.Atan2((double)(projectile.velocity.Y * (float)projectile.direction), (double)(projectile.velocity.X * (float)projectile.direction));
            }
            else
            {
                Main.player[projectile.owner].itemRotation = (float)Math.Atan2((double)(projectile.velocity.Y * (float)projectile.direction), (double)(projectile.velocity.X * (float)projectile.direction));
            }
            projectile.velocity.X = projectile.velocity.X * (1f + (float)Main.rand.Next(-3, 4) * 0.01f);
            Player player = Main.player[projectile.owner];
            float num = 1.57079637f;
            Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
            projectile.ai[0] += 1f;
            int num2 = 0;
            if (projectile.ai[0] >= 40f)
            {
                num2++;
            }
            if (projectile.ai[0] >= 80f)
            {
                num2++;
            }
            if (projectile.ai[0] >= 120f)
            {
                num2++;
            }
            int num3 = 24;
            int num4 = 6;
            projectile.ai[1] += 1f;
            bool flag = false;
            if (projectile.ai[1] >= (float)(num3 - num4 * num2))
            {
                projectile.ai[1] = 0f;
                flag = true;
            }
            projectile.frameCounter += 1 + num2;
            if (projectile.frameCounter >= 4)
            {
                projectile.frameCounter = 0;
                projectile.frame++;
                if (projectile.frame >= 6)
                {
                    projectile.frame = 0;
                }
            }
            if (projectile.soundDelay <= 0)
            {
                projectile.soundDelay = num3 - num4 * num2;
                if (projectile.ai[0] != 1f)
                {

                }
            }
            if (projectile.ai[1] == 1f && projectile.ai[0] != 1f)
            {
                Vector2 vector2 = Vector2.UnitX * 24f;
                vector2 = vector2.RotatedBy((double)(projectile.rotation - 1.57079637f), default(Vector2));
                Vector2 value = projectile.Center + vector2;
                for (int i = 0; i < 2; i++)
                {
                    int num5 = Dust.NewDust(value - Vector2.One * 8f, 16, 16, mod.DustType("CryotechDust"), projectile.velocity.X / 2f, projectile.velocity.Y / 2f, 100, default(Color), 1f);
                    Main.dust[num5].velocity *= 0.66f;
                    Main.dust[num5].noGravity = true;
                    Main.dust[num5].scale = 1.4f;
                }
            }
            if (flag && Main.myPlayer == projectile.owner)
            {
                bool flag2 = player.channel && player.CheckMana(player.inventory[player.selectedItem].mana, true, false) && !player.noItems && !player.CCed;
                if (flag2)
                {
                    float scaleFactor = player.inventory[player.selectedItem].shootSpeed * projectile.scale;
                    Vector2 value2 = vector;
                    Vector2 value3 = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY) - value2;
                    if (player.gravDir == -1f)
                    {
                        value3.Y = (float)(Main.screenHeight - Main.mouseY) + Main.screenPosition.Y - value2.Y;
                    }
                    Vector2 vector3 = Vector2.Normalize(value3);
                    if (float.IsNaN(vector3.X) || float.IsNaN(vector3.Y))
                    {
                        vector3 = -Vector2.UnitY;
                    }
                    vector3 *= scaleFactor;
                    if (vector3.X != projectile.velocity.X || vector3.Y != projectile.velocity.Y)
                    {
                        projectile.netUpdate = true;
                    }
                    projectile.velocity = vector3;
                    int num6 = 14;
                    float scaleFactor2 = 28f;
                    int num7 = 7;
                    for (int j = 0; j < 2; j++)
                    {
                        value2 = projectile.Center + new Vector2((float)Main.rand.Next(-num7, num7 + 1), (float)Main.rand.Next(-num7, num7 + 1));
                        Vector2 spinningpoint = Vector2.Normalize(projectile.velocity) * scaleFactor2;
                        spinningpoint = spinningpoint.RotatedBy(Main.rand.NextDouble() * 0.19634954631328583 - 0.098174773156642914, default(Vector2));
                        if (float.IsNaN(spinningpoint.X) || float.IsNaN(spinningpoint.Y))
                        {
                            spinningpoint = -Vector2.UnitY;
                        }
                        Projectile.NewProjectile(value2.X + 10, value2.Y + 10, spinningpoint.X, spinningpoint.Y, num6, projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
                    }
                }
                else
                {
                    projectile.Kill();
                }
            }
        }
    }
}
