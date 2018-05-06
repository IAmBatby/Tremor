using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.NPCs.Bosses.CogLord.Projectiles
{
	public class CogLordProbeLaser : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 10;
			projectile.hostile = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.hide = true;
			cooldownSlot = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cog Lord Probe Laser");
		}

		float LaserLength
		{
			get { return projectile.localAI[0]; }
			set { projectile.localAI[0] = value; }
		}

		NPC CogLordBoss => Main.npc[(int)projectile.ai[1]];
		NPC Probe => Main.npc[(int)projectile.ai[0]];

		public override bool ShouldUpdatePosition() => false;
		public override void DrawBehind(int index, List<int> drawCacheProjsBehindNPCsAndTiles, List<int> drawCacheProjsBehindNPCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverWiresUI) => drawCacheProjsBehindNPCs.Add(index);

		float probeOffset = 21;

		public override void AI()
		{
			if (projectile.ai[0] >= 0 && projectile.ai[0] < 200 && Probe.active && Probe.type == mod.NPCType<CogLordProbe>() &&
				projectile.ai[1] >= 0 && projectile.ai[1] < 200 && CogLordBoss.active && CogLordBoss.type == mod.NPCType<CogLord>())
				projectile.timeLeft = 2;

			Vector2 toBoss = CogLordBoss.Center - Probe.Center;
			LaserLength = toBoss == Vector2.Zero ? float.Epsilon : toBoss.Length();
			toBoss /= LaserLength;
			projectile.velocity = toBoss;
			projectile.Center = Probe.Center + projectile.velocity * probeOffset;
			projectile.rotation = projectile.velocity.ToRotation();

			DelegateMethods.v3_1 = Color.Yellow.ToVector3();
			Utils.PlotTileLine(projectile.Center, projectile.Center + projectile.velocity * projectile.localAI[1], projectile.width * projectile.scale, new Utils.PerLinePoint(DelegateMethods.CastLight));
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			for (int i = 0; i < 2; i++)
			{
				Vector2 drawPos = projectile.Center + new Vector2(0, 1.5f * (i == 0 ? 1 : -1)).RotatedBy(projectile.rotation) - Main.screenPosition;
				Rectangle destRect = new Rectangle((int)Math.Round(drawPos.X), (int)Math.Round(drawPos.Y), (int)(LaserLength - probeOffset * 2), projectile.width);
				Vector2 origin = projectile.Size * 0.5f / (destRect.Size() / Main.blackTileTexture.Size());
				spriteBatch.Draw(
					Main.blackTileTexture,
					destRect,
					null,
					Color.Yellow * 0.5f,
					projectile.rotation,
					origin,
					SpriteEffects.None,
					0f
				);
			}
			return false;
		}
	}
}
