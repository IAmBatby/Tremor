using Terraria.ID;
using Terraria;
using System;
using System.IO;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tremor.NPCs
{
    public class CogLordGun : ModNPC
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cog Lord Gun");
		}
 
        const int ShootRate = 120;
        const int ShootDamage = 20;
        const float ShootKN = 1.0f;
        const int ShootType = 88;
        const float ShootSpeed = 5;
        const int ShootCount = 10;
        const int spread = 45;
        const float spreadMult = 0.045f;
        const float MaxDist = 250f;

        int TimeToShoot = ShootRate;

        public override void SetDefaults()
        {
            npc.lifeMax = 20000;
            npc.damage = 80;
            npc.defense = 20;
            npc.knockBackResist = 0f;
            npc.width = 88;
            npc.height = 46;
            npc.aiStyle = 12;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.value = Item.buyPrice(0, 0, 5, 0);
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CogLordGun"), 1f);

            }
        }

        bool FirstAI = true;
        public override void AI()
        {
            if (FirstAI)
            {
                FirstAI = false;
                MakeArms();
            }
            if (Main.npc[(int)npc.ai[1]].type == mod.NPCType("CogLord") && Main.npc[(int)npc.ai[1]].active)
                if (Main.player[Main.npc[(int)npc.ai[1]].target].active)
                {
                    if (npc.localAI[3] == 0f)
                    {
                        npc.rotation = Helper.rotateBetween2Points(npc.Center, Main.player[Main.npc[(int)npc.ai[1]].target].Center);
                        if (--TimeToShoot <= 0) Shoot();
                    }
                }
            if (NPC.AnyNPCs(mod.NPCType("CogLordProbe")))
            {
                npc.dontTakeDamage = true;
            }
            else
            {
                npc.dontTakeDamage = false;
            }
            Vector2 CogLordCenter = Main.npc[(int)npc.ai[1]].Center;
            Vector2 Distance = npc.Center - CogLordCenter;
            if (Distance.Length() >= MaxDist)
            {
                Distance.Normalize();
                Distance *= MaxDist;
                npc.Center = CogLordCenter + Distance;
            }
        }

        void MakeArms()
        {
            int Arm = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("CogLordArm"), 0, 9999, 1, 1, npc.ai[1]);
            int Arm2 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("CogLordArmSecond"), 0, npc.whoAmI, 0, 1, Arm);
            Main.npc[Arm].ai[0] = Arm2;
        }

        void Shoot()
        {
            TimeToShoot = ShootRate;
            if (Main.npc[(int)npc.ai[1]].target != -1)
            {
                Vector2 velocity = Helper.VelocityToPoint(npc.Center, Main.player[Main.npc[(int)npc.ai[1]].target].Center, ShootSpeed);
                for (int l = 0; l < 2; l++)
                {
                    velocity.X = velocity.X + (float)Main.rand.Next(-spread, spread + 1) * spreadMult;
                    velocity.Y = velocity.Y + (float)Main.rand.Next(-spread, spread + 1) * spreadMult;
                    int i = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, velocity.X, velocity.Y, ShootType, ShootDamage, ShootKN);
                    Main.projectile[i].hostile = true;
                    Main.projectile[i].friendly = false;
                }
            }
        }

        public override bool PreNPCLoot()
        {
            npc.aiStyle = -1;
            npc.ai[1] = -1;
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