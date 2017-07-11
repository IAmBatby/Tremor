using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	[AutoloadBossHead]
	public class Mothership : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mothership");
			Main.npcFrameCount[npc.type] = 8;
		}


		private float timeToNextFrame;
		public int frame;

		public override void SetDefaults()
		{
			npc.aiStyle = -1;
			npc.lifeMax = 45000;
			npc.damage = 125;
			npc.defense = 55 * 0;
			npc.knockBackResist = 0f;
			npc.width = 162;
			npc.height = 122;
			npc.value = Item.buyPrice(0, 0, 0, 0);
			npc.npcSlots = 1;
			npc.boss = true;
			npc.lavaImmune = true;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath6;
			music = MusicID.Boss2;
		}

		public float timeToShoot = 2;
		private float vel = 2.5f;
		private float lifeTime;
		private bool Rage;



		public Vector2 bossCenter
		{
			get { return npc.Center; }
			set { npc.position = value - new Vector2(npc.width / 2, npc.height / 2); }
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CKMotherGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CKMotherGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CKMotherGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CKMotherGore3"), 1f);
			}
		}


		public override void AI()
		{
			bool allDead = false;
			for (int i = 0; i < Main.player.Length; i++)
			{
				if (Main.player[i].dead) allDead = true;
			}

			if (Main.dayTime || allDead)
			{
				if (npc.velocity.X > 0f)
				{
					npc.velocity.X = npc.velocity.X + 0.75f;
				}
				else
				{
					npc.velocity.X = npc.velocity.X - 0.75f;
				}
				npc.velocity.Y = npc.velocity.Y - 0.1f;
				npc.rotation = npc.velocity.X * 0.05f;
			}

			lifeTime += 0.016f;
			Player player = Main.player[npc.target];
			Vector2 targetPos = player.Center - new Vector2(0, 250) + new Vector2((float)Math.Sin(lifeTime) * 200, (float)Math.Cos(lifeTime) * 50);
			bossCenter = Vector2.Lerp(bossCenter, targetPos, 0.01f);
			Lighting.AddLight(bossCenter, 0.3f, 0.3f, 1f);
			if (npc.life < npc.lifeMax / 2)
			{
				Rage = true;
			}
			if (timeToNextFrame > 0)
			{
				timeToNextFrame -= 0.016f;
			}
			else
			{
				timeToNextFrame = 0.1f;
				if (frame < 3)
				{
					frame++;
				}
				else
				{
					frame = 0;
				}
				if (Rage)
				{
					frame += 4;
				}
			}
			if (timeToShoot > 0)
			{
				timeToShoot -= 0.016f;
			}
			else
			{
				Shoot(player);
			}
		}

		private void Shoot(Player player)
		{
			if (!Rage)
			{
				float angle = Main.rand.Next(0, (int)Math.PI * 200) / 100f;
				Vector2 vel = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * 3 * Main.rand.Next(5);
				Projectile.NewProjectile(bossCenter.X, bossCenter.Y + 15, vel.X + 15, vel.Y, mod.ProjectileType("PurplePulsePro"), 30, 5f);
				Projectile.NewProjectile(bossCenter.X, bossCenter.Y, vel.X, vel.Y, mod.ProjectileType("PurplePulsePro"), 30, 5f);
				Projectile.NewProjectile(bossCenter.X, bossCenter.Y - 15, vel.X - 15, vel.Y, mod.ProjectileType("PurplePulsePro"), 30, 5f);
				Projectile.NewProjectile(bossCenter.X, bossCenter.Y + 30, vel.X + 30, vel.Y, mod.ProjectileType("PurplePulsePro"), 30, 5f);
				Projectile.NewProjectile(bossCenter.X, bossCenter.Y - 30, vel.X - 30, vel.Y, mod.ProjectileType("PurplePulsePro"), 30, 5f);
				timeToShoot = 1;
			}
			else
			{
				float angle = (float)Math.Atan2(player.Center.Y - bossCenter.Y, player.Center.X - bossCenter.X);
				Vector2 vel = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * 5;
				Projectile.NewProjectile(bossCenter.X, bossCenter.Y, vel.X, vel.Y, 465, 25, 5f);
				timeToShoot = 8;
			}
		}

		public override bool PreNPCLoot()
		{
			Player player = Main.player[npc.target];
			NPC.NewNPC((int)bossCenter.X, (int)bossCenter.Y, mod.NPCType("CyberKing"), 0, 0, 0, 0, 0, npc.target);
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return false;
		}

		private float clamp(float value, float min, float max)
		{
			if (value < min)
			{
				return min;
			}
			if (value > max)
			{
				return max;
			}
			return value;
		}

		public override void FindFrame(int frameHeight)
		{
			npc.frame.Y = frameHeight * frame + 2;
		}
	}
}