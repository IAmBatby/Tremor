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
    public class CogLordHand : ModNPC
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cog Lord Hand");
		}
 
        public override void SetDefaults()
        {
            npc.lifeMax = 20000;
            npc.damage = 80;
            npc.defense = 20;
            npc.knockBackResist = 0f;
            npc.width = 44;
            npc.height = 84;
            npc.aiStyle = 12;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            Main.npcFrameCount[npc.type] = 2;
            npc.value = Item.buyPrice(0, 0, 5, 0);
        }

        const float MaxDist = 250f;
        bool FirstAI = true;
        int timer = 0;
        public override void AI()
        {
            timer++;
            if (FirstAI)
            {
                FirstAI = false;
                MakeArms();
            }
            if (NPC.AnyNPCs(mod.NPCType("CogLordProbe")))
            {
                npc.dontTakeDamage = true;
            }
            else
                npc.dontTakeDamage = false;
            if (timer < 1000)
            {
                npc.frame = GetFrame(1);
                npc.damage = 80;
            }
            if (timer >= 1000 && timer < 1500)
            {
                npc.frame = GetFrame(2);
                npc.dontTakeDamage = true;
                npc.damage = 120;
            }
            if (timer > 1500)
            {
                timer = 0;
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

        Rectangle GetFrame(int Number)
        {
            return new Rectangle(0, npc.frame.Height * (Number - 1), npc.frame.Width, npc.frame.Height);
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CogLordHand"), 1f);
            }
        }

        void MakeArms()
        {
            int Arm = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("CogLordArm"), 0, 9999, 1, 1, npc.ai[1]);
            int Arm2 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("CogLordArmSecond"), 0, npc.whoAmI, 0, 1, Arm);
            Main.npc[Arm].ai[0] = Arm2;
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