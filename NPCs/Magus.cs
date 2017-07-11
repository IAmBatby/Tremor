using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
    public class Magus : ModNPC
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magus");
			Main.npcFrameCount[npc.type] = 3;
		}
 
        public override void SetDefaults()
        {
            npc.lifeMax = 290;
            npc.damage = 65;
            npc.defense = 18;
            npc.knockBackResist = 0.3f;
            npc.width = 42;
            npc.height = 56;
            animationType = 29;
            npc.aiStyle = 0;
            npc.npcSlots = 15f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = Item.buyPrice(0, 0, 1, 21);
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 1);
            npc.damage = (int)(npc.damage * 1);
        }

        int timer = 0;
        int TimeToAnimation = 50;
        int Frame = 0;
        public override void AI()
        {
            if ((int)(Main.time % 180) == 0)
            {
                PlayAnimation();
                DoAI();
                Teleport();
            }
        }

        public void PlayAnimation()
        {
            if (--TimeToAnimation <= 0)
            {
                if (++Frame > 3)
                    Frame = 1;
                TimeToAnimation = 50;
                npc.frame = GetFrame(Frame);
            }
        }

        Rectangle GetFrame(int Num)
        {
            return new Rectangle(0, npc.frame.Height * (Num - 1), npc.frame.Width, npc.frame.Height);
        }

        public void Teleport()
        {
            for (int Num = 0; Num < 10; Num++)
            {
                int dust = Dust.NewDust(new Vector2((float)npc.position.X, (float)npc.position.Y), npc.width, npc.height, 68, npc.velocity.X + Main.rand.Next(-10, 10), npc.velocity.Y + Main.rand.Next(-10, 10), 5, npc.color, 2.6f);
                Main.dust[dust].noGravity = true;
            }
            npc.position.X = (Main.player[npc.target].position.X - 500) + Main.rand.Next(1000);
            npc.position.Y = (Main.player[npc.target].position.Y - 500) + Main.rand.Next(1000);
        }

        public void DoAI()
        {
            float SpeedX = Main.LocalPlayer.Center.X - npc.Center.X;
            float SpeedY = Main.LocalPlayer.Center.Y - npc.Center.Y;
            float Length = (float)Math.Sqrt(SpeedX * SpeedX + SpeedY * SpeedY);
            float Speed = 8;
            float Num = Speed / Length;
            SpeedX = SpeedX * Num;
            SpeedY = SpeedY * Num;
            int Proj = Projectile.NewProjectile(npc.Center.X - 10f, npc.Center.Y, SpeedX, SpeedY, mod.ProjectileType("MagusBall"), 14, 1f, Main.myPlayer);
            Main.projectile[Proj].timeLeft = 300;
            Main.projectile[Proj].netUpdate = true;
        }

    public override void NPCLoot()
    {
        if (Main.invasionType == Terraria.ID.InvasionID.GoblinArmy)
        {
                Main.invasionProgress++;
        }
        if (Main.netMode != 1)
        {
            int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
            int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
            int halfLength = npc.width / 2 / 16 + 1;

        if(Main.rand.Next(50) == 0)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MagusTome"));
        }
        }
    }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) 
        { 
            int x = spawnInfo.spawnTileX; 
            int y = spawnInfo.spawnTileY; 
            int tile = (int)Main.tile[x, y].type; 
            return (NPC.AnyNPCs(26) || NPC.AnyNPCs(27) || NPC.AnyNPCs(28) || NPC.AnyNPCs(29)) && Main.hardMode && y < Main.worldSurface ? 0.08f : 0f; 
        }
    }
}