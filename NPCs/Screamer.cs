using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	public class Screamer : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Screamer");
			Main.npcFrameCount[npc.type] = 4;
		}


		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ScreamerGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ScreamerGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ScreamerGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ScreamerGore3"), 1f);
			}
		}

		public override void SetDefaults()
		{
			npc.aiStyle = -1;
			npc.lifeMax = 12000;
			npc.damage = 160;
			npc.defense = 135;
			animationType = 82;
			npc.knockBackResist = 0f;
			npc.width = 130;
			npc.height = 140;
			npc.value = Item.buyPrice(0, 20, 0, 0);
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath10;
			npc.buffImmune[20] = true;
			npc.buffImmune[24] = true;
			npc.buffImmune[39] = true;
			npc.npcSlots = 10f;
		}


		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}

		public override void AI()
		{
			float num1971 = 5f;
			float moveSpeed = 0.15f;
			npc.TargetClosest(true);
			Vector2 desiredVelocity4 = Main.player[npc.target].Center - npc.Center + new Vector2(0f, -250f);
			float num1972 = desiredVelocity4.Length();
			if (num1972 < 20f)
			{
				desiredVelocity4 = npc.velocity;
			}
			else if (num1972 < 40f)
			{
				desiredVelocity4.Normalize();
				desiredVelocity4 *= num1971 * 0.35f;
			}
			else if (num1972 < 80f)
			{
				desiredVelocity4.Normalize();
				desiredVelocity4 *= num1971 * 0.65f;
			}
			else
			{
				desiredVelocity4.Normalize();
				desiredVelocity4 *= num1971;
			}
			npc.SimpleFlyMovement(desiredVelocity4, moveSpeed);
			npc.rotation = npc.velocity.X * 0.1f;
			if ((npc.ai[0] += 1f) >= 70f)
			{
				npc.ai[0] = 0f;
				if (Main.netMode != 1)
				{
					Vector2 vector283 = Vector2.Zero;
					while (Math.Abs(vector283.X) < 1.5f)
					{
						vector283 = Vector2.UnitY.RotatedByRandom(1.5707963705062866) * new Vector2(5f, 3f);
					}
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vector283.X, vector283.Y, 593, 60, 0f, Main.myPlayer, 0f, (float)npc.whoAmI);
					return;
				}
			}
		}


		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
			return spawnInfo.spawnTileY < Main.rockLayer && NPC.downedMoonlord && Main.eclipse ? 0.001f : 0f;
		}

		public override void NPCLoot()
		{
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
				int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
				int halfLength = npc.width / 2 / 16 + 1;
				if (Main.rand.Next(1) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Catalyst"), Main.rand.Next(5, 12));
				}
			}
		}
	}
}