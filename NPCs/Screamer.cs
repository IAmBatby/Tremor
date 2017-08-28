using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

using Tremor.Items;

namespace Tremor.NPCs
{
	public class Screamer : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Screamer");
			Main.npcFrameCount[npc.type] = 4;
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

		public override void AI()
		{
			float maxMoveSpeed = 5f;
			npc.TargetClosest(true);
			Vector2 targetVelocity = Main.player[npc.target].Center - npc.Center;
			float velocityMagnitude = targetVelocity.Length();

			if (velocityMagnitude < 20f)
			{
				targetVelocity = npc.velocity;
			}
			else if (velocityMagnitude < 40f)
			{
				targetVelocity.Normalize();
				targetVelocity *= maxMoveSpeed * 0.35f;
			}
			else if (velocityMagnitude < 80f)
			{
				targetVelocity.Normalize();
				targetVelocity *= maxMoveSpeed * 0.65f;
			}
			else
			{
				targetVelocity.Normalize();
				targetVelocity *= maxMoveSpeed;
			}

			npc.SimpleFlyMovement(targetVelocity, 0.15F);
			npc.rotation = npc.velocity.X * 0.1f;

			if (npc.ai[0]++ >= 70f)
			{
				npc.ai[0] = 0f;
				if (Main.netMode != 1)
				{
					Vector2 randomProjectileVelocity = Vector2.Zero;
					while (Math.Abs(randomProjectileVelocity.X) < 1.5f)
						randomProjectileVelocity = Vector2.UnitY.RotatedByRandom(1.5707963705062866) * new Vector2(5f, 3f);

					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, randomProjectileVelocity.X, randomProjectileVelocity.Y, ProjectileID.AncientDoomProjectile, 60, 0f, Main.myPlayer, 0f, npc.whoAmI);
				}
			}
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool())
				this.NewItem(mod.ItemType<Catalyst>(), Main.rand.Next(6, 13));
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

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> spawnInfo.spawnTileY < Main.rockLayer && NPC.downedMoonlord && Main.eclipse ? 0.001f : 0f;
	}
}