using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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

		protected override bool CanMeleeAttack => false;
		protected override float ArmDrawOffset => 76f;

		public override void SetDefaults()
		{
			npc.lifeMax = 20000;
			npc.damage = 80;
			npc.defense = 20;
			npc.knockBackResist = 0f;
			npc.width = 50;
			npc.height = 50;
			npc.aiStyle = -1;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath14;
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
			get { return npc.localAI[1]; }
			set { npc.localAI[1] = value; }
		}

		public override void AI()
		{
			base.AI();

			if (Boss.active && Boss.type == mod.NPCType<CogLord>())
			{
				if (Main.netMode != NetmodeID.MultiplayerClient && Main.player[Boss.target].active && npc.localAI[3] == 0)
				{
					npc.rotation = (Main.player[Boss.target].Center - npc.Center).ToRotation();
					if (npc.spriteDirection == 1)
						npc.rotation += MathHelper.Pi;
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
			base.PreDraw(spriteBatch, lightColor);
			Texture2D drawTexture = Main.npcTexture[npc.type];
			Vector2 drawPos = npc.Center - Main.screenPosition;
			Vector2 origin = new Vector2(npc.spriteDirection == -1 ? 18 : drawTexture.Width - 18, 18);
			SpriteEffects effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(drawTexture, drawPos, npc.frame, npc.dontTakeDamage ? Color.Yellow : Color.White, npc.rotation, origin * npc.scale, npc.scale, effects, 0);
			return false;
		}
	}
}