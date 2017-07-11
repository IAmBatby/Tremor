using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace Tremor.Invasion
{
	[AutoloadBossHead]
	public class Titan : ModNPC
	{
		/*
		Интеллект босса состоит из резких рывков. 
		Рывок определяется таймером npc.ai[1]
		Макс. кол-во "тиков" в 	npc.ai[1] = 4500
		Чем меньше у босса здоровья, тем быстрее и сильнее рывки
		С небольшим шансом может сделать комбинацию из рывков (от 1 до 6 рывков подряд)
		Иногда создает кольцо из быстро меняющихся картинок (как у мозга Ктулху)
		Выбирает случайную позицию и встает на место картинки
		Со временем картинки исчезают
		В зависимости от выбранной картинки меняется урон рывка
		Босс не покидает поле сражения, при этом, сделая рывок 6, может улететь
		Рывки 1, 2 и 3 самые безвредные
		Иногда спаунит кристаллы
		*/
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paradox Titan");
			Main.npcFrameCount[npc.type] = 4;
		}


		Vector2 Hands = new Vector2(-1, -1);
		public static readonly int arenaWidth = (int)(1.3f * NPC.sWidth);
		public override void SetDefaults()
		{
			npc.lifeMax = 90000;
			npc.damage = 145;
			npc.defense = 50;
			npc.knockBackResist = 0f;
			npc.noTileCollide = true;
			npc.width = 180;
			npc.height = 200;
			animationType = 82;
			npc.aiStyle = 14;
			npc.npcSlots = 50f;
			npc.HitSound = SoundID.NPCHit31;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = Item.buyPrice(0, 0, 25, 0);
			npc.boss = true;
			bossBag = mod.ItemType("ParadoxTitanBag");
		}

		int draw = -25;
		int draw_ = 75;
		public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			//spriteBatch.Draw(mod.GetTexture("NPCs/CogLordBody"), npc.Center - Main.screenPosition, null, Color.White, 0f, new Vector2(74, -18), 1f, SpriteEffects.None, 0f);
			spriteBatch.Draw(mod.GetTexture("Invasion/Hand_"), npc.Center - Main.screenPosition, null, Color.White, 0.0f, new Vector2(draw, -10), 1f, SpriteEffects.None, 1);
			spriteBatch.Draw(mod.GetTexture("Invasion/Hand"), npc.Center - Main.screenPosition, null, Color.White, 0.0f, new Vector2(draw_, -10), 1f, SpriteEffects.None, 1);
			//spriteBatch.Draw(mod.GetTexture("Invasion/Titan"), new Vector2(npc.Center.X, npc.Center.Y), null, Color.White, 0.0f, new Vector2(-10, -25), 1f, SpriteEffects.None, 1);				
		}

		int CurrentFrame = 0;
		int TimeToAnimation = 6;
		const int AnimationRate = 6;
		bool FirstState_ = true;
		void Animation()
		{
			if (--TimeToAnimation <= 0)
			{

				if (++CurrentFrame > 4)
					CurrentFrame = 1;
				TimeToAnimation = AnimationRate;
				npc.frame = GetFrame(CurrentFrame + ((FirstState_) ? 0 : 4));
			}
		}

		Rectangle GetFrame(int Number)
		{
			return new Rectangle(0, npc.frame.Height * (Number - 1), npc.frame.Width, npc.frame.Height);
		}

		private void SetupCrystals(int radius, bool clockwise)
		{
			if (Main.netMode == 1)
			{
				return;
			}
			Vector2 center = npc.Center;
			for (int k = 0; k < 15; k++)
			{
				float angle = 2f * (float)Math.PI / 10f * k;
				Vector2 pos = center + radius * new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
				int damage = 80;
				if (Main.expertMode)
				{
					damage = (int)(100 / Main.expertDamage);
				}
				int proj = Projectile.NewProjectile(pos.X, pos.Y, 0f, 0f, mod.ProjectileType("TitanCrystal_"), damage, 0f, Main.myPlayer, npc.whoAmI, angle);
				Main.projectile[proj].localAI[0] = radius;
				Main.projectile[proj].localAI[1] = clockwise ? 1 : -1;
				//NetMessage.SendData(27, -1, -1, "", proj);
			}
		}

		public override void AI()
		{
			Animation();
			Vector2 PTC = Main.player[npc.target].position + new Vector2(npc.width / 2, npc.height / 2);
			Vector2 NPos = npc.position + new Vector2(npc.width / 2, npc.height / 2);
			if (Main.rand.Next(150) == 0)
			{
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("TitanCrystal"));
			}

			if (Main.rand.Next(150) == 1)
			{
				Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
				float rotation = (float)Math.Atan2(vector8.Y - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), vector8.X - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
				npc.velocity.X = (float)(Math.Cos(rotation) * 14) * -1;
				npc.velocity.Y = (float)(Math.Sin(rotation) * 14) * -1;
				npc.netUpdate = true;
			}

			if (Main.rand.Next(250) == 1)
			{
				Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
				float rotation = (float)Math.Atan2(vector8.Y - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), vector8.X - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
				npc.velocity.X = (float)(Math.Cos(rotation) * 28) * -1;
				npc.velocity.Y = (float)(Math.Sin(rotation) * 28) * -1;
				npc.netUpdate = true;
			}

			if (Main.rand.Next(350) == 1) //6 комбо
			{
				Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
				float rotation = (float)Math.Atan2(vector8.Y - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), vector8.X - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
				npc.velocity.X = (float)(Math.Cos(rotation) * 46) * -1;
				npc.velocity.Y = (float)(Math.Sin(rotation) * 46) * -1;
				npc.netUpdate = true;
			}


			npc.netUpdate = false;
			npc.ai[0]++;
			npc.ai[1]++; //старт таймера
			if (npc.ai[1] >= 40) //ускорение рывков
			{
				npc.velocity.X *= 0.97f;
				npc.velocity.Y *= 0.97f;
			}

			if (npc.ai[1] >= 4500) //макс. таймера
			{
				npc.ai[0]++;
				npc.ai[1] = 0;
			}

			if ((npc.ai[1] >= 200 && npc.life > 90000 && npc.ai[1] < 3000) || (npc.ai[1] >= 120 && npc.life <= 90000 && npc.ai[1] < 3000) && Main.expertMode) //экспертные рывки
			{
				Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 8);
				for (int num36 = 0; num36 < 10; num36++)
				{
					Color color = new Color();
					int dust = Dust.NewDust(new Vector2((float)npc.position.X, (float)npc.position.Y), npc.width, npc.height, mod.DustType("CyberDust"), npc.velocity.X + Main.rand.Next(-10, 10), npc.velocity.Y + Main.rand.Next(-10, 10), 200, color, 1f);
					Main.dust[dust].noGravity = true;
				}
				npc.ai[3] = (float)(Main.rand.Next(360) * (Math.PI / 180));
				npc.ai[2] = 0;
				//npc.ai[1] = 0;

				if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
				{
					npc.TargetClosest(true);
				}
				if (!Main.player[npc.target].dead && Main.rand.Next(2) == 0)
				{
					npc.position.X = Main.player[npc.target].position.X + (float)((600 * Math.Cos(npc.ai[3])) * -1);
					npc.position.Y = Main.player[npc.target].position.Y + (float)((600 * Math.Sin(npc.ai[3])) * -1);
					Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
					float rotation = (float)Math.Atan2(vector8.Y - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), vector8.X - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
					npc.velocity.X = (float)(Math.Cos(rotation) * 14) * -1;
					npc.velocity.Y = (float)(Math.Sin(rotation) * 14) * -1;
				}
			}

			if ((npc.ai[1] >= 200 && npc.life > 45000 && npc.ai[1] < 500) || (npc.ai[1] >= 120 && npc.life <= 45000 && npc.ai[1] < 500) && !Main.expertMode) //рывки
			{
				Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 8);
				for (int num36 = 0; num36 < 10; num36++)
				{
					Color color = new Color();
					int dust = Dust.NewDust(new Vector2((float)npc.position.X, (float)npc.position.Y), npc.width, npc.height, mod.DustType("CyberDust"), npc.velocity.X + Main.rand.Next(-10, 10), npc.velocity.Y + Main.rand.Next(-10, 10), 200, color, 1f);
					Main.dust[dust].noGravity = true;
				}
				npc.ai[3] = (float)(Main.rand.Next(360) * (Math.PI / 180));
				npc.ai[2] = 0;
				//npc.ai[1] = 0;

				if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
				{
					npc.TargetClosest(true);
				}

				if (!Main.player[npc.target].dead && Main.rand.Next(2) == 1)
				{
					npc.position.X = Main.player[npc.target].position.X + (float)((600 * Math.Cos(npc.ai[3])) * -1);
					npc.position.Y = Main.player[npc.target].position.Y + (float)((600 * Math.Sin(npc.ai[3])) * -1);
					Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
					float rotation = (float)Math.Atan2(vector8.Y - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), vector8.X - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
					npc.velocity.X = (float)(Math.Cos(rotation) * 14) * -1;
					npc.velocity.Y = (float)(Math.Sin(rotation) * 14) * -1;
				}
			}

			if (npc.ai[1] >= 3000) //комбо 2
			{
				if (npc.ai[0] == 0)
				{
					npc.velocity.Y = Main.rand.Next(-10, -2);
					npc.velocity.X = Main.rand.Next(-10, 10) / 10;
					npc.ai[0] = 1;
				}
				npc.TargetClosest();
				if (Main.player[npc.target].position.X < npc.position.X)
				{
					if (npc.velocity.X > -6) { npc.velocity.X -= 0.3f; npc.netUpdate = true; }
				}
				if (Main.player[npc.target].position.X > npc.position.X)
				{
					if (npc.velocity.X < 6) { npc.velocity.X += 0.3f; npc.netUpdate = true; }
				}

				if (Main.player[npc.target].position.Y < npc.position.Y && npc.velocity.Y > -8)
				{
					if (npc.velocity.Y > 0f) npc.velocity.Y -= 0.3f;
					else npc.velocity.Y -= 0.015f;
				}
				if (Main.player[npc.target].position.Y > npc.position.Y && npc.velocity.Y < 8)
				{
					if (npc.velocity.Y < 0f) npc.velocity.Y += 0.3f;
					else npc.velocity.Y += 0.015f;
				}
			}

			if (npc.ai[1] >= 3200) //комбо 3
			{
				Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
				float rotation = (float)Math.Atan2(vector8.Y - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), vector8.X - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
				npc.velocity.X = (float)(Math.Cos(rotation) * 28) * -1;
				npc.velocity.Y = (float)(Math.Sin(rotation) * 28) * -1;
				npc.netUpdate = true;
				float Angle = (float)Math.Atan2(NPos.Y - PTC.Y, NPos.X - PTC.X);
				int SpitShot1 = Projectile.NewProjectile(NPos.X, NPos.Y, (float)((Math.Cos(Angle) * 22f) * -1), (float)((Math.Sin(Angle) * 22f) * -1), mod.ProjectileType("CyberLaserBat"), 30, 0f, 0);
				Main.projectile[SpitShot1].friendly = false;
				Main.projectile[SpitShot1].timeLeft = 500;
			}

			if (npc.ai[1] >= 3500) //комбо 4
			{
				npc.velocity.X *= 2.00f;
				npc.velocity.Y *= 2.00f;
				Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height * 0.5f));
				{
					float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
					npc.velocity.X = (float)(Math.Cos(rotation) * 28) * -1;
					npc.velocity.Y = (float)(Math.Sin(rotation) * 28) * -1;
					float Angle = (float)Math.Atan2(NPos.Y - PTC.Y, NPos.X - PTC.X);
					int SpitShot1 = Projectile.NewProjectile(NPos.X, NPos.Y, (float)((Math.Cos(Angle) * 22f) * -1), (float)((Math.Sin(Angle) * 22f) * -1), mod.ProjectileType("CyberLaserBat"), 50, 0f, 0);
					Main.projectile[SpitShot1].friendly = false;
					Main.projectile[SpitShot1].timeLeft = 500;
				}
				return;
			}

			if (npc.ai[1] >= 4000) //комбо 5-6
			{
				npc.velocity.X *= 5.00f;
				npc.velocity.Y *= 5.00f;
				Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height * 0.5f));
				{
					float Angle = (float)Math.Atan2(NPos.Y - PTC.Y, NPos.X - PTC.X);
					int SpitShot1 = Projectile.NewProjectile(NPos.X, NPos.Y, (float)((Math.Cos(Angle) * 22f) * -1), (float)((Math.Sin(Angle) * 22f) * -1), mod.ProjectileType("CyberLaserBat"), 90, 0f, 0);
					Main.projectile[SpitShot1].friendly = false;
					Main.projectile[SpitShot1].timeLeft = 500;
					float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), (vector8.X) - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
					npc.velocity.X = (float)(Math.Cos(rotation) * 28) * -1;
					npc.velocity.Y = (float)(Math.Sin(rotation) * 28) * -1;
				}
				return;
			}
		}

		public override void NPCLoot()
		{
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
				int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
				int halfLength = npc.width / 2 / 16 + 1;

				if (Main.expertMode)
				{
					npc.DropBossBags();
				}
				if (!Main.expertMode && Main.rand.Next(7) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ParadoxTitanMask"));
				}
				if (!Main.expertMode && Main.rand.Next(1) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TimeTissue"), Main.rand.Next(20, 32));
				}
				if (!Main.expertMode && Main.rand.Next(1) == 0)
				{
					Helper.DropItem(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), new Drop(mod.ItemType("RocketWand"), 1, 1), new Drop(mod.ItemType("TheEtherealm"), 1, 1), new Drop(mod.ItemType("SoulFlames"), 1, 1));
				}
				if (Main.rand.Next(10) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ParadoxTitanTrophy"));
				}
				if (Main.rand.Next(20) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("VioleumWings"));
				}
			}
		}
	}
}