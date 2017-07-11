using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	[AutoloadBossHead]
	public class StormJellyfish : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Storm Jellyfish");
			Main.npcFrameCount[npc.type] = 6;
		}

		const int ShootRate = 100; // Частота выстрела
		const int ShootDamage = 18; // Урон от лазера.
		const float ShootKN = 1.0f; // Отбрасывание
		const int ShootType = 435; // Тип проджектайла которым будет произведён выстрел.
		const float ShootSpeed = 8; // Это, я так понимаю, влияет на дальность выстрела
		const int ProjID = 437;
		const int UpSpeed = 6;

		const int ShootRate2 = 660; // Частота выстрела
		const int ShootDamage2 = 15; // Урон от лазера.
		const float ShootKN2 = 1.0f; // Отбрасывание
		const int ShootType2 = 465; // Тип проджектайла которым будет произведён выстрел.
		const float ShootSpeed2 = 5; // Это, я так понимаю, влияет на дальность выстрела
		const int ProjID2 = 437;
		const int UpSpeed2 = 6;

		int TimeToShoot = ShootRate; // Время до выстрела.

		int TimeToShoot2 = ShootRate2; // Время до выстрела.

		public override void SetDefaults()
		{
			npc.width = 140;
			npc.height = 140;
			npc.damage = 18;
			npc.defense = 16;
			npc.lifeMax = 2800;
			npc.HitSound = SoundID.NPCHit25;
			npc.DeathSound = SoundID.NPCDeath28;
			npc.boss = true;
			npc.knockBackResist = 0.1f;
			aiType = 472;
			npc.noGravity = true;
			npc.noGravity = true;
			music = 39;
			npc.aiStyle = 86;
			animationType = 472;
			bossBag = mod.ItemType("StormJellyfishBag");
		}

		public override void AI()
		{
			npc.position += npc.velocity * 0.5f;

			if (--TimeToShoot <= 0 && npc.target != -1) Shoot(); // В этой строке из переменной TimeToShot отнимается 1, и если TimeToShot < или = 0, то вызывается метод Shoot()
			if (--TimeToShoot2 <= 0 && npc.target != -1) Shoot2(); // В этой строке из переменной TimeToShot отнимается 1, и если TimeToShot < или = 0, то вызывается метод Shoot()

			if (Main.rand.Next(400) == 0)
			{
				NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("FlyingJelly"));
			}
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 60; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 226, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 226, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 226, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/StormGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/StormGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/StormGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/StormGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/StormGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/StormGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/StormGore4"), 1f);
			}
			else
			{

				for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 226, hitDirection, -2f, 0, default(Color), 0.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 27, hitDirection, -1f, 0, default(Color), 0.7f);
				}
			}
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = npc.lifeMax * 1;
			npc.damage = npc.damage * 1;
		}

		void Shoot()
		{
			TimeToShoot = ShootRate;
			Vector2 velocity = VelocityFPTP(npc.Center, Main.player[npc.target].Center, ShootSpeed);
			Projectile.NewProjectile(npc.Center.X, npc.Center.Y, velocity.X, velocity.Y, ShootType, ShootDamage, ShootKN);
		}

		void Shoot2()
		{
			TimeToShoot2 = ShootRate2;
			Vector2 velocity = VelocityFPTP(npc.Center, Main.player[npc.target].Center, ShootSpeed2);
			Projectile.NewProjectile(npc.Center.X, npc.Center.Y, velocity.X, velocity.Y, ShootType2, ShootDamage2, ShootKN2);
		}

		Vector2 VelocityFPTP(Vector2 pos1, Vector2 pos2, float speed)
		{
			Vector2 move = pos2 - pos1;
			return move * (speed / (float)Math.Sqrt(move.X * move.X + move.Y * move.Y));
		}


		public override void NPCLoot()
		{
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + npc.width / 2) / 16;
				int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
				int halfLength = npc.width / 2 / 16 + 1;

				if (Main.expertMode)
				{
					npc.DropBossBags();
				}

				if (!Main.expertMode && Main.rand.Next(7) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StormJellyfishMask"));
				}
				if (!Main.expertMode && Main.rand.Next(4) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StormBlade"));
				}
				if (!Main.expertMode && Main.rand.Next(3) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Poseidon"));
				}
				if (!Main.expertMode && Main.rand.Next(3) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("JellyfishStaff"));
				}
				if (!Main.expertMode && Main.rand.Next(3) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BoltTome"));
				}
				if (!Main.expertMode && Main.rand.Next(3) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StickyFlail"));
				}
				if (Main.rand.Next(10) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StormJellyfishTrophy"));
				}
				TremorWorld.downedStormJellyfish = true;
			}
		}

	}
}