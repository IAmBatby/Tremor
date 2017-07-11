using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	public class HeaterOfWorldsBody : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heater of Worlds");
		}


		const int ShootRate = 160; // Частота выстрела
		const int ShootDamage = 10; // Урон от лазера.
		const float ShootKN = 1.0f; // Отбрасывание
		const int ShootType = 326; // Тип проджектайла которым будет произведён выстрел.
		const float ShootSpeed = 4; // Это, я так понимаю, влияет на дальность выстрела

		int TimeToShoot = ShootRate; // Время до выстрела.

		public override void SetDefaults()
		{
			npc.lifeMax = 6500;
			npc.damage = 39;
			npc.defense = 40;
			npc.width = 26;
			npc.height = 48;
			npc.noTileCollide = true;
			npc.behindTiles = true;
			npc.friendly = false;
			npc.noGravity = true;
			npc.aiStyle = 6;
			npc.dontTakeDamage = true;
			npc.dontCountMe = true;
			npc.lavaImmune = true;
			npc.buffImmune[24] = true;
			npc.buffImmune[67] = true;
			npc.npcSlots = 5f;
			music = 17;
			npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath10;
		}

		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (Main.expertMode || Main.rand.Next(1) == 0)
			{
				player.AddBuff(24, 180, true);
			}
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}

		void Shoot()
		{
			TimeToShoot = ShootRate; // Устанавливаем кулдаун выстрелу
			Vector2 velocity = VelocityFPTP(npc.Center, Main.player[npc.target].Center, ShootSpeed); // Тут мы получим нужную velocity (пояснение аргументов ниже)
																									 // 1 аргумент - позиция из которой будет вылетать выстрел
																									 // 2 аргумент - позиция в которую он должен полететь 
																									 // 3 аргумент - скорость выстрела
			Projectile.NewProjectile(npc.Center.X, npc.Center.Y, velocity.X, velocity.Y, ShootType, ShootDamage, ShootKN);
		}

		Vector2 VelocityFPTP(Vector2 pos1, Vector2 pos2, float speed)
		{
			Vector2 move = pos2 - pos1;
			return move * (speed / (float)System.Math.Sqrt(move.X * move.X + move.Y * move.Y));
		}

		public override void AI()
		{

			if (--TimeToShoot <= 0 && npc.target != -1) Shoot(); // В этой строке из переменной TimeToShot отнимается 1, и если TimeToShot < или = 0, то вызывается метод Shoot()
			if (Main.rand.Next(3) == 0)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, 6, 0f, 0f, 200, npc.color, 1f);
				Dust.NewDust(npc.position, npc.width, npc.height, 6, 0f, 0f, 200, npc.color, 1f);
			}

			if (!Main.npc[(int)npc.ai[1]].active)
			{
				npc.life = 0;
				npc.HitEffect(0, 10.0);
				NPCLoot();
				npc.active = false;
			}
		}
		public override bool CheckActive()
		{
			return false;
		}
		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
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