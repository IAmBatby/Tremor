using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{

	public class SnowEater : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Snow Eater");
			Main.npcFrameCount[npc.type] = 5;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 70;
			npc.damage = 13;
			npc.defense = 7;
			npc.knockBackResist = 0.0f;
			npc.width = 24;
			npc.height = 24;
			animationType = 69;
			npc.aiStyle = -1;
			npc.behindTiles = true;
			npc.npcSlots = 0.1f;
			npc.HitSound = SoundID.NPCHit31;
			npc.DeathSound = SoundID.NPCDeath34;
			npc.value = Item.buyPrice(0, 0, 12, 0);
			banner = npc.type;
			bannerItem = mod.ItemType("SnowEaterBanner");
		}

		public override void NPCLoot()
		{
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
				int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
				int halfLength = npc.width / 2 / 16 + 1;
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FrostCore"));
				};
				if (NPC.downedMoonlord && Main.rand.Next(5) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IceSoul"));
				}
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return spawnInfo.player.ZoneSnow && y > Main.rockLayer ? 0.01f : 0f;
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 1);
			npc.damage = (int)(npc.damage * 1);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SEGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SEGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SEGore2"), 1f);
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 1.7f);
					Dust.NewDust(npc.position, npc.width, npc.height, 80, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.6f);
				}
			}
		}

		public override void AI()
		{
			npc.TargetClosest(true);
			float num679 = 12f;
			Vector2 vector67 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
			float num680 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector67.X;
			float num681 = Main.player[npc.target].position.Y - vector67.Y;
			float num682 = (float)Math.Sqrt((double)(num680 * num680 + num681 * num681));
			num682 = num679 / num682;
			num680 *= num682;
			num681 *= num682;
			bool flag74 = false;
			if (npc.directionY < 0)
			{
				npc.rotation = (float)(Math.Atan2((double)num681, (double)num680) + 1.57);
				flag74 = ((double)npc.rotation >= -1.2 && (double)npc.rotation <= 1.2);
				if ((double)npc.rotation < -0.8)
				{
					npc.rotation = -0.8f;
				}
				else if ((double)npc.rotation > 0.8)
				{
					npc.rotation = 0.8f;
				}
				if (npc.velocity.X != 0f)
				{
					npc.velocity.X = npc.velocity.X * 0.9f;
					if ((double)npc.velocity.X > -0.1 || (double)npc.velocity.X < 0.1)
					{
						npc.netUpdate = true;
						npc.velocity.X = 0f;
					}
				}
			}
			if (npc.ai[0] > 0f)
			{
				if (npc.ai[0] == 200f)
				{
					Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 5);
				}
				npc.ai[0] -= 1f;
			}
			if (Main.netMode != 1 && flag74 && npc.ai[0] == 0f && Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
			{
				npc.ai[0] = 200f;
				int num683 = 10;
				int num684 = 109;
				int num685 = Projectile.NewProjectile(vector67.X, vector67.Y, num680, num681, num684, num683, 0f, Main.myPlayer, 0f, 0f);
				Main.projectile[num685].ai[0] = 2f;
				Main.projectile[num685].timeLeft = 300;
				Main.projectile[num685].friendly = false;
				//NetMessage.SendData(27, -1, -1, "", num685, 0f, 0f, 0f, 0, 0, 0);
				npc.netUpdate = true;
			}
			try
			{
				int num686 = (int)npc.position.X / 16;
				int num687 = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
				int num688 = (int)(npc.position.X + (float)npc.width) / 16;
				int num689 = (int)(npc.position.Y + (float)npc.height) / 16;
				bool flag75 = false;
				if (Main.tile[num686, num689] == null)
				{
					Main.tile[num686, num689] = new Tile();
				}
				if (Main.tile[num687, num689] == null)
				{
					Main.tile[num686, num689] = new Tile();
				}
				if (Main.tile[num688, num689] == null)
				{
					Main.tile[num686, num689] = new Tile();
				}
				if ((Main.tile[num686, num689].nactive() && Main.tileSolid[(int)Main.tile[num686, num689].type]) || (Main.tile[num687, num689].nactive() && Main.tileSolid[(int)Main.tile[num687, num689].type]) || (Main.tile[num688, num689].nactive() && Main.tileSolid[(int)Main.tile[num688, num689].type]))
				{
					flag75 = true;
				}
				if (flag75)
				{
					npc.noGravity = true;
					npc.noTileCollide = true;
					npc.velocity.Y = -0.2f;
				}
				else
				{
					npc.noGravity = false;
					npc.noTileCollide = false;
					if (Main.rand.Next(2) == 0)
					{
						int num690 = Dust.NewDust(new Vector2(npc.position.X - 4f, npc.position.Y + (float)npc.height - 8f), npc.width + 8, 24, 80, 0f, npc.velocity.Y / 2f, 0, default(Color), 1f);
						Dust expr_28A1C_cp_0 = Main.dust[num690];
						expr_28A1C_cp_0.velocity.X = expr_28A1C_cp_0.velocity.X * 0.4f;
						Dust expr_28A3C_cp_0 = Main.dust[num690];
						expr_28A3C_cp_0.velocity.Y = expr_28A3C_cp_0.velocity.Y * -1f;
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num690].noGravity = true;
							Main.dust[num690].scale += 0.2f;
						}
					}
				}
				return;
			}
			catch
			{
				return;
			}
		}

	}
}