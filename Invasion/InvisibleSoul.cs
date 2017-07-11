using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Invasion
{
	public class InvisibleSoul : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paradox Soul Warrior");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 12250;
			npc.damage = 100;
			npc.defense = 65;
			npc.knockBackResist = 0f;
			npc.width = 34;
			npc.height = 40;
			animationType = 3;
			npc.aiStyle = 3;
			aiType = 77;
			npc.npcSlots = 0.5f;
			npc.HitSound = SoundID.NPCHit55;
			npc.DeathSound = SoundID.NPCDeath51;
			npc.color = Color.White;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			Mod mod = ModLoader.GetMod("Tremor");
			CyberWrathInvasion modPlayer = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>(mod);
			float spawn = 20f;
			if (InvasionWorld.CyberWrath)
				return 1000f;
			return 0f;

			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = Main.tile[x, y].type;
			return InvasionWorld.CyberWrath && y > Main.worldSurface ? 1f : 0f;
		}

		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (Main.rand.Next(3) == 0)
			{
				player.AddBuff(164, 1000, true);
			}
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 10; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("CyberDust"), 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}

				CyberWrathInvasion modPlayer = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>(mod);
				if (InvasionWorld.CyberWrath && Main.rand.Next(3) == 1)
				{
					InvasionWorld.CyberWrathPoints1 += 3;
					//Main.NewText(("Wave 1: Complete " + TremorWorld.CyberWrathPoints + "%"), 39, 86, 134);
				}
			}

			for (int k = 0; k < damage / npc.lifeMax * 50.0; k++)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("CyberDust"), hitDirection, -1f, 0, default(Color), 0.7f);
			}
		}

		public override void NPCLoot()
		{
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + npc.width / 2) / 16;
				int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
				int halfLength = npc.width / 2 / 16 + 1;
				if (Main.rand.Next(3) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ParadoxElement"), Main.rand.Next(5, 7));
				}
			}
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = npc.lifeMax * 1;
			npc.damage = npc.damage * 1;
		}

		float customAi1;
		bool FirstState;
		bool SecondState;
		public Vector2 tilePos = default(Vector2);
		public override void AI()
		{
			//PlayAnimation();
			if (npc.life > npc.lifeMax / 2)
			{
				FirstState = true;
			}

			if (npc.life < npc.lifeMax / 2)
			{
				FirstState = false;
				SecondState = true;
			}

			if (Main.rand.Next(2) == 0)
			{
				int num706 = Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("CyberDust"), 0f, 0f, 200, npc.color, 0.5f);
				Main.dust[num706].velocity *= 0.6f;
			}
			if (FirstState)
			{
				if (Main.player[npc.target].position.X > npc.position.X)
					npc.spriteDirection = 1;
				else
					npc.spriteDirection = -1;

				if (npc.direction == -1 && npc.velocity.X > -2f)
				{
					npc.velocity.X = npc.velocity.X - 0.1f;
					if (npc.velocity.X > 2f)
					{
						npc.velocity.X = npc.velocity.X - 0.1f;
					}
					else
					{
						if (npc.velocity.X > 0f)
						{
							npc.velocity.X = npc.velocity.X + 0.05f;
						}
					}
					if (npc.velocity.X < -2f)
					{
						npc.velocity.X = -2f;
					}
				}
				else
				{
					if (npc.direction == 1 && npc.velocity.X < 2f)
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
								npc.velocity.X = npc.velocity.X - 0.05f;
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
					npc.velocity.Y = npc.velocity.Y - 0.05f;

					if (npc.velocity.Y < -1.5)
					{
						npc.velocity.Y = -1.5f;
					}
				}
				else
				{
					if (npc.directionY == 1 && npc.velocity.Y < 1.5)
					{
						npc.velocity.Y = npc.velocity.Y + 0.05f;
						if (npc.velocity.Y > 1.5)
						{
							npc.velocity.Y = 1.5f;
						}
					}
				}

				if (Main.rand.Next(160) == 0)
				{
					NPC.NewNPC((int)npc.position.X - 50, (int)npc.position.Y, mod.NPCType("MiniSoul"));
				}
			}

			if (SecondState && !FirstState)
			{
				if (Main.player[npc.target].position.X > npc.position.X)
					npc.spriteDirection = 1;
				else
					npc.spriteDirection = -1;

				if (npc.direction == -1 && npc.velocity.X > -2f)
				{
					npc.velocity.X = npc.velocity.X - 0.1f;
					if (npc.velocity.X > 2f)
					{
						npc.velocity.X = npc.velocity.X - 0.1f;
					}
					else
					{
						if (npc.velocity.X > 0f)
						{
							npc.velocity.X = npc.velocity.X + 0.05f;
						}
					}
					if (npc.velocity.X < -2f)
					{
						npc.velocity.X = -2f;
					}
				}
				else
				{
					if (npc.direction == 1 && npc.velocity.X < 2f)
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
								npc.velocity.X = npc.velocity.X - 0.05f;
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
					npc.velocity.Y = npc.velocity.Y - 0.05f;

					if (npc.velocity.Y < -1.5)
					{
						npc.velocity.Y = -1.5f;
					}
				}
				else
				{
					if (npc.directionY == 1 && npc.velocity.Y < 1.5)
					{
						npc.velocity.Y = npc.velocity.Y + 0.05f;
						if (npc.velocity.Y > 1.5)
						{
							npc.velocity.Y = 1.5f;
						}
					}
				}

				if (Main.rand.Next(120) == 0)
				{
					NPC.NewNPC((int)npc.position.X - 50, (int)npc.position.Y, mod.NPCType("MiniSoul"));
				}

				if (Main.rand.Next(200) == 0)
				{
					NPC.NewNPC((int)npc.position.X - 50, (int)npc.position.Y, mod.NPCType("CyberSoul"));
				}
			}
		}
	}
}