
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.CogLord.NPCs
{
	/*
	 * npc.ai[0] = Index of the Cog Lord boss in the Main.npc array.
	 * npc.ai[1] = State manager.
	 * npc.ai[2] = (Shoot) timer.
	 */
	public class CogLordGun : ModNPC
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

		private int _timeToShoot = ShootRate;

		public override void SetDefaults()
		{
			npc.lifeMax = 20000;
			npc.damage = 80;
			npc.defense = 20;
			npc.knockBackResist = 0f;
			npc.width = 88;
			npc.height = 46;
			npc.aiStyle = 12;
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

		private bool _firstAi = true;
		public override void AI()
		{
			if (_firstAi)
			{
				_firstAi = false;
				MakeArms();
			}
			if (Main.npc[(int)npc.ai[1]].type == mod.NPCType("CogLord") && Main.npc[(int)npc.ai[1]].active)
				if (Main.player[Main.npc[(int)npc.ai[1]].target].active)
				{
					if (npc.localAI[3] == 0f)
					{
						npc.rotation = Helper.rotateBetween2Points(npc.Center, Main.player[Main.npc[(int)npc.ai[1]].target].Center);
						if (--_timeToShoot <= 0) Shoot();
					}
				}
			if (NPC.AnyNPCs(mod.NPCType("CogLordProbe")))
			{
				npc.dontTakeDamage = true;
			}
			else
			{
				npc.dontTakeDamage = false;
			}
			Vector2 cogLordCenter = Main.npc[(int)npc.ai[1]].Center;
			Vector2 distance = npc.Center - cogLordCenter;
			if (distance.Length() >= MaxDist)
			{
				distance.Normalize();
				distance *= MaxDist;
				npc.Center = cogLordCenter + distance;
			}
		}

		private void MakeArms()
		{
			int arm = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("CogLordArm"), 0, 9999, 1, 1, npc.ai[1]);
			int arm2 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("CogLordArmSecond"), 0, npc.whoAmI, 0, 1, arm);
			Main.npc[arm].ai[0] = arm2;
		}

		private void Shoot()
		{
			_timeToShoot = ShootRate;
			if (Main.npc[(int)npc.ai[1]].target != -1)
			{
				Vector2 velocity = Helper.VelocityToPoint(npc.Center, Main.player[Main.npc[(int)npc.ai[1]].target].Center, ShootSpeed);
				for (int l = 0; l < 2; l++)
				{
					velocity.X = velocity.X + Main.rand.Next(-Spread, Spread + 1) * SpreadMult;
					velocity.Y = velocity.Y + Main.rand.Next(-Spread, Spread + 1) * SpreadMult;
					int i = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, velocity.X, velocity.Y, ShootType, ShootDamage, ShootKn);
					Main.projectile[i].hostile = true;
					Main.projectile[i].friendly = false;
				}
			}
		}

		public override bool PreNPCLoot()
		{
			npc.aiStyle = -1;
			npc.ai[1] = -1;
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