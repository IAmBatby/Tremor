using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Invasion
{
	public class Violeum : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Violeum");
			Main.npcFrameCount[npc.type] = 4;
		}

		Vector2 Hands = new Vector2(-1, -1);
		public override void SetDefaults()
		{
			npc.lifeMax = 18000;
			npc.width = 78;
			npc.height = 88;
			animationType = 82;
			npc.damage = 250;
			npc.defense = 70;
			npc.knockBackResist = 0f;
			npc.width = 70;
			npc.height = 86;
			npc.aiStyle = 14;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit35;
			npc.noGravity = true;
			npc.DeathSound = SoundID.NPCDeath57;
			npc.color = Color.White;
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
				if (!Main.expertMode && Main.rand.NextBool(7))
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("VioleumMask"));
				}
				if (!Main.expertMode && Main.rand.NextBool(5))
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Crystyle"));
				}
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HealingPotion"), Main.rand.Next(7, 20));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TimeTissue"), Main.rand.Next(5, 15));
				Main.NewText("Violeum has been defeated!", 39, 86, 134);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			CyberWrathInvasion modPlayer = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>(mod);
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = Main.tile[x, y].type;
			return InvasionWorld.CyberWrath && y > Main.worldSurface ? 0.5f : 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 10; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType<CyberDust>(), 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}

				CyberWrathInvasion modPlayer = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>(mod);
				if (InvasionWorld.CyberWrath && InvasionWorld.CyberWrathPoints1 < 85)
				{
					InvasionWorld.CyberWrathPoints1 += 15;
					//Main.NewText(("Wave 1: Complete " + TremorWorld.CyberWrathPoints + "%"), 39, 86, 134);
				}
			}

			for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType<CyberDust>(), hitDirection, -1f, 0, default(Color), 0.7f);
			}
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = npc.lifeMax * 1;
			npc.damage = npc.damage * 1;
		}

		const string Boss_Left_Hand_Type = "Violeum_LeftArm";
		const string Boss_Right_Hand_Type = "Violeum_RightArm";
		const string Boss_Up_Hand_Type = "Violeum_LeftArm";
		const string Boss_Down_Hand_Type = "Violeum_RightArm";

		void MakeHands()
		{
			Hands.X = NPC.NewNPC((int)npc.Center.X - 50, (int)npc.Center.Y, mod.NPCType(Boss_Left_Hand_Type), 0, 1, npc.whoAmI);
			Hands.Y = NPC.NewNPC((int)npc.Center.X + 50, (int)npc.Center.Y, mod.NPCType(Boss_Right_Hand_Type), 0, -1, npc.whoAmI);
			Hands.Y = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y - 1000, mod.NPCType(Boss_Down_Hand_Type), 0, -1, npc.whoAmI);
			Hands.Y = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y + 1000, mod.NPCType(Boss_Up_Hand_Type), 0, -1, npc.whoAmI);
		}

		void CheckHands()
		{
			if (Hands.X != -1)
				if (!((Main.npc[(int)Hands.X].type == mod.NPCType(Boss_Left_Hand_Type) && Main.npc[(int)Hands.X].ai[1] == npc.whoAmI) && Main.npc[(int)Hands.X].active))
					Hands.X = -1;
			if (Hands.Y != -1)
				if (!((Main.npc[(int)Hands.Y].type == mod.NPCType(Boss_Right_Hand_Type) && Main.npc[(int)Hands.Y].ai[1] == npc.whoAmI) && Main.npc[(int)Hands.Y].active))
					Hands.Y = -1;
			if (Hands.X != -1)
				if (!((Main.npc[(int)Hands.X].type == mod.NPCType(Boss_Up_Hand_Type) && Main.npc[(int)Hands.X].ai[1] == npc.whoAmI) && Main.npc[(int)Hands.X].active))
					Hands.X = -1;
			if (Hands.Y != -1)
				if (!((Main.npc[(int)Hands.Y].type == mod.NPCType(Boss_Down_Hand_Type) && Main.npc[(int)Hands.Y].ai[1] == npc.whoAmI) && Main.npc[(int)Hands.Y].active))
					Hands.Y = -1;
		}

		public override void ModifyHitByProjectile(Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			CheckHands();
			if (Hands.Y != -1)
				damage /= 10;
		}

		public override void ModifyHitByItem(Player player, Item item, ref int damage, ref float knockback, ref bool crit)
		{
			CheckHands();
			if (Hands.Y != -1)
				damage /= 10;
		}

		public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
		{
			CheckHands();
			if (Hands.Y != -1)
				damage /= 10;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit)
		{
			CheckHands();
			if (Hands.Y != -1)
				damage /= 10;
		}

		float customAi1;
		bool FirstState;
		bool SecondState;
		public override void AI()
		{
			if (npc.life > npc.lifeMax / 2)
			{
				FirstState = true;
			}

			if (npc.life < npc.lifeMax / 2)
			{
				SecondState = true;
			}

			if (Main.rand.NextBool(2))
			{
				int num706 = Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType<CyberDust>(), 0f, 0f, 200, npc.color, 0.5f);
				Main.dust[num706].velocity *= 0.6f;
			}
			if (FirstState)
			{
				npc.TargetClosest();
				npc.netUpdate = false;
				npc.ai[1]++;

				npc.TargetClosest(true);
				Vector2 PTC = Main.player[npc.target].position + new Vector2(npc.width / 2, npc.height / 2);
				Vector2 NPos = npc.position + new Vector2(npc.width / 2, npc.height / 2);
				npc.netUpdate = true;

				customAi1 += (Main.rand.Next(2, 5) * 0.1f) * npc.scale;
				if (customAi1 >= 4f)
					if (Main.rand.Next(300) == 1)
					{
						Main.PlaySound(27, (int)npc.position.X, (int)npc.position.Y, 12);
						float Angle = (float)Math.Atan2(NPos.Y - PTC.Y, NPos.X - PTC.X);
						int SpitShot1 = Projectile.NewProjectile(NPos.X, NPos.Y, (float)((Math.Cos(Angle) * 22f) * -1), (float)((Math.Sin(Angle) * 22f) * -1), mod.ProjectileType("CyberLaserBat"), 70, 0f, 0);
						Main.projectile[SpitShot1].timeLeft = 120;
						customAi1 = 1f;
					}
				npc.netUpdate = true;

				npc.ai[1] += (Main.rand.Next(2, 5) * 0.1f) * npc.scale;
				if (npc.ai[1] >= 10f)
				{
					npc.TargetClosest(true);
					if (Main.rand.Next(60) == 0)
					{
						Vector2 vector8 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
						float rotation = (float)Math.Atan2(vector8.Y - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), vector8.X - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
						npc.velocity.X = (float)(Math.Cos(rotation) * 14) * -1;
						npc.velocity.Y = (float)(Math.Sin(rotation) * 14) * -1;
						npc.ai[1] = 1f;
						npc.netUpdate = true;
					}
				}

				int num60;
				npc.TargetClosest(true);

				if (Main.player[npc.target].position.Y - 150 > npc.position.Y)
				{
					npc.directionY = 1;
				}
				else
				{
					npc.directionY = -1;
				}

				if (npc.direction == -1 && npc.velocity.X > -2f)
				{
					npc.velocity.X = npc.velocity.X - 0.4f;
					if (npc.velocity.X > 2f)
					{
						npc.velocity.X = npc.velocity.X - 0.4f;
					}
					else
					{
						if (npc.velocity.X > 0f)
						{
							npc.velocity.X = npc.velocity.X + 0.08f;
						}
					}
					if (npc.velocity.X < -2f)
					{
						npc.velocity.X = -2f;
					}
				}
				else
				{
					if (npc.direction == 1 && npc.velocity.X < 4f)
					{
						npc.velocity.X = npc.velocity.X + 0.1f;
						if (npc.velocity.X < -2f)
						{
							npc.velocity.X = npc.velocity.X + 0.1f;
						}
						else
						{
							if (npc.velocity.X < 0f)
							{
								npc.velocity.X = npc.velocity.X - 0.08f;
							}
						}
						if (npc.velocity.X > 2f)
						{
							npc.velocity.X = 2f;
						}
					}
				}
				if (npc.directionY == -1 && npc.velocity.Y > -1.5)
				{
					npc.velocity.Y = npc.velocity.Y - 0.08f;

					if (npc.velocity.Y < -1.5)
					{
						npc.velocity.Y = -1.5f;
					}
				}
				else
				{
					if (npc.directionY == 1 && npc.velocity.Y < 1.5)
					{
						npc.velocity.Y = npc.velocity.Y + 0.08f;
						if (npc.velocity.Y > 1.5)
						{
							npc.velocity.Y = 1.5f;
						}
					}
				}

				if (Main.rand.NextBool(2))
				{

					float j = 0;
					float m = 0;
					float n = 0;
					FirstState = true;
					if ((int)Main.time % 140 > 50)
					{
						if ((int)Main.time % 40 < 1)
							for (int i = 0; i < 3; i++)
							{
								j += 2;
								m = (float)Math.Sin(j) * 25f;
								n = (float)Math.Cos(j) * 25f;
								Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 8);
								int damage = 70,
								type = mod.ProjectileType("CyberLaserBat");
								int num56 = Projectile.NewProjectile(npc.position.X + 20, npc.position.Y + 50, m, n, type, damage, 0f, Main.myPlayer);
								Main.projectile[num56].timeLeft = 600;
							}
					}
				}
			}
		}
	}
}