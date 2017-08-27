using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class Galasquid : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Galasquid");
			Main.npcFrameCount[npc.type] = 5;
		}

		public override void SetDefaults()
		{
			npc.aiStyle = -1;
			npc.lifeMax = 4250;
			npc.damage = 125;
			npc.defense = 75;
			animationType = 82;
			npc.knockBackResist = 0.03f;
			npc.width = 40;
			npc.height = 60;
			npc.value = Item.buyPrice(0, 2, 0, 0);
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
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
			npc.TargetClosest(true);

			float moveSpeed = 5f;

			Vector2 targetVelocity = Main.player[npc.target].Center - npc.Center;
			float velocityLength = targetVelocity.Length();

			// Depending on the distance between this NPC and its target player, we make the NPC move faster or slower.
			if (velocityLength < 20)
				targetVelocity = npc.velocity;
			else if (velocityLength < 40)
			{
				targetVelocity.Normalize();
				targetVelocity *= moveSpeed * 0.35f;
			}
			else if (velocityLength < 80)
			{
				targetVelocity.Normalize();
				targetVelocity *= moveSpeed * 0.65f;
			}
			else
			{
				targetVelocity.Normalize();
				targetVelocity *= moveSpeed;
			}
			npc.SimpleFlyMovement(targetVelocity, 0.15F);
			npc.rotation = npc.velocity.X * 0.1f;

			if (Main.netMode != 1 && npc.ai[0]++ >= 70)
			{
				Vector2 projectileVelocity = Vector2.Zero;
				while (Math.Abs(projectileVelocity.X) < 1.5f)
					projectileVelocity = Vector2.UnitY.RotatedByRandom(Math.PI / 2) * new Vector2(5f, 3f);

				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, projectileVelocity.X, projectileVelocity.Y, ProjectileID.MartianTurretBolt, 60, 0f, Main.myPlayer, 0f, npc.whoAmI);
				npc.ai[0] = 0f;
			}
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool())
				npc.NewItem(mod.ItemType<Catalyst>(), Main.rand.Next(5, 12));
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GalasquidGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GalasquidGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GalasquidGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/GalasquidGore2"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> spawnInfo.spawnTileY < Main.rockLayer && NPC.downedMoonlord && spawnInfo.spawnTileType == mod.TileType("CometiteOreTile") || spawnInfo.spawnTileType == mod.TileType("HardCometiteOreTile") ? 0.005f : 0f;
	}
}