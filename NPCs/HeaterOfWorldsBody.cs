using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
{
	public class HeaterOfWorldsBody : HeaterofWorldsPart
	{
		const int MaxCooldown = 240;

		public float ShootCooldown
		{
			get { return npc.ai[0]; }
			set { npc.ai[0] = value; }
		}

		public override void SetDefaults()
		{
			base.SetDefaults();
			npc.width = 26;
			npc.height = 48;
		}

		public override void AI()
		{
			if (JustSpawned)
			{
				ShootCooldown = MaxCooldown;
				JustSpawned = false;
			}
			CheckSegments();
			TryShoot();
			DustFX();
		}

		private void TryShoot()
		{
			if (Main.rand.NextBool())
				ShootCooldown -= 1;

			npc.TargetClosest(false);

			if (Main.netMode != NetmodeID.MultiplayerClient
			    && npc.HasValidTarget
				&& ShootCooldown <= 0)
			{
				ShootCooldown = MaxCooldown;
				Vector2 velocity = Helper.VelocityFPTP(npc.Center, Main.player[npc.target].Center, 4);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, velocity.X, velocity.Y, 326, 10, 1f);
			}
		}

		private void DustFX()
		{
			if (Main.rand.NextBool(3))
			{
				for (int i = 0; i < 2; i++)
				{
					Dust dust = Dust.NewDustPerfect(npc.position, 6, Alpha: 200);
					dust.noGravity = true;
				}
			}
		}

		public override bool CheckActive()
		{
			return false;
		}

		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			return false;
		}
	}
}