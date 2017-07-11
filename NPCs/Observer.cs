using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class Observer : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Observer");
			Main.npcFrameCount[npc.type] = 4;
		}

		const int ShootRate = 250; // Частота выстрела
		const int ShootDamage = 20; // Урон от лазера.
		const float ShootKN = 1.0f; // Отбрасывание
		const int ShootType = 100; // Тип проджектайла которым будет произведён выстрел.
		const float ShootSpeed = 4; // Это, я так понимаю, влияет на дальность выстрела

		int TimeToShoot = ShootRate; // Время до выстрела.

		public override void SetDefaults()
		{
			npc.lifeMax = 2500;
			npc.damage = 80;
			npc.defense = 32;
			npc.knockBackResist = 0f;
			npc.width = 130;
			npc.height = 130;
			animationType = 82;
			npc.aiStyle = 22;
			npc.npcSlots = 0.5f;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit31;
			npc.noGravity = true;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = Item.buyPrice(0, 0, 55, 9);
			banner = npc.type;
			bannerItem = mod.ItemType("ObserverBanner");
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = npc.lifeMax * 1;
			npc.damage = npc.damage * 1;
		}

		public override void AI()
		{
			// Всякая дичь
			if (--TimeToShoot <= 0 && npc.target != -1) Shoot(); // В этой строке из переменной TimeToShot отнимается 1, и если TimeToShot < или = 0, то вызывается метод Shoot()
		}


		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = Main.tile[x, y].type;
			return (Tremor.NormalSpawn(spawnInfo) && Tremor.NoZoneAllowWater(spawnInfo)) && Main.hardMode && Main.bloodMoon && y < Main.worldSurface ? 0.006f : 0f;
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ObserverGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ObserverGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ObserverGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ObserverGore4"), 1f);
			}
			else
			{
				for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 5, hitDirection, -1f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 5, hitDirection, -1f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 5, hitDirection, -1f, 0, default(Color), 0.7f);
				}
			}
		}

		public override void NPCLoot()
		{
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + npc.width / 2) / 16;
				int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
				int halfLength = npc.width / 2 / 16 + 1;
				if (Main.rand.Next(15) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Spearaxe"));
				}
				if (Main.rand.Next(15) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ScarredReaper"));
				};
			}
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
			return move * (speed / (float)Math.Sqrt(move.X * move.X + move.Y * move.Y));
		}
	}
}