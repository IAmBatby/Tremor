using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
    public class projBoneHook : ModProjectile
    {
        const int HookTime = 50; // "Длина" хука
        const float BackSpeedMulti = 0.75f; // Множитель скорости возвращения хука
        int TimeToHook = HookTime;
        int NPC = -1;

        public override void SetDefaults()
        {

            projectile.width = 42;
            projectile.height = 38;
            projectile.timeLeft = 36000;
            projectile.melee = true;
            projectile.aiStyle = 13;
            projectile.penetrate = -1;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Bone Hook");
       
    }

        
        public override void AI()
        {
            if (--TimeToHook <= 0)
            {
                projectile.ai[0] = 1;
                projectile.velocity *= BackSpeedMulti;
            }
            else
                projectile.ai[0] = 0;
            projectile.rotation = Helper.rotateBetween2Points(projectile.position, Main.player[projectile.owner].position) + Helper.GradtoRad(45);
            if (NPC != -1 && projectile.Distance(Main.player[projectile.owner].position) > 64)
            {
                Main.npc[NPC].Center = projectile.position;
                if (!Main.npc[NPC].active)
                    NPC = -1;
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            spriteBatch.Draw(Main.projectileTexture[projectile.type], new Rectangle((int)(projectile.position - Main.screenPosition).X, (int)(projectile.position - Main.screenPosition).Y, projectile.width, projectile.height), null, lightColor, projectile.rotation, new Vector2(projectile.width / 2, projectile.height / 2), SpriteEffects.None, 0);
            return false;
        }

        public override bool? CanHitNPC(NPC target)
        {
            return true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (NPC == -1 && !target.boss && !target.friendly && target.lifeMax > 5 && target.aiStyle != 6)
                NPC = target.whoAmI;
            TimeToHook = 1;
            base.OnHitNPC(target, damage, knockback, crit);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            TimeToHook = 1;
            return base.OnTileCollide(oldVelocity);
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            TimeToHook = 1;
            base.OnHitPlayer(target, damage, crit);
        }

        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            TimeToHook = 1;
            base.OnHitPvp(target, damage, crit);
        }
    }
}
