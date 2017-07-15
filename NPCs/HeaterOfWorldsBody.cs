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
		const int CDMax = 160;
		int ShootCD = CDMax;

		public override void SetDefaults()
		{
			npc.width = 26;
			npc.height = 48;
		}

		public override void AI()
		{
			CheckSegments();
			TryShoot();
			DustFX();
		}

		private void TryShoot()
		{
			if (Main.netMode != NetmodeID.MultiplayerClient
			    && npc.target != -1
				&& --ShootCD <= 0)
			{
				ShootCD = CDMax;
				Vector2 velocity = Helper.VelocityFPTP(npc.Center, Main.player[npc.target].Center, 4);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, velocity.X, velocity.Y, 326, 10, 1f);
			}
		}

		private void DustFX()
		{
			if (Helper.Chance(3))
			{
				for (int i = 0; i < 2; i++)
					Dust.NewDust(npc.position, npc.width, npc.height, 6, 0f, 0f, 200, npc.color, 1f);
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