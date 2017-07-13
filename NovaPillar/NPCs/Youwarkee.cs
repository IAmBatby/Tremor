using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NovaPillar.NPCs
{
	public class Youwarkee : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Yuwarkee");
			Main.npcFrameCount[npc.type] = 4;
		}

		//Int variables
		int AnimationRate = 4;
		int CountFrame;
		int TimeToAnimation = 4;
		int Timer;
		public override void SetDefaults()
		{
			npc.lifeMax = 1750;
			npc.damage = 81;
			npc.defense = 35;
			npc.knockBackResist = 0.96f;
			npc.width = 66;
			npc.height = 68;
			npc.HitSound = SoundID.NPCHit55;
			npc.DeathSound = SoundID.NPCDeath51;
			npc.buffImmune[31] = false;
			npc.npcSlots = 2f;
			npc.noGravity = true;
			npc.noTileCollide = true;
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = npc.lifeMax * 1;
			npc.damage = npc.damage * 1;
		}

		const float Speed = 4f;
		const float Acceleration = 0.27f;

		int k;
		public override void AI()
		{
			Player player=Main.player[npc.target];
			if(player.GetModPlayer<TremorPlayer>(mod).ZoneRuins)
			{
				npc.life=-1;
				npc.active=false;
				npc.checkDead();
				return;
			}
			Vector2 StartPosition = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
			float DirectionX = player.position.X + player.width / 2 - StartPosition.X;
			float DirectionY = player.position.Y + (player.height / 2) - 120 - StartPosition.Y;
			float Length = (float)Math.Sqrt(DirectionX * DirectionX + DirectionY * DirectionY);
			float Num = Speed / Length;
			DirectionX = DirectionX * Num;
			DirectionY = DirectionY * Num;
			if (npc.velocity.X < DirectionX)
			{
				npc.velocity.X = npc.velocity.X + Acceleration;
				if (npc.velocity.X < 0 && DirectionX > 0)
					npc.velocity.X = npc.velocity.X + Acceleration;
			}
			else if (npc.velocity.X > DirectionX)
			{
				npc.velocity.X = npc.velocity.X - Acceleration;
				if (npc.velocity.X > 0 && DirectionX < 0)
					npc.velocity.X = npc.velocity.X - Acceleration;
			}
			if (npc.velocity.Y < DirectionY)
			{
				npc.velocity.Y = npc.velocity.Y + Acceleration;
				if (npc.velocity.Y < 0 && DirectionY > 0)
					npc.velocity.Y = npc.velocity.Y + Acceleration;
			}
			else if (npc.velocity.Y > DirectionY)
			{
				npc.velocity.Y = npc.velocity.Y - Acceleration;
				if (npc.velocity.Y > 0 && DirectionY < 0)
					npc.velocity.Y = npc.velocity.Y - Acceleration;
			}
			if (Main.rand.Next(46) == 1)
			{
				Vector2 StartPosition2 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
				float AndasRotation = (float)Math.Atan2(StartPosition2.Y - (player.position.Y + (player.height * 0.5f)), StartPosition2.X - (player.position.X + (player.width * 0.5f)));
				npc.velocity.X = (float)(Math.Cos(AndasRotation) * 15) * -1;
				npc.velocity.Y = (float)(Math.Sin(AndasRotation) * 15) * -1;
				npc.netUpdate = true;
			}
			Timer++;
			if (Timer >= 700)
			{
				Timer = 0;
			}
			if (NPC.CountNPCS(k) < 3 && Timer % 200 == 0)
			{
				k = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("Varki"), 0, npc.whoAmI, 0, 200);
			}
			npc.rotation = npc.velocity.X * 0.1f;
			NovaAnimation();
		}

		public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			TremorUtils.DrawNPCGlowMask(spriteBatch, npc, mod.GetTexture("NovaPillar/NPCs/Youwarkee_GlowMask"));
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
					Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/YouwarkeeGore1"));
					Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/YouwarkeeGore2"));
				}
				Gore.NewGore(npc.Top, npc.velocity * hitDirection, mod.GetGoreSlot("Gores/YouwarkeeGore3"));
				Gore.NewGore(npc.Top, npc.velocity * hitDirection, mod.GetGoreSlot("Gores/YouwarkeeGore3"));
			}
		}

		void NovaAnimation()
		{
			if (--TimeToAnimation <= 0)
			{
				if (++CountFrame > 4)
					CountFrame = 1;
				TimeToAnimation = AnimationRate;
				npc.frame = GetFrame(CountFrame + 0);
			}
		}

		Rectangle GetFrame(int Number)
		{
			return new Rectangle(0, npc.frame.Height * (Number - 1), npc.frame.Width, npc.frame.Height);
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.player.GetModPlayer<TremorPlayer>(mod).ZoneTowerNova)
				return 1f;
			return 0;
		}
	}
}
