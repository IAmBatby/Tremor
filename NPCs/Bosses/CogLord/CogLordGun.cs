using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Tremor.NPCs.Bosses.CogLord.CogLord;

namespace Tremor.NPCs.Bosses.CogLord
{
	public class CogLordGun : HandAI
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cog Lord Gun");
		}

		private const int ShootRate = 120;
		private const int ShootDamage = 20;
		private const float ShootKn = 1.0f;
		private const int ShootType = 88;
		private const float ShootSpeed = 5;
		private const int ShootCount = 10;
		private const int Spread = 45;
		private const float SpreadMult = 0.045f;
		private const float MaxDist = 250f;

		public override void SetDefaults()
		{
			npc.lifeMax = 20000;
			npc.damage = 80;
			npc.defense = 20;
			npc.knockBackResist = 0f;
			npc.width = 88;
			npc.height = 46;
			npc.aiStyle = -1;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath14;
			npc.value = Item.buyPrice(0, 0, 5, 0);
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CogLordGun"), 1f);
			}
		}

		float ShootTimer
		{
			get { return npc.localAI[0]; }
			set { npc.localAI[0] = value; }
		}

		public override void AI()
		{
			base.AI();

			if (Boss.active && Boss.type == mod.NPCType<CogLord>())
			{
				if (Main.netMode != NetmodeID.MultiplayerClient && Main.player[Boss.target].active && npc.localAI[3] == 0)
				{
					npc.rotation = Helper.rotateBetween2Points(npc.Center, Main.player[Boss.target].Center);
					if (ShootTimer++ > ShootRate)
						Shoot();
				}
			}

			npc.dontTakeDamage = NPC.AnyNPCs(mod.NPCType<CogLordProbe>());
		}

		private void Shoot()
		{
			ShootTimer = 0;
			Vector2 velocity = Helper.VelocityToPoint(npc.Center, Main.player[Boss.target].Center, ShootSpeed);
			for (int i = 0; i < 2; i++)
			{
				velocity.X = velocity.X + Main.rand.Next(-Spread, Spread + 1) * SpreadMult;
				velocity.Y = velocity.Y + Main.rand.Next(-Spread, Spread + 1) * SpreadMult;
				int index = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, velocity.X, velocity.Y, ShootType, ShootDamage, ShootKn);
				Main.projectile[index].hostile = true;
				Main.projectile[index].friendly = false;
			}
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