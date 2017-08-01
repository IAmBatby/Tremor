using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.NovaPillar.NPCs
{
	public class NovaBat : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nova Bat");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.lifeMax = 2250;
			npc.damage = 100;
			npc.defense = 45;
			npc.knockBackResist = 0.3f;
			npc.width = 40;
			npc.height = 20;
			animationType = 75;
			npc.aiStyle = 14;
			npc.npcSlots = 0.5f;
			npc.noGravity = true;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.player.GetModPlayer<TremorPlayer>(mod).ZoneTowerNova)
				return 1f;
			return 0;
		}

		public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			TremorUtils.DrawNPCGlowMask(spriteBatch, npc, mod.GetTexture("NovaPillar/NPCs/NovaBat_GlowMask"));
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
				for (int k = 0; k < 19; k++)
				{
					Vector2 Vector = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
					Vector.Normalize();
					Vector *= Main.rand.Next(10, 201) * 0.01f;
					int i = Projectile.NewProjectile(npc.position.X, npc.position.Y, Vector.X, Vector.Y, mod.ProjectileType("NovaAlchemistCloud"), 20, 1);
					Main.projectile[i].friendly = false;
				}
				for (int i = 0; i < 5; i++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 57, Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(-3f, 3f));
				}
				for (int i = 0; i < 2; i++)
				{
					Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/NovaBatGore2"));
					Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/NovaBatGore2"));
				}
				Gore.NewGore(npc.Top, npc.velocity * hitDirection, mod.GetGoreSlot("Gores/NovaBatGore3"));
				Gore.NewGore(npc.Top, npc.velocity * hitDirection, mod.GetGoreSlot("Gores/NovaBatGore1"));
			}
		}

		public override void AI()
		{
			npc.position += npc.velocity * 1.33f;
			if (Main.time % 120 == 0)
			{
				for (int k = 0; k < 19; k++)
				{
					Vector2 Vector = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
					Vector.Normalize();
					Vector *= Main.rand.Next(10, 201) * 0.01f;
					int i = Projectile.NewProjectile(npc.position.X, npc.position.Y, Vector.X, Vector.Y, mod.ProjectileType("NovaAlchemistCloud"), 20, 1);
					Main.projectile[i].friendly = false;
				}
			}
		}
	}
}