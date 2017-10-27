using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs.Bosses.NovaPillar
{
	[AutoloadBossHead]
	public class NovaPillar : ModNPC
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nova Pillar");
		}
		public override void SetDefaults()
		{
			npc.aiStyle = 94;
			npc.lifeMax = 20000;
			npc.damage = 0;
			npc.defense = 20;
			npc.knockBackResist = 0f;
			npc.width = 170;
			npc.height = 359;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.noGravity = true;
			npc.npcSlots = 0;
			npc.noTileCollide = true;
			npc.alpha = 0;
			NPCID.Sets.MustAlwaysDraw[npc.type] = true;
			music = MusicID.TheTowers;
		}

		int Timer;
		public override void AI()
		{
			Timer++;
			if (Timer % 150 == 0)
			{
				if (Main.player[npc.target].GetModPlayer<TremorPlayer>(mod).ZoneTowerNova)
				{
					var ShootPos = Main.player[npc.target].position + new Vector2(Main.rand.Next(-1000, 1000), -1000);
					var ShootVel = new Vector2(Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(15f, 20f));
					int i = Projectile.NewProjectile(ShootPos, ShootVel, mod.ProjectileType("NovaBottle"), 34, 1f);
					Main.projectile[i].friendly = false;
				}
			}
			if (NovaHandler.ShieldStrength > 0)
			{
				npc.dontTakeDamage = true;
			}
			else if (npc.dontTakeDamage)
			{
				npc.ai[3] = 30f;
				npc.dontTakeDamage = false;
			}
			if (npc.ai[3] > 0)
			{
				npc.ai[3]--;
			}
			if (Main.rand.NextBool(5))
			{
				Dust dust21 = Main.dust[Dust.NewDust(npc.Left, npc.width, npc.height / 2, 241, 0f, 0f, 0, default(Color), 1f)];
				dust21.position = npc.Center + Vector2.UnitY.RotatedByRandom(2.0943951606750488) * new Vector2(npc.width / 2, npc.height / 2) * (0.8f + Main.rand.NextFloat() * 0.2f);
				dust21.velocity.X = 0f;
				dust21.velocity.Y = Math.Abs(dust21.velocity.Y) * 0.25f;
			}
			for (int num1940 = 0; num1940 < 3; num1940++)
			{
				if (Main.rand.NextBool(5))
				{
					Dust dust22 = Main.dust[Dust.NewDust(npc.Top + new Vector2(-(float)npc.width * (0.33f - 0.11f * num1940), -20f), (int)(npc.width * (0.66f - 0.22f * num1940)), 20, 135, 0f, 0f, 0, default(Color), 1f)];
					dust22.velocity.X = 0f;
					dust22.velocity.Y = -Math.Abs(dust22.velocity.Y - num1940 + npc.velocity.Y - 4f) * 1f;
					dust22.noGravity = true;
					dust22.fadeIn = 1f;
					dust22.scale = 1f + Main.rand.NextFloat() + num1940 * 0.3f;
				}
			}
			if (npc.ai[2] == 1f)
			{
				npc.velocity = Vector2.UnitY * npc.velocity.Length();
				if (npc.velocity.Y < 0.25f)
				{
					npc.velocity.Y = npc.velocity.Y + 0.02f;
				}
				if (npc.velocity.Y > 0.25f)
				{
					npc.velocity.Y = npc.velocity.Y - 0.02f;
				}
				npc.dontTakeDamage = true;
				npc.ai[1] += 1f;
				if (npc.ai[1] > 120f)
				{
					npc.Opacity = 1f - (npc.ai[1] - 120f) / 60f;
				}
				int dustID = 59;
				if (Main.rand.NextBool(5) && npc.ai[1] < 120f)
				{
					for (int i = 0; i < 3; i++)
					{
						Dust dust4 = Main.dust[Dust.NewDust(npc.Left, npc.width, npc.height / 2, dustID)];
						dust4.position = npc.Center + Vector2.UnitY.RotatedByRandom(4.1887903213500977) * new Vector2(npc.width * 1.5f, npc.height * 1.1f) * 0.8f * (0.8f + Main.rand.NextFloat() * 0.2f);
						dust4.velocity.X = 0f;
						dust4.velocity.Y = -Math.Abs(dust4.velocity.Y - i + npc.velocity.Y - 4f) * 3f;
						dust4.noGravity = true;
						dust4.fadeIn = 1f;
						dust4.scale = 1f + Main.rand.NextFloat() + i * 0.3f;
					}
				}
				if (npc.ai[1] < 150f)
				{
					for (int num1362 = 0; num1362 < 3; num1362++)
					{
						if (Main.rand.NextBool(4))
						{
							Dust dust5 = Main.dust[Dust.NewDust(npc.Top + new Vector2(-(float)npc.width * (0.33f - 0.11f * num1362), -20f), (int)(npc.width * (0.66f - 0.22f * num1362)), 20, dustID)];
							dust5.velocity.X = 0f;
							dust5.velocity.Y = -Math.Abs(dust5.velocity.Y - num1362 + npc.velocity.Y - 4f) * (1f + npc.ai[1] / 180f * 0.5f);
							dust5.noGravity = true;
							dust5.fadeIn = 1f;
							dust5.scale = 1f + Main.rand.NextFloat() + num1362 * 0.3f;
						}
					}
				}
				if (Main.rand.NextBool(5) && npc.ai[1] < 150f)
				{
					for (int i = 0; i < 3; i++)
					{
						Vector2 position6 = npc.Center + Vector2.UnitY.RotatedByRandom(4.1887903213500977) * new Vector2(npc.width, npc.height) * 0.7f * Main.rand.NextFloat();
						float num1364 = 1f + Main.rand.NextFloat() * 2f + npc.ai[1] / 180f * 4f;
						for (int num1365 = 0; num1365 < 6; num1365++)
						{
							Dust dust6 = Main.dust[Dust.NewDust(position6, 4, 4, dustID, newColor: Color.Yellow)];
							dust6.position = position6;
							Dust expr_41952_cp_0 = dust6;
							expr_41952_cp_0.velocity.X = expr_41952_cp_0.velocity.X * num1364;
							dust6.velocity.Y = -Math.Abs(dust6.velocity.Y) * num1364;
							dust6.noGravity = true;
							dust6.fadeIn = 1f;
							dust6.scale = 1.5f + Main.rand.NextFloat() + num1365 * 0.13f;
						}
						Main.PlaySound(3, position6, Utils.SelectRandom(Main.rand, 1, 18));
					}
				}
				if (Main.rand.Next(3) != 0 && npc.ai[1] < 150f)
				{
					Dust dust7 = Main.dust[Dust.NewDust(npc.Left, npc.width, npc.height / 2, DustID.MarblePot)];
					dust7.position = npc.Center + Vector2.UnitY.RotatedByRandom(4.1887903213500977) * new Vector2(npc.width / 2, npc.height / 2) * (0.8f + Main.rand.NextFloat() * 0.2f);
					dust7.velocity.X = 0f;
					dust7.velocity.Y = Math.Abs(dust7.velocity.Y) * 0.25f;
				}
				if (npc.ai[1] % 60 == 1)
				{
					Main.PlaySound(SoundID.NPCDeath22, npc.Center);
				}
				if (npc.ai[1] >= 180f)
				{
					npc.alpha++;
					if (npc.alpha >= 255)
					{
						npc.life = 0;
						npc.HitEffect(0, 1337);
						npc.checkDead();
					}
				}
			}
		}

		public override bool CheckActive()
		{
			return false;
		}

		public override bool CheckDead()
		{
			if (npc.ai[2] != 1 && npc.ai[1] < 180)
			{
				npc.ai[2] = 1;
				npc.ai[1] = 0;
				npc.life = npc.lifeMax;
				npc.dontTakeDamage = true;
				npc.netUpdate = true;
				return false;
			}
			return base.CheckDead();
		}

		public override void NPCLoot()
		{
			int stacks = Main.rand.Next(25, 41) / 2;
			if (Main.expertMode)
			{
				stacks = (int)(stacks * 1.5f);
			}
			for (int i = 0; i < stacks; i++)
			{
				Item.NewItem((int)npc.position.X + Main.rand.Next(npc.width), (int)npc.position.Y + Main.rand.Next(npc.height), 2, 2, mod.ItemType("NovaFragment"), Main.rand.Next(1, 4));
			}

			TremorWorld.Boss.NovaPillar.Downed();
			NovaHandler.TowerX = -1;
			NovaHandler.TowerY = -1;
			if (NPC.LunarApocalypseIsUp)
			{
				Main.NewText("Your hands are shaking...", 175, 75, 255);
			}
			else
			{
				WorldGen.StartImpendingDoom();
			}
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			var effects = npc.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(Main.npcTexture[npc.type], npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame,
							 Color.White, npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);
			return false;
		}

		public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			TremorUtils.DrawNPCGlowMask(spriteBatch, npc, mod.GetTexture("NPCs/Bosses/NovaPillar/NovaPillar_GlowMask"));
			float num88 = NovaHandler.ShieldStrength / (float)NPC.ShieldStrengthTowerMax;
			if (NovaHandler.ShieldStrength > 0)
			{
				Main.spriteBatch.End();
				Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointWrap, DepthStencilState.Default, RasterizerState.CullNone);

				var center = npc.Center - Main.screenPosition;
				float num89 = 0f;
				if (npc.ai[3] > 0f && npc.ai[3] <= 30f)
				{
					num89 = 1f - npc.ai[3] / 30f;
				}
				Filters.Scene["Tremor:Nova"].GetShader().UseIntensity(1f + num89).UseProgress(0f);
				DrawData drawData = new DrawData(TextureManager.Load("Images/Misc/Perlin"), center - new Vector2(0, 10), new Rectangle(0, 0, 600, 600), Color.White * (num88 * 0.8f + 0.2f), npc.rotation, new Vector2(300f, 300f), npc.scale * (1f + num89 * 0.05f), SpriteEffects.None, 0);
				GameShaders.Misc["ForceField"].UseColor(new Vector3(1f + num89 * 0.5f));
				GameShaders.Misc["ForceField"].Apply(drawData);
				drawData.Draw(Main.spriteBatch);
				Main.spriteBatch.End();
				Main.spriteBatch.Begin();
				return;
			}
			if (npc.ai[3] > 0f)
			{
				Main.spriteBatch.End();
				Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointWrap, DepthStencilState.Default, RasterizerState.CullNone);
				var center = npc.Center - Main.screenPosition;
				float num90 = npc.ai[3] / 120f;
				float num91 = Math.Min(npc.ai[3] / 30f, 1f);
				Filters.Scene["Tremor:Nova"].GetShader().UseIntensity(Math.Min(5f, 15f * num90) + 1f).UseProgress(num90);
				DrawData drawData = new DrawData(TextureManager.Load("Images/Misc/Perlin"), center - new Vector2(0, 10), new Rectangle(0, 0, 600, 600), new Color(new Vector4(1f - (float)Math.Sqrt(num91))), npc.rotation, new Vector2(300f, 300f), npc.scale * (1f + num91), SpriteEffects.None, 0);
				GameShaders.Misc["ForceField"].UseColor(new Vector3(2f));
				GameShaders.Misc["ForceField"].Apply(drawData);
				drawData.Draw(Main.spriteBatch);
				Main.spriteBatch.End();
				Main.spriteBatch.Begin();
				return;
			}
			Filters.Scene["Tremor:Nova"].GetShader().UseIntensity(0f).UseProgress(0f);
		}
	}
}
