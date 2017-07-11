using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs.AndasBoss
{
	[AutoloadBossHead]
	public class Andas : ModNPC
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Andas");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.aiStyle = -1;
			npc.width = 66;
			npc.height = 88;
			npc.damage = 52;
			npc.defense = 170;
			npc.lifeMax = 90000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath5;
			npc.knockBackResist = 0f;
			npc.noTileCollide = true;
			npc.noGravity = true;
			npc.boss = true;
			music = MusicID.Boss3;
			npc.buffImmune[24] = true;
			npc.buffImmune[67] = true;
			npc.lavaImmune = true;
		}

		#region Settings AI
		const int ShootType = 467;
		const int ShootDamage = 40;
		const float ShootKnockback = 0.8554f;
		const int ShootCount = 5;
		const int ShootSpeed = 3;
		const int ShootDirection = 7;
		const float Speed = 14f;
		const float Acceleration = 0.1f;
		int Timer;
		#endregion
		public override void AI()
		{
			npc.TargetClosest(true);
			npc.spriteDirection = npc.direction;
			Player player = Main.player[npc.target];
			if (player.dead || !player.active)
			{
				npc.TargetClosest(false);
				npc.active = false;
			}
			Timer++;
			if (Timer >= 0)
			{
				if ((int)(Main.time % 90) == 0)
				{
					Vector2 Velocity = Helper2.VelocityFPTP(npc.Center, new Vector2(Main.player[npc.target].Center.X, Main.player[npc.target].Center.Y + 20), 10);
					int Spread = 65;
					float SpreadMult = 0.05f;
					Velocity.X = Velocity.X + Main.rand.Next(-Spread, Spread + 1) * SpreadMult;
					Velocity.Y = Velocity.Y + Main.rand.Next(-Spread, Spread + 1) * SpreadMult;
					int i = Projectile.NewProjectile(npc.Center.X, npc.Center.Y + 20, Velocity.X, Velocity.Y, 258, ShootDamage, ShootKnockback);
					Main.projectile[i].hostile = true;
					Main.projectile[i].friendly = true;
					Main.projectile[i].tileCollide = false;
				}
			}
			if (Timer >= 0 && Timer <= 1000) //flight
			{
				Vector2 StartPosition = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
				float DirectionX = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - StartPosition.X;
				float DirectionY = Main.player[npc.target].position.Y + (Main.player[npc.target].height / 2) - 120 - StartPosition.Y;
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
				if (Main.rand.Next(36) == 1)
				{
					Vector2 StartPosition2 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
					float AndasRotation = (float)Math.Atan2(StartPosition2.Y - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), StartPosition2.X - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
					npc.velocity.X = (float)(Math.Cos(AndasRotation) * 18) * -1;
					npc.velocity.Y = (float)(Math.Sin(AndasRotation) * 18) * -1;
					npc.netUpdate = true;
				}
			}

			if (Timer == 700)
			{
				for (int i = 0; i < 50; i++)
				{
					int dust = Dust.NewDust(npc.position, npc.width, npc.height, 6);
					Main.dust[dust].scale = 1.5f;
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 0f;
					Main.dust[dust].velocity *= 0f;
				}
				DoAndasShoot();
				npc.position.X = (Main.player[npc.target].position.X - 500) + Main.rand.Next(1000);
				npc.position.Y = (Main.player[npc.target].position.Y - 500) + Main.rand.Next(1000);
			}


			if (Timer == 850)
			{
				for (int i = 0; i < 50; i++)
				{
					int dust = Dust.NewDust(npc.position, npc.width, npc.height, 6);
					Main.dust[dust].scale = 1.5f;
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 0f;
					Main.dust[dust].velocity *= 0f;
				}
				DoAndasShoot();
				npc.position.X = (Main.player[npc.target].position.X - 500) + Main.rand.Next(1000);
				npc.position.Y = (Main.player[npc.target].position.Y - 500) + Main.rand.Next(1000);
			}


			if (Timer == 1000)
			{
				for (int i = 0; i < 50; i++)
				{
					int dust = Dust.NewDust(npc.position, npc.width, npc.height, 6);
					Main.dust[dust].scale = 1.5f;
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 0f;
					Main.dust[dust].velocity *= 0f;
				}
				DoAndasShoot();
				npc.position.X = (Main.player[npc.target].position.X - 500) + Main.rand.Next(1000);
				npc.position.Y = (Main.player[npc.target].position.Y - 500) + Main.rand.Next(1000);
			}

			if (Timer == 1150)
			{
				for (int i = 0; i < 50; i++)
				{
					int dust = Dust.NewDust(npc.position, npc.width, npc.height, 6);
					Main.dust[dust].scale = 1.5f;
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 0f;
					Main.dust[dust].velocity *= 0f;
				}
				DoAndasShoot();
				npc.position.X = (Main.player[npc.target].position.X - 500) + Main.rand.Next(1000);
				npc.position.Y = (Main.player[npc.target].position.Y - 500) + Main.rand.Next(1000);
			}

			if (Timer == 1300)
			{
				for (int i = 0; i < 50; i++)
				{
					int dust = Dust.NewDust(npc.position, npc.width, npc.height, 6);
					Main.dust[dust].scale = 1.5f;
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 0f;
					Main.dust[dust].velocity *= 0f;
				}
				DoAndasShoot();
				npc.position.X = (Main.player[npc.target].position.X - 500) + Main.rand.Next(1000);
				npc.position.Y = (Main.player[npc.target].position.Y - 500) + Main.rand.Next(1000);
			}

			if (Timer > 1300)
			{
				Timer = 0;
			}
		}

		void DoAndasShoot()
		{
			Projectile.NewProjectile(npc.position.X + 40, npc.position.Y + 40, -ShootDirection, 0, ShootType, ShootDamage, ShootKnockback, Main.myPlayer, 0f, 0f);
			Projectile.NewProjectile(npc.position.X + 40, npc.position.Y + 40, ShootDirection, 0, ShootType, ShootDamage, ShootKnockback, Main.myPlayer, 0f, 0f);
			Projectile.NewProjectile(npc.position.X + 40, npc.position.Y + 40, 0, ShootDirection, ShootType, ShootDamage, ShootKnockback, Main.myPlayer, 0f, 0f);
			Projectile.NewProjectile(npc.position.X + 40, npc.position.Y + 40, 0, -ShootDirection, ShootType, ShootDamage, ShootKnockback, Main.myPlayer, 0f, 0f);
			Projectile.NewProjectile(npc.position.X + 40, npc.position.Y + 40, -ShootDirection, -ShootDirection, ShootType, ShootDamage, ShootKnockback, Main.myPlayer, 0f, 0f);
			Projectile.NewProjectile(npc.position.X + 40, npc.position.Y + 40, ShootDirection, -ShootDirection, ShootType, ShootDamage, ShootKnockback, Main.myPlayer, 0f, 0f);
			Projectile.NewProjectile(npc.position.X + 40, npc.position.Y + 40, -ShootDirection, ShootDirection, ShootType, ShootDamage, ShootKnockback, Main.myPlayer, 0f, 0f);
			Projectile.NewProjectile(npc.position.X + 40, npc.position.Y + 40, ShootDirection, ShootDirection, ShootType, ShootDamage, ShootKnockback, Main.myPlayer, 0f, 0f);
		}

		public override bool PreNPCLoot()
		{
			return false;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("TrueAndas"));
				Main.PlaySound(15, 0);
			}
		}

		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.15f;
			npc.frameCounter %= Main.npcFrameCount[npc.type];
			int Frame = (int)npc.frameCounter;
			npc.frame.Y = Frame * frameHeight;
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