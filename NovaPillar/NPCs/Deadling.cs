using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NovaPillar.NPCs
{
	public class Deadling : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nova Kamikaze");
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.aiStyle = 87;
			npc.damage = 60;
			npc.width = 24;
			npc.height = 26;
			npc.defense = 50;
			npc.lifeMax = 1000;
			npc.knockBackResist = 0f;
			animationType = 81;
			npc.noGravity = false;
			npc.noTileCollide = false;
			npc.HitSound = SoundID.NPCHit55;
			npc.DeathSound = SoundID.NPCDeath51;
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = npc.lifeMax * 1;
			npc.damage = npc.damage * 1;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.player.GetModPlayer<TremorPlayer>(mod).ZoneTowerNova)
				return 1f;
			return 0;
		}

		public override bool PreAI()
		{
			if(Main.player[npc.target].GetModPlayer<TremorPlayer>(mod).ZoneRuins)
			{
				npc.life=-1;
				npc.active=false;
				npc.checkDead();
				return false;
			}
			return true;
		}

		public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			TremorUtils.DrawNPCGlowMask(spriteBatch, npc, mod.GetTexture("NovaPillar/NPCs/Deadling_GlowMask"));
		}

		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			npc.life = -1;
			npc.active = false;
			npc.checkDead();
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
			for (int k = 0; k < 30; k++)
			{
				Vector2 Vector = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
				Vector.Normalize();
				Vector *= Main.rand.Next(10, 201) * 0.01f;
				int i = Projectile.NewProjectile(npc.position.X, npc.position.Y, Vector.X, Vector.Y, mod.ProjectileType("NovaAlchemistCloud"), 20, 1f, Main.myPlayer, 0f, Main.rand.Next(-45, 1));
				Main.projectile[i].friendly = false;
			}
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
				for (int k = 0; k < 30; k++)
				{
					Vector2 Vector = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
					Vector.Normalize();
					Vector *= Main.rand.Next(10, 201) * 0.01f;
					int i = Projectile.NewProjectile(npc.position.X, npc.position.Y, Vector.X, Vector.Y, mod.ProjectileType("NovaAlchemistCloud"), 20, 1f, Main.myPlayer, 0f, Main.rand.Next(-45, 1));
					Main.projectile[i].friendly = false;
				}
			}
		}
	}
}