using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Tremor.NPCs.Bosses.CogLord.Projectiles;

namespace Tremor.NPCs.Bosses.CogLord
{
	public class CogLordProbe : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cog Lord Probe");
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 4500;
			npc.defense = 10;
			npc.knockBackResist = 0f;
			npc.width = 42;
			npc.height = 42;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath10;
			npc.value = Item.buyPrice(0, 1);
		}

		protected NPC Boss => Main.npc[(int)npc.ai[0]];
		
		bool ShootLaser
		{
			get { return npc.localAI[0] == 0; }
			set { npc.localAI[0] = value ? 0 : 1; }
		}

		public override void AI()
		{
			if (!Boss.active || Boss.type != mod.NPCType<CogLord>())
			{
				npc.active = false;
				return;
			}

			npc.TargetClosest(true);
			Player target = Main.player[npc.target];

			if (npc.direction == -1 && npc.velocity.X > -4f)
			{
				npc.velocity.X -= 0.1f;
				if (npc.velocity.X > 4f)
					npc.velocity.X -= 0.1f;
				else if (npc.velocity.X > 0f)
					npc.velocity.X += 0.05f;
				if (npc.velocity.X < -4f)
					npc.velocity.X = -4f;
			}
			else if (npc.direction == 1 && npc.velocity.X < 4f)
			{
				npc.velocity.X += 0.1f;
				if (npc.velocity.X < -4f)
					npc.velocity.X += 0.1f;
				else if (npc.velocity.X < 0f)
					npc.velocity.X -= 0.05f;
				if (npc.velocity.X > 4f)
					npc.velocity.X = 4f;
			}
			if (npc.directionY == -1 && npc.velocity.Y > -1.5f)
			{
				npc.velocity.Y -= 0.04f;
				if (npc.velocity.Y > 1.5f)
					npc.velocity.Y -= 0.05f;
				else if (npc.velocity.Y > 0f)
					npc.velocity.Y += 0.03f;
				if (npc.velocity.Y < -1.5f)
					npc.velocity.Y = -1.5f;
			}
			else if (npc.directionY == 1 && npc.velocity.Y < 1.5f)
			{
				npc.velocity.Y += 0.04f;
				if (npc.velocity.Y < -1.5f)
					npc.velocity.Y += 0.05f;
				else if (npc.velocity.Y < 0f)
					npc.velocity.Y -= 0.03f;
				if (npc.velocity.Y > 1.5f)
					npc.velocity.Y = 1.5f;
			}

			if (++npc.ai[1] > 200f)
			{
				if (!target.wet && Collision.CanHit(npc.position, npc.width, npc.height, target.position, target.width, target.height))
				{
					npc.ai[1] = 0f;
				}
				float accelX = 0.2f;
				float accelY = 0.1f;
				float maxSpeedX = 4f;
				float maxSpeedY = 1.5f;

				if (npc.ai[1] > 1000f)
					npc.ai[1] = 0f;

				if (++npc.ai[2] > 0f)
				{
					if (npc.velocity.Y < maxSpeedY)
						npc.velocity.Y += accelY;
				}
				else if (npc.velocity.Y > -maxSpeedY)
					npc.velocity.Y -= accelY;
				if (npc.ai[2] < -150f || npc.ai[2] > 150f)
				{
					if (npc.velocity.X < maxSpeedX)
						npc.velocity.X += accelX;
				}
				else if (npc.velocity.X > -maxSpeedX)
					npc.velocity.X -= accelX;
				if (npc.ai[2] > 300f)
					npc.ai[2] = -300f;
			}

			npc.position += npc.velocity * 1.7f;
			npc.rotation = Helper.rotateBetween2Points(npc.Center, Boss.Center);
			if (npc.Distance(Boss.Center) > 1000)
				npc.Center = Boss.Center;

			if (ShootLaser && Main.netMode != NetmodeID.MultiplayerClient)
			{
				Projectile.NewProjectile(npc.Center, Vector2.Zero, mod.ProjectileType<CogLordProbeLaser>(), 30, 1f, Main.myPlayer, npc.whoAmI, Boss.whoAmI);
				ShootLaser = false;
			}
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			Texture2D drawTexture = Main.npcTexture[npc.type];
			Vector2 origin = npc.frame.Size() * 0.5f;
			Vector2 drawPos = npc.Center - Main.screenPosition;
			SpriteEffects effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(drawTexture, drawPos, npc.frame, Color.White, npc.rotation, origin * npc.scale, npc.scale, effects, 0);
			return false;
		}
	}
}