using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NovaPillar.NPCs
{
	public class Varki : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Warkee");
			Main.npcFrameCount[npc.type] = 2;
		}

		//Int variables
		int AnimationRate = 4;
		int CountFrame;
		int TimeToAnimation = 4;
		int Timer;
		public override void SetDefaults()
		{
			npc.lifeMax = 750;
			npc.damage = 300;
			npc.defense = 25;
			npc.knockBackResist = 0.34f;
			npc.width = 26;
			npc.height = 34;
			npc.aiStyle = 14;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit55;
			npc.DeathSound = SoundID.NPCDeath51;
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = npc.lifeMax * 1;
			npc.damage = npc.damage * 1;
		}

		public override void AI()
		{
			if(Main.player[npc.target].GetModPlayer<TremorPlayer>(mod).ZoneRuins)
			{
				npc.life=-1;
				npc.active=false;
				npc.checkDead();
				return;
			}
			npc.spriteDirection = npc.direction;
			Timer++;
			if (Timer == 2000)
			{
				npc.Transform(mod.NPCType("Youwarkee2"));
			}
			NovaAnimation();
		}

		public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			TremorUtils.DrawNPCGlowMask(spriteBatch, npc, mod.GetTexture("NovaPillar/NPCs/Varki_GlowMask"));
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				if (NovaHandler.ShieldStrength > 0)
				{
					NPC parent = Main.npc[NPC.FindFirstNPC(mod.NPCType("NovaPillar"))];
					Vector2 Velocity = Helper.VelocityToPoint(npc.Center, parent.Center, 20);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Velocity.X, Velocity.Y, mod.ProjectileType("CogLordLaser"), 1, 1f);
				}
				for (int i = 0; i < 5; i++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 57, Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(-3f, 3f));
				}
				for (int i = 0; i < 2; i++)
				{
					Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/VarkiGore1"));
					Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/VarkiGore2"));
				}
				Gore.NewGore(npc.Top, npc.velocity * hitDirection, mod.GetGoreSlot("Gores/VarkiGore3"));
				for (int k = 0; k < 7; k++)
				{
					Vector2 Vector = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
					Vector.Normalize();
					Vector *= Main.rand.Next(10, 201) * 0.01f;
					int i = Projectile.NewProjectile(npc.position.X, npc.position.Y, Vector.X, Vector.Y, mod.ProjectileType("NovaAlchemistCloud"), 20, 1f, Main.myPlayer, 0f, Main.rand.Next(-45, 1));
					Main.projectile[i].friendly = false;
				}
			}
		}

		void NovaAnimation()
		{
			if (--TimeToAnimation <= 0)
			{
				if (++CountFrame > 2)
					CountFrame = 1;
				TimeToAnimation = AnimationRate;
				npc.frame = GetFrame(CountFrame + 0);
			}
		}

		Rectangle GetFrame(int Number)
		{
			return new Rectangle(0, npc.frame.Height * (Number - 1), npc.frame.Width, npc.frame.Height);
		}
	}
}