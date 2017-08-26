using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	public class SignalDrone : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Signal Drone");
		}

		public override void SetDefaults()
		{
			npc.noTileCollide = true;
			npc.noGravity = true;
			npc.lifeMax = 1500;
			npc.damage = 75;
			npc.defense = 18;
			npc.knockBackResist = 0.5f;
			npc.width = 90;
			npc.height = 90;
			npc.aiStyle = 0;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath14;
		}

		private void UpdateDroneImmunities()
		{
			foreach (NPC drone in Main.npc.Where(x => x.type == npc.type && npc.active))
			{
				var signalDrone = drone.modNPC as SignalDrone;
				if (signalDrone != null)
				{
					signalDrone._immuneTime = 180;
					signalDrone.npc.netUpdate = true;
				}
			}
		}

		protected void UpdateMyImmunity()
		{
			_immuneTime = Math.Max(0, _immuneTime - 1);
		}

		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			UpdateDroneImmunities();
		}

		public override bool CanHitPlayer(Player target, ref int cooldownSlot)
			=> _immuneTime <= 0;


		public override void AI()
		{
			CheckParent();
			SharknadoStyledAI();
			UpdateMyImmunity();
		}

		public override bool CheckActive() => false;

		private void CheckParent()
		{
			if (Motherboard.type != mod.NPCType("Motherboard") 
				|| !Motherboard.active)
			{
				npc.active = false;
				npc.netUpdate = true;
			}
		}

		private float _immuneTime
		{
			get { return npc.ai[1]; }
			set { npc.ai[1] = value; }
		}
		private NPC Motherboard => Main.npc[(int)npc.ai[3]];

		private void SharknadoStyledAI()
		{
			// The amount of spacing
			// Default: 0.1f
			const float spacingValue = 0.25f;
			float spacingTreshold = (float)npc.width * 2f;

			// Some movement control
			// This adds spacing between units
			// So that they dont all stack on the same position because they have the same AI
			for (int i = 0; i < Main.maxNPCs; i++)
			{
				NPC otherNPC = Main.npc[i];
				if (i != npc.whoAmI // not us
				    && otherNPC.active // active
				    && otherNPC.type == npc.type // same type
				    &&
				    // Basically this makes sure the padding movement code
				    // only kicks in if the units are within treshold range
				    Math.Abs(npc.position.X - otherNPC.position.X)  // absolute x position difference
				    + Math.Abs(npc.position.Y - otherNPC.position.Y)  // absolute y position difference
				    < spacingTreshold) // differences added up are lower than treshold
				{
					// Control X
					if (npc.position.X < otherNPC.position.X)
					{
						npc.velocity.X = npc.velocity.X - spacingValue;
					}
					else
					{
						npc.velocity.X = npc.velocity.X + spacingValue;
					}

					// Control Y
					if (npc.position.Y < otherNPC.position.Y)
					{
						npc.velocity.Y = npc.velocity.Y - spacingValue;
					}
					else
					{
						npc.velocity.Y = npc.velocity.Y + spacingValue;
					}
				}
			}

			npc.TargetClosest();
			
			Entity target =
				npc.target != -1
				&& !Main.player[npc.target].dead
					? (Entity)Main.player[npc.target]
					: (Entity)Motherboard;

			float velocityMultiplier = 
				(target as NPC) != null
				? 16f : 10f; // 16f is pretty much as fast as the player

			Vector2 distanceToTarget = target.Center - npc.Center + new Vector2(0f, -20f);

			if (Math.Abs(distanceToTarget.X) > 40f
				|| Math.Abs(distanceToTarget.Y) > 10f)
			{
				distanceToTarget.Normalize();
				distanceToTarget *= velocityMultiplier;
				distanceToTarget *= new Vector2(1.25f, 0.65f);
				npc.velocity = (npc.velocity * 20f + distanceToTarget) / 21f;
			}
			else
			{
				if (npc.velocity.X == 0f && npc.velocity.Y == 0f)
				{
					npc.velocity.X = -0.15f;
					npc.velocity.Y = -0.05f;
				}
				npc.velocity *= 1.01f;
			}

			// Rotation
			npc.rotation = npc.velocity.X * 0.05f;

			// Sprite direction
			if (npc.velocity.X > 0f)
			{
				npc.spriteDirection = (npc.direction = -1);
			}
			else if (npc.velocity.X < 0f)
			{
				npc.spriteDirection = (npc.direction = 1);
			}
		}
	}
}