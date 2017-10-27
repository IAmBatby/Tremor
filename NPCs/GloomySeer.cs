using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace Tremor.NPCs
{
	public class GloomySeer : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gloomy Seer");
			Main.npcFrameCount[npc.type] = 5;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 250;
			npc.damage = 22;
			npc.defense = 10;
			npc.knockBackResist = 0.3f;
			npc.width = 40;
			npc.height = 40;
			animationType = 156;
			npc.aiStyle = 22;
			npc.npcSlots = 15f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.noGravity = true;
			npc.value = Item.buyPrice(0, 0, 2, 50);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("GloomySeerBanner");
		}

		public override void AI()
		{
			npc.ai[0]++;

			if (Main.netMode != 1 && (npc.ai[0] == 20f || npc.ai[0] == 40f || npc.ai[0] == 60f || npc.ai[0] == 80f))
			{
				Player target = Main.player[npc.target];
				if (Collision.CanHit(npc.position, npc.width, npc.height, target.position, target.width, target.height))
				{
					float speed = 2.2f;
					Vector2 npcCenter = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
					float targetX = target.position.X + target.width * 0.5f - npcCenter.X + Main.rand.Next(-100, 101);
					float targetY = target.position.Y + target.height * 0.5f - npcCenter.Y + Main.rand.Next(-100, 101);
					float length = (float)Math.Sqrt(targetX * targetX + targetY * targetY);
					length = speed / length;

					targetX *= length;
					targetY *= length;
					
					Main.projectile[Projectile.NewProjectile(npcCenter.X, npcCenter.Y, targetX, targetY, ProjectileID.Bone, 83, 0f, Main.myPlayer, 0f, 0f)].timeLeft = 3000;
				}
			}
			else if (npc.ai[0] >= 150 + Main.rand.Next(150))
				npc.ai[0] = 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.2f);

				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GSGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GSGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GSGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GSGore3"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo) && Main.bloodMoon && spawnInfo.spawnTileY < Main.worldSurface ? 0.001f : 0f;
	}
}