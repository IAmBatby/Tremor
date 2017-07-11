using Terraria.ID;
using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs
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
			//npc.damage = 250;
			npc.defense = 10;
			npc.knockBackResist = 0f;
			npc.width = 42;
			npc.height = 42;
			npc.aiStyle = 14;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath10;
			npc.value = Item.buyPrice(0, 1, 0, 0);
		}

		int ShootRate = 4;
		int TimeToShoot = 4;
		public override void AI()
		{
			npc.position += npc.velocity * 1.7f;
			npc.rotation = Helper.rotateBetween2Points(npc.Center, Main.npc[(int)npc.ai[0]].Center);
			while (npc.Distance(Main.npc[(int)npc.ai[0]].position) > 1000)
			{
				npc.Center = Main.npc[(int)npc.ai[0]].Center;
			}
			if (--this.TimeToShoot <= 0)
			{
				this.TimeToShoot = this.ShootRate;
				NPC parent = Main.npc[NPC.FindFirstNPC(mod.NPCType("CogLord"))];
				Vector2 Velocity = Helper.VelocityToPoint(npc.Center, parent.Center, 20);
				int k = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Velocity.X, Velocity.Y, mod.ProjectileType("CogLordLaser"), 100, 1f);
				Main.projectile[k].friendly = false;
				Main.projectile[k].tileCollide = false;
				Main.projectile[k].hostile = true;
			}
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			Texture2D drawTexture = Main.npcTexture[npc.type];
			Vector2 origin = new Vector2((drawTexture.Width / 2) * 0.5F, (drawTexture.Height / Main.npcFrameCount[npc.type]) * 0.5F);
			Vector2 drawPos = new Vector2(
				npc.position.X - Main.screenPosition.X + (npc.width / 2) - (Main.npcTexture[npc.type].Width / 2) * npc.scale / 2f + origin.X * npc.scale,
				npc.position.Y - Main.screenPosition.Y + npc.height - Main.npcTexture[npc.type].Height * npc.scale / Main.npcFrameCount[npc.type] + 4f + origin.Y * npc.scale + npc.gfxOffY);
			SpriteEffects effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(drawTexture, drawPos, npc.frame, Color.White, npc.rotation, origin, npc.scale, effects, 0);
			return false;
		}
	}
}