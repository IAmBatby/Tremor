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
	public class TikiSoul : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tiki Soul");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 600;
			npc.damage = 12;
			npc.defense = 0;
			npc.knockBackResist = 0f;
			npc.width = 28;
			npc.height = 34;
			npc.aiStyle = -1;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit31;
			npc.noGravity = true;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.value = Item.buyPrice(0, 0, 15, 0);
			NPCID.Sets.TrailCacheLength[npc.type] = 5;
		}

		int ShootRate = 4;
		int TimeToShoot = 4;
		public override bool PreAI()
		{
			bool expertMode = Main.expertMode;
			npc.TargetClosest(true);
			Vector2 direction = Main.player[npc.target].Center - npc.Center;
			direction.Normalize();
			direction *= 9f;
			Player player = Main.player[npc.target];
			NPC parent = Main.npc[NPC.FindFirstNPC(mod.NPCType("TikiTotem"))];
			double deg = (double)npc.ai[1] / 2;
			double rad = deg * (Math.PI / 150);
			double dist = 240;
			npc.position.X = parent.Center.X - (int)(Math.Cos(rad) * dist) - npc.width / 2;
			npc.position.Y = parent.Center.Y - (int)(Math.Sin(rad) * dist) - npc.height / 2;
			npc.ai[1] += 2f;
			if (--this.TimeToShoot <= 0)
			{
				this.TimeToShoot = this.ShootRate;
				NPC parent2 = Main.npc[NPC.FindFirstNPC(mod.NPCType("TikiTotem"))];
				Vector2 Velocity = Helper.VelocityToPoint(npc.Center, parent2.Center, 20);
				//int k = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Velocity.X, Velocity.Y, mod.ProjectileType("TikiSoulPro"), 0, 1f);
				//Main.projectile[k].friendly = false;
				//Main.projectile[k].tileCollide = false;
				//Main.projectile[k].hostile = true;
			}
			return false;
		}


		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
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