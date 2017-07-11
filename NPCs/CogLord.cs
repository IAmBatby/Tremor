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
	[AutoloadBossHead]
    public class CogLord : ModNPC
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cog Lord");
			Main.npcFrameCount[npc.type] = 5;
		}
 
        //Framework
        Vector2 CogHands = new Vector2(-1, -1);

        //Bool variables
        bool Ram
        {
            get { return ((this.CogHands.X == -1 && this.CogHands.Y == -1) || npc.ai[1] == 1); }
        }
        bool FirstAI = true;
        bool SecondAI = true;
        bool NeedCheck = false;
        bool Flag = true;
        bool Flag1 = true;
        bool Flag2 = true;
        bool Rockets = true;

        //Float variables
        float DistanseBlood = 150f;
        float RotationSpeed = 0.3f;
        float Rotation = 0.0f;
        float LaserRotation = MathHelper.PiOver2;
        float NewRotation = MathHelper.PiOver2;

        //Int variables
        int GetLaserDamage
        {
            get { return 30; }
        }
        int AnimationRate = 6;
        int CurrentFrame = 0;
        int TimeToAnimation = 6;
        int Timer = 0;
        int Timer2 = 0;
        int ShootType = ProjectileID.HeatRay;
        int LaserPosition = 20;
        int ShootRate = 10;
        int TimeToShoot = 4;
        float PreviousRageRotation = 0;

        //String variables
        string LeftHandName = "CogLordHand"; 
        string RightHandName = "CogLordGun"; 
        public override void SetDefaults()
        {
            npc.lifeMax = 45000;
            npc.damage = 25;
            npc.defense = 5;
            npc.knockBackResist = 0.0f;
            npc.width = 86;
            npc.height = 124;
            npc.aiStyle = 11;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath10;
            npc.boss = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Boss6");
            bossBag = mod.ItemType("CogLordBag");
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.6f);
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            spriteBatch.Draw(mod.GetTexture("NPCs/CogLordBody"), npc.Center - Main.screenPosition, null, Color.White, 0f, new Vector2(44, -18), 1f, SpriteEffects.None, 0f);
            Texture2D drawTexture = Main.npcTexture[npc.type];
            Vector2 origin = new Vector2((drawTexture.Width / 2) * 0.5F, (drawTexture.Height / Main.npcFrameCount[npc.type]) * 0.5F);
            Vector2 drawPos = new Vector2(
                npc.position.X - Main.screenPosition.X + (npc.width / 2) - (Main.npcTexture[npc.type].Width / 2) * npc.scale / 2f + origin.X * npc.scale,
                npc.position.Y - Main.screenPosition.Y + npc.height - Main.npcTexture[npc.type].Height * npc.scale / Main.npcFrameCount[npc.type] + 4f + origin.Y * npc.scale + npc.gfxOffY);
            SpriteEffects effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(drawTexture, drawPos, npc.frame, Color.White, npc.rotation, origin, npc.scale, effects, 0);
            return false;
        }

        public override void AI()
        {
            npc.TargetClosest();
            if (Main.dayTime)
            {
                this.Timer = 0;
            }
            if (NPC.AnyNPCs(mod.NPCType("CogLordProbe")))
            {
                npc.dontTakeDamage = true;
            }
            else
                npc.dontTakeDamage = false;
            if (!Main.expertMode)
                npc.position += npc.velocity * 1.7f;
            else
                npc.position += npc.velocity * 1.02f;
            this.Timer++;
            this.Animation();
            for (int i = 0; i < Main.dust.Length; i++)
            {
                if (Main.dust[i].type == DustID.Blood && npc.Distance(Main.dust[i].position) < this.DistanseBlood)
                {
                    Main.dust[i].scale /= 1000000f;
                    Main.dust[i].active = false;
                }
            }
            foreach (NPC npc2 in Main.npc)
            {
                if (npc2.type == 36)
                {
                    npc2.active = false;
                    npc2.life = 0;
                    npc2.checkDead();
                }
            }
            foreach (var proj in Main.projectile)
            {
                if (proj.type == ProjectileID.Skull && Vector2.Distance(proj.Center, npc.Center) < 100f)
                {
                    proj.active = false;
                }
            }
            if (npc.life < npc.lifeMax * 0.6f && Flag)
            {
                Flag = false;
                if (Main.expertMode)
                    this.CogMessage("Low health is detected. Launching support drones.");
                else
                    this.CogMessage("Low health is detected. Launching support drone.");
                if (Main.expertMode)
                    NPC.NewNPC((int)npc.Center.X - 100, (int)npc.Center.Y - 100, mod.NPCType("CogLordProbe"), 0, npc.whoAmI, 0, 200);
                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("CogLordProbe"), 0, npc.whoAmI, 0, 200);
            }
            if (npc.life < npc.lifeMax * 0.4f && Flag1)
            {
                Flag1 = false;
                if (Main.expertMode)
                    this.CogMessage("Low health is detected. Launching support drones.");
                else
                    this.CogMessage("Low health is detected. Launching support drone.");
                if (Main.expertMode)
                    NPC.NewNPC((int)npc.Center.X - 100, (int)npc.Center.Y - 100, mod.NPCType("CogLordProbe"), 0, npc.whoAmI, 0, 200);
                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("CogLordProbe"), 0, npc.whoAmI, 0, 200);
            }
            if (npc.life < npc.lifeMax * 0.2f && Flag2)
            {
                Flag2 = false;
                if (Main.expertMode)
                    this.CogMessage("Low health is detected. Launching support drones.");
                else
                    this.CogMessage("Low health is detected. Launching support drone.");
                if (Main.expertMode)
                    NPC.NewNPC((int)npc.Center.X - 100, (int)npc.Center.Y - 100, mod.NPCType("CogLordProbe"), 0, npc.whoAmI, 0, 200);
                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("CogLordProbe"), 0, npc.whoAmI, 0, 200);
            }
            if (this.FirstAI)
            {
                this.FirstAI = false;
            }
            else
            {
                if (this.SecondAI)
                {
                    this.MakeHands();
                    this.SecondAI = false;
                    this.NeedCheck = true;
                }
            }
            if (!this.Ram)
            {
                if (this.NeedCheck)
                    this.CheckHands();
                if (this.CogHands.Y != -1 && this.NeedCheck)
                {
                    Main.npc[(int)this.CogHands.Y].localAI[3] = 0;
                }
            }
            else
            {
                if (this.Rockets)
                {
                    this.Rockets = false;
                    this.CogMessage("Protocol 10 is activated: Preparing for rocket storm.");
                }
                npc.frame = GetFrame(5);
                this.Rotation += this.RotationSpeed;
                npc.rotation = this.Rotation;
                if ((int)(Main.time % 120) == 0)
                {
                    for (int k = 0; k < ((Main.expertMode) ? 2 : 1); k++)
                    {
                        Vector2 Velocity = Helper.VelocityToPoint(npc.Center, Helper.RandomPointInArea(new Vector2(Main.player[Main.myPlayer].Center.X - 10, Main.player[Main.myPlayer].Center.Y - 10), new Vector2(Main.player[Main.myPlayer].Center.X + 20, Main.player[Main.myPlayer].Center.Y + 20)), 20);
                        int i = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Velocity.X, Velocity.Y, 134, (int)(this.GetLaserDamage * ((Main.expertMode) ? 3 : 2)), 1f);
                        Main.projectile[i].hostile = true;
                        Main.projectile[i].tileCollide = true;
                        Main.projectile[i].friendly = false;
                    }
                }
                if (this.NeedCheck)
                    this.CheckHands();
                if (this.CogHands.Y != -1 && this.NeedCheck)
                {
                    Main.npc[(int)this.CogHands.Y].localAI[3] = 1;
                }
            }
            if (this.Timer == 400)
            {
                this.CogMessage("Protocol 11 is activated: Clockwork laser cutter is being enabled.");
            }
            if (this.Timer >= 500 && this.Timer < 800)
            {
                this.PreviousRageRotation = 0f;
                if (Main.netMode != 1)
                {
                    this.LaserRotation += 0.01f;
                    if (--this.TimeToShoot <= 0)
                    {
                        this.TimeToShoot = this.ShootRate;
                        var ShootPos = npc.Center + new Vector2(0, 17);
                        var ShootVel = new Vector2(0, 7).RotatedBy(LaserRotation);
                        int[] i = new int[]
                        {
                            Projectile.NewProjectile(ShootPos, ShootVel, this.ShootType, this.GetLaserDamage, 1f),
                            Projectile.NewProjectile(ShootPos, ShootVel.RotatedBy(MathHelper.PiOver2), this.ShootType, this.GetLaserDamage, 1f),
                            Projectile.NewProjectile(ShootPos, ShootVel.RotatedBy(MathHelper.Pi), this.ShootType, this.GetLaserDamage, 1f),
                            Projectile.NewProjectile(ShootPos, ShootVel.RotatedBy(-MathHelper.PiOver2), this.ShootType, this.GetLaserDamage, 1f)
                        };
                        for (int l = 0; l < i.Length; l++)
                        {
                            Main.projectile[i[l]].hostile = true;
                            Main.projectile[i[l]].tileCollide = false;
                        }
                    }
                }
            }
            if (this.Timer >= 800 && this.Timer < 1200)
            {
                npc.velocity.X *= 2.00f;
                npc.velocity.Y *= 2.00f;
                Vector2 Vector = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height * 0.5f));
                {
                    float CLRad = (float)Math.Atan2((Vector.Y) - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), (Vector.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                    npc.velocity.X = (float)(Math.Cos(CLRad) * 4) * -1;
                    npc.velocity.Y = (float)(Math.Sin(CLRad) * 4) * -1;
                }
            }
            if (this.Timer == 1100)
            {
                this.CogMessage("Protocol 12 is activated: Summoning gears.");
            }
            if (this.Timer > 1200 && this.Timer < 1700)
            {
                if ((int)(Main.time % 15) == 0)
                    NPC.NewNPC((int)((Main.player[npc.target].position.X - 500) + Main.rand.Next(1000)), (int)((Main.player[npc.target].position.Y - 500) + Main.rand.Next(1000)), mod.NPCType("GogLordGog"));
            }
            if (this.Timer == 1600)
            {
                this.CogMessage("Protocol 13 is activated: Rocket attack incoming.");
            }
            if (this.Timer >= 1700 && this.Timer < 1775)
            {
                if (Helper.Chance(0.3f))
                {
                    var ShootPos = Main.player[npc.target].position + new Vector2(Main.rand.Next(-1000, 1000), -1000);
                    var ShootVel = new Vector2(Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(15f, 20f));
                    int i = Projectile.NewProjectile(ShootPos, ShootVel, 134, (int)(this.GetLaserDamage * ((Main.expertMode) ? 3 : 2)), 1f);
                    Main.projectile[i].hostile = true;
                    Main.projectile[i].tileCollide = true;
                    Main.projectile[i].friendly = false;
                }
            }
            if (this.Timer > 1775)
            {
                this.Rockets = true;
                this.Timer = 0;
            }
            this.Rotation = 0;
        }

        public void CheckHands()
        {
            if (this.CogHands.X != -1)
                if (!((Main.npc[(int)this.CogHands.X].type == mod.NPCType(this.LeftHandName) && Main.npc[(int)this.CogHands.X].ai[1] == npc.whoAmI) && Main.npc[(int)this.CogHands.X].active))
                    this.CogHands.X = -1;
            if (this.CogHands.Y != -1)
                if (!((Main.npc[(int)this.CogHands.Y].type == mod.NPCType(this.RightHandName) && Main.npc[(int)this.CogHands.Y].ai[1] == npc.whoAmI) && Main.npc[(int)this.CogHands.Y].active))
                    this.CogHands.Y = -1;
        }

        public void MakeHands()
        {
            this.CogHands.X = NPC.NewNPC((int)npc.Center.X - 50, (int)npc.Center.Y, mod.NPCType(LeftHandName), 0, 1, npc.whoAmI);
            this.CogHands.Y = NPC.NewNPC((int)npc.Center.X + 50, (int)npc.Center.Y, mod.NPCType(RightHandName), 0, -1, npc.whoAmI);
        }

        public void Animation()
        {
            if (--TimeToAnimation <= 0)
            {
                if (++CurrentFrame > 4)
                    CurrentFrame = 1;
                TimeToAnimation = AnimationRate;
                npc.frame = GetFrame(CurrentFrame);
            }
        }

        Rectangle GetFrame(int Number)
        {
            return new Rectangle(0, npc.frame.Height * (Number - 1), npc.frame.Width, npc.frame.Height);
        }

        public void CogMessage(string Message)
        {
            string Text = "[CL-AI]: " + Message;
            if (Main.netMode != 2)
            {
                Main.NewText("[CL-AI]: " + Message, 208, 137, 55);
            }
            else
            {
                //NetMessage.SendData(25, -1, -1, Text, 208, 137, 55, 150);
            }
        }
        public override void NPCLoot()
        {
			TremorWorld.downedCogLord = true;
            if (Main.netMode != 1)
            {
                if (Main.expertMode)
                {
                    npc.DropBossBags();
                }
                if (!Main.expertMode && Main.rand.Next(10) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrassChip"));
                }
                if (!Main.expertMode && Main.rand.Next(7) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CogLordMask"));
                }
                if (!Main.expertMode && Main.rand.Next(3) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrassRapier"));
                }
                if (!Main.expertMode && Main.rand.Next(3) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrassChainRepeater"));
                }
                if (!Main.expertMode && Main.rand.Next(3) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrassStave"));
                }
                if (Main.rand.Next(10) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CogLordTrophy"));
                }
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 499, Main.rand.Next(6, 25));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 500, Main.rand.Next(6, 25));
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrassNugget"), Main.rand.Next(18, 32));
            }
        }
    }
}