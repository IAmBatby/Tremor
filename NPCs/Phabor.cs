using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class Phabor : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Phabor");
			Main.npcFrameCount[npc.type] = 4;
		}

		const int ShootRate = 500; // ������� ��������
		const int ShootDamage = 20; // ���� �� ������.
		const float ShootKN = 1.0f; // ������������
		const int ShootType = 468; // ��� ������������ ������� ����� ��������� �������.
		const float ShootSpeed = 4; // ���, � ��� �������, ������ �� ��������� ��������

		int TimeToShoot = ShootRate; // ����� �� ��������.

		public override void SetDefaults()
		{
			npc.lifeMax = 420;
			npc.damage = 30;
			npc.defense = 12;
			npc.knockBackResist = 0f;
			npc.width = 75;
			npc.height = 75;
			animationType = 82;
			npc.aiStyle = 22;
			npc.npcSlots = 0.5f;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit31;
			npc.noGravity = true;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = Item.buyPrice(0, 0, 55, 9);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("PhaborBanner");
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = npc.lifeMax * 1;
			npc.damage = npc.damage * 1;
		}

		public override void AI()
		{
			// ������ ����
			if (--TimeToShoot <= 0 && npc.target != -1) Shoot(); // � ���� ������ �� ���������� TimeToShot ���������� 1, � ���� TimeToShot < ��� = 0, �� ���������� ����� Shoot()
		}


		public override void NPCLoot()
		{
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + npc.width / 2) / 16;
				int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
				int halfLength = npc.width / 2 / 16 + 1;
				if (Main.rand.NextBool())
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Gloomstone"), Main.rand.Next(6, 15));
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = Main.tile[x, y].type;
			return (Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo)) && Main.hardMode && Main.bloodMoon && y < Main.worldSurface ? 0.06f : 0f;
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
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PhaborGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PhaborGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PhaborGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PhaborGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PhaborGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/PhaborGore3"), 1f);
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

		void Shoot()
		{
			TimeToShoot = ShootRate; // ������������� ������� ��������
			Vector2 velocity = VelocityFPTP(npc.Center, Main.player[npc.target].Center, ShootSpeed); // ��� �� ������� ������ velocity (��������� ���������� ����)
																									 // 1 �������� - ������� �� ������� ����� �������� �������
																									 // 2 �������� - ������� � ������� �� ������ �������� 
																									 // 3 �������� - �������� ��������
			Projectile.NewProjectile(npc.Center.X, npc.Center.Y, velocity.X, velocity.Y, ShootType, ShootDamage, ShootKN);
		}

		Vector2 VelocityFPTP(Vector2 pos1, Vector2 pos2, float speed)
		{
			Vector2 move = pos2 - pos1;
			return move * (speed / (float)Math.Sqrt(move.X * move.X + move.Y * move.Y));
		}
	}
}