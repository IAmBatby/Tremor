using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	[AutoloadBossHead]
	public class FrostKing : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frost King");
			Main.npcFrameCount[npc.type] = 8;
		}


		private float timeToNextFrame;
		private int frame;

		public override void SetDefaults()
		{
			npc.aiStyle = -1;
			npc.lifeMax = 60000;
			npc.damage = 78;
			npc.defense = 65;
			npc.knockBackResist = 0f;
			npc.width = 252;
			npc.height = 254;
			npc.value = Item.buyPrice(0, 0, 15, 0);
			npc.npcSlots = 1;
			npc.boss = true;
			npc.lavaImmune = true;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit41;
			bossBag = mod.ItemType("FrostKingBag");
			npc.DeathSound = SoundID.NPCDeath44;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FrostKingGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FrostKingGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FrostKingGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FrostKingGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FrostKingGore4"), 1f);
			}
		}

		private float timeToAtack = 2;
		private float vel = 2.5f;
		private float lifeTime;
		private int minTimeToAtack = 3;
		private int maxTimeToAtack = 5;
		private Vector2 localTargPos = new Vector2(666, 666);
		private int mode;
		private float atackTimer;
		private float atackLenghtTimer;
		private float preAtack;

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

		private void findNewLocalTargetPos()
		{
			float a = Main.rand.Next(0, (int)(Math.PI) * 200) / 100f;
			float r = Main.rand.Next(0, 5000) / 100f;
			localTargPos = new Vector2((float)Math.Cos(a) * r, (float)Math.Sin(a) * r);
		}

		public override void AI()
		{
			bool allDead = false;
			for (int i = 0; i < Main.player.Length; i++)
			{
				if (Main.player[i].dead) allDead = true;
			}

			if (allDead)
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
			Vector2 targetPos = player.Center + localTargPos;
			if (localTargPos == new Vector2(666, 666) || Vector2.Distance(bossCenter, targetPos) < 5)
			{
				findNewLocalTargetPos();
			}
			Lighting.AddLight(bossCenter, 0.8f, 0.8f, 1f);
			if (mode == 0)
			{
				bossCenter = Vector2.Lerp(bossCenter, targetPos, 0.01f);
			}
			else if (mode == 1)
			{
				bossCenter = Vector2.Lerp(bossCenter, targetPos, 0.005f);
				if (preAtack > 0)
				{
					preAtack -= 0.016f;
				}
				else
				{
					if (atackLenghtTimer > 0)
					{
						atackLenghtTimer -= 0.016f;
						if (atackTimer > 0)
						{
							atackTimer -= 0.016f;
						}
						else
						{
							for (int i = 0; i < 30; i++)
							{
								float angle = Main.rand.Next(0, (int)(Math.PI) * 200) / 100f;
								Vector2 velocity = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * 25;
								Projectile.NewProjectile(bossCenter.X - 90, bossCenter.Y + 7, velocity.X, velocity.Y, 349, 20, 5);
							}
							atackTimer = 0.3f;
						}
					}
					else
					{
						mode = 0;
					}
				}
			}
			else if (mode == 2)
			{
				bossCenter = Vector2.Lerp(bossCenter, targetPos, 0.005f);
				if (preAtack > 0)
				{
					preAtack -= 0.016f;
				}
				else
				{
					if (atackLenghtTimer > 0)
					{
						atackLenghtTimer -= 0.016f;
						if (atackTimer > 0)
						{
							atackTimer -= 0.016f;
						}
						else
						{
							Vector2 shootPos = bossCenter + new Vector2(88, 32);
							float angle = (float)Math.Atan2(targetPos.Y - shootPos.Y, targetPos.X - shootPos.X) + Main.rand.Next((int)(Math.PI * -100f), (int)(Math.PI * 100f)) / 3600f;
							Vector2 velocity = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * 20;
							Projectile.NewProjectile(shootPos.X, shootPos.Y, velocity.X, velocity.Y, 348, 40, 5);
							atackTimer = 1;
						}
					}
					else
					{
						mode = 0;
					}
				}
			}
			else
			{
				bossCenter = Vector2.Lerp(bossCenter, targetPos, 0.005f);
				if (preAtack > 0)
				{
					preAtack -= 0.016f;
				}
				else
				{
					if (atackLenghtTimer > 0)
					{
						atackLenghtTimer -= 0.016f;
						if (atackTimer > 0)
						{
							atackTimer -= 0.016f;
						}
						else
						{
							Vector2 shootPos = bossCenter + new Vector2(-90, 25);
							Projectile.NewProjectile(shootPos.X, shootPos.Y, -20, 0, 464, 40, 5);
							shootPos = bossCenter + new Vector2(90, 25);
							Projectile.NewProjectile(shootPos.X, shootPos.Y, 20, 0, 464, 40, 5);
							atackTimer = 3;
						}
					}
					else
					{
						mode = 0;
					}
				}
			}
			if (timeToNextFrame > 0)
			{
				timeToNextFrame -= 0.016f;
			}
			else
			{
				if (mode == 0)
				{
					timeToNextFrame = 0.1f;
					if (frame < 4)
					{
						frame++;
					}
					else
					{
						frame = 0;
					}
				}
				else
				{
					frame = 4 + mode;
				}
			}
			if (timeToAtack > 0)
			{
				timeToAtack -= 0.016f;
			}
			else
			{
				Shoot(player, Main.rand.Next(0, 3));
			}
			if (Vector2.Distance(targetPos, bossCenter) > 10000 && Main.dayTime)
			{
				npc.active = false;
			}
		}

		private void Shoot(Player player, int type)
		{
			mode = type + 1;
			if (type == 0)
			{
				timeToAtack = Main.rand.Next(5 + minTimeToAtack, 5 + maxTimeToAtack + 1);
				atackLenghtTimer = 5;
			}
			else if (type == 1)
			{
				timeToAtack = Main.rand.Next(5 + minTimeToAtack, 5 + maxTimeToAtack + 1);
				atackLenghtTimer = 5;
			}
			else
			{
				timeToAtack = Main.rand.Next(7 + minTimeToAtack, 9 + maxTimeToAtack + 1);
				atackLenghtTimer = 7;
			}
			preAtack = 0.5f;
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

		public override void NPCLoot()
		{
			if (Main.expertMode)
			{
				npc.DropBossBags();
			}
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + npc.width / 2) / 16;
				int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
				int halfLength = npc.width / 2 / 16 + 1;

				if (!Main.expertMode && Main.rand.Next(7) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FrostKingMask"));
				}
				if (Main.rand.Next(10) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FrostKingTrophy"));
				}
				if (!Main.expertMode && Main.rand.NextBool())
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FrostoneOre"), Main.rand.Next(24, 42));
				}
				TremorWorld.Boss.FrostKing.Downed(true);
			}
		}
	}
}
