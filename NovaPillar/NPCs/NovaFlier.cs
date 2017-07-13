using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NovaPillar.NPCs
{
	public class NovaFlier : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nova Flier");
			Main.npcFrameCount[npc.type] = 4;
		}

		//Int variables
		int AnimationRate = 4;
		int CountFrame;
		int TimeToAnimation = 4;
		int Timer = 0;

		//Vanilla AI
		static int num1461 = 360;
		float num1453 = 7f;
		float num1463 = 6.28318548f / (num1461 / 2);
		int num1450 = 200;
		int num1472 = 0;
		bool flag128;
		static float scaleFactor10 = 8.5f;
		float num1451 = 0.55f;
		public override void SetDefaults()
		{
			npc.lifeMax = 2150;
			npc.damage = 67;
			npc.defense = 15;
			npc.knockBackResist = 0.2f;
			npc.width = 44;
			npc.height = 56;
			npc.HitSound = SoundID.NPCHit55;
			npc.DeathSound = SoundID.NPCDeath51;
			npc.buffImmune[31] = false;
			npc.npcSlots = 2f;
			npc.aiStyle = 14;
			npc.noGravity = true;
			npc.noTileCollide = false;
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = npc.lifeMax * 1;
			npc.damage = npc.damage * 1;
		}

		public override void AI()
		{
			Player player=Main.player[npc.target];
			if(player.GetModPlayer<TremorPlayer>(mod).ZoneRuins)
			{
				npc.life=-1;
				npc.active=false;
				npc.checkDead();
				return;
			}
			npc.spriteDirection = npc.direction;
			NovaAnimation();
			if (Main.time % 200 == 0)
			{
				Vector2 Velocity = Helper.VelocityToPoint(npc.Center, Helper.RandomPointInArea(new Vector2(player.Center.X - 10, player.Center.Y - 10), new Vector2(player.Center.X + 20, player.Center.Y + 20)), 7);
				int i = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Velocity.X, Velocity.Y, mod.ProjectileType("NovaFlierProj"), 20, 1f);
			}
		}

		public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			TremorUtils.DrawNPCGlowMask(spriteBatch, npc, mod.GetTexture("NovaPillar/NPCs/NovaFlier_GlowMask"));
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				if (NovaHandler.ShieldStrength > 0)
				{
					NPC parent = Main.npc[NPC.FindFirstNPC(mod.NPCType("NovaPillar"))];
					Vector2 Velocity = Helper.VelocityToPoint(npc.Center, parent.Center, 20);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, Velocity.X, Velocity.Y, mod.ProjectileType("CogLordLaser"), 1, 1f);
				}
				for (int i = 0; i < 5; i++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 57, Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(-3f, 3f));
				}
				for (int i = 0; i < 2; i++)
				{
					Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/NovaFlierGore1"));
					Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/NovaFlierGore2"));
				}
				Gore.NewGore(npc.Top, npc.velocity * hitDirection, mod.GetGoreSlot("Gores/NovaFlierGore3"));
				Gore.NewGore(npc.Top, npc.velocity * hitDirection, mod.GetGoreSlot("Gores/NovaFlierGore3"));
			}
		}

		void NovaAnimation()
		{
			if (--TimeToAnimation <= 0)
			{
				if (++CountFrame > 4)
					CountFrame = 1;
				TimeToAnimation = AnimationRate;
				npc.frame = GetFrame(CountFrame + 0);
			}
		}

		Rectangle GetFrame(int Number)
		{
			return new Rectangle(0, npc.frame.Height * (Number - 1), npc.frame.Width, npc.frame.Height);
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.player.GetModPlayer<TremorPlayer>(mod).ZoneTowerNova)
				return 1f;
			return 0;
		}
	}
}
