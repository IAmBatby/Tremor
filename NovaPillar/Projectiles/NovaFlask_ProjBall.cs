using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NovaPillar.Projectiles
{
	public class NovaFlask_ProjBall : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.SpikyBall);
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.timeLeft = 180;
			projectile.width = 20;
			Main.projFrames[projectile.type] = 3;
			projectile.height = 20;
			if (Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("BouncingCasingBuff")))
			{
				projectile.scale = 3f;
			}
			else
				projectile.scale = 1f;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (Main.rand.Next(1, 101) <= Main.player[projectile.owner].GetModPlayer<MPlayer>(mod).alchemistCrit)
			{
				crit = true;
			}
		}

		public override void AI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter > 3)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
			}
			if (projectile.frame >= 3)
			{
				projectile.frame = 0;
			}
			for (int i = 0; i < Main.dust.Length; i++)
			{
				if ((Main.dust[i].type == DustID.Fire || Main.dust[i].type == 31 || Main.dust[i].type == 6) && projectile.Distance(Main.dust[i].position) < 150f)
				{
					Main.dust[i].scale /= 1000000f;
					Main.dust[i].active = false;
				}
			}
		}

		public override void Kill(int timeLeft)
		{
			Player player = Main.player[projectile.owner];
			MPlayer modPlayer = (MPlayer)player.GetModPlayer(mod, "MPlayer");
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("NovaFlask_ProjFire"), projectile.damage - 30, 0, Main.myPlayer);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("NovaFlask_ProjFire"), projectile.damage - 30, 0, Main.myPlayer);

			if (projectile.owner == Main.myPlayer)
			{
				if (Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("PyroBuff")) && !modPlayer.nitro)
				{
					Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 62);
					int a = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1.5f, projectile.owner);
					Main.projectile[a].scale = 1.5f;
				}
				if (Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("ChemikazeBuff")) && !modPlayer.nitro)
				{
					Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 62);
					int a = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1.25f, projectile.owner);
					Main.projectile[a].scale = 1.25f;
					int b = Projectile.NewProjectile(projectile.position.X + 32, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1f, projectile.owner);
					int c = Projectile.NewProjectile(projectile.position.X - 32, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1f, projectile.owner);
					int d = Projectile.NewProjectile(projectile.position.X, projectile.position.Y + 32, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1f, projectile.owner);
					int e = Projectile.NewProjectile(projectile.position.X, projectile.position.Y - 32, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1f, projectile.owner);
				}
				if (Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("CrossBlastBuff")) && !modPlayer.nitro)
				{
					Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 62);
					int a = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1.25f, projectile.owner);
					Main.projectile[a].scale = 1.25f;
					int b = Projectile.NewProjectile(projectile.position.X + 30, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1f, projectile.owner);
					int c = Projectile.NewProjectile(projectile.position.X - 30, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1f, projectile.owner);
					int d = Projectile.NewProjectile(projectile.position.X, projectile.position.Y + 30, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1f, projectile.owner);
					int e = Projectile.NewProjectile(projectile.position.X, projectile.position.Y - 30, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1f, projectile.owner);
					int f = Projectile.NewProjectile(projectile.position.X + 50, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 0.7f, projectile.owner);
					Main.projectile[f].scale = 0.7f;
					int g = Projectile.NewProjectile(projectile.position.X - 50, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 0.7f, projectile.owner);
					Main.projectile[g].scale = 0.7f;
					int h = Projectile.NewProjectile(projectile.position.X, projectile.position.Y + 50, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 0.7f, projectile.owner);
					Main.projectile[h].scale = 0.7f;
					int i = Projectile.NewProjectile(projectile.position.X, projectile.position.Y - 50, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 0.7f, projectile.owner);
					Main.projectile[i].scale = 0.7f;
					int j = Projectile.NewProjectile(projectile.position.X + 70, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 0.5f, projectile.owner);
					Main.projectile[j].scale = 0.8f;
					int k = Projectile.NewProjectile(projectile.position.X - 70, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 0.5f, projectile.owner);
					Main.projectile[k].scale = 0.8f;
					int l = Projectile.NewProjectile(projectile.position.X, projectile.position.Y + 70, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 0.5f, projectile.owner);
					Main.projectile[l].scale = 0.8f;
					int m = Projectile.NewProjectile(projectile.position.X, projectile.position.Y - 70, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 0.5f, projectile.owner);
					Main.projectile[m].scale = 0.8f;
				}
				if (Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("RoundBlastBuff")) && !modPlayer.nitro)
				{
					Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 62);
					int a = Projectile.NewProjectile(projectile.position.X + 60, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1f, projectile.owner);
					int b = Projectile.NewProjectile(projectile.position.X - 60, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1f, projectile.owner);
					int c = Projectile.NewProjectile(projectile.position.X, projectile.position.Y + 60, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1f, projectile.owner);
					int d = Projectile.NewProjectile(projectile.position.X, projectile.position.Y - 60, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1f, projectile.owner);
					int e = Projectile.NewProjectile(projectile.position.X + 40, projectile.position.Y + 40, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1f, projectile.owner);
					int f = Projectile.NewProjectile(projectile.position.X - 40, projectile.position.Y + 40, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1f, projectile.owner);
					int g = Projectile.NewProjectile(projectile.position.X + 40, projectile.position.Y - 40, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1f, projectile.owner);
					int h = Projectile.NewProjectile(projectile.position.X - 40, projectile.position.Y - 40, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1f, projectile.owner);
				}

				if (Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("SquareBlastBuff")) && !modPlayer.nitro)
				{
					Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 62);
					int a = Projectile.NewProjectile(projectile.position.X + 70, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1f, projectile.owner);
					int b = Projectile.NewProjectile(projectile.position.X - 70, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1f, projectile.owner);
					int c = Projectile.NewProjectile(projectile.position.X, projectile.position.Y + 70, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1f, projectile.owner);
					int d = Projectile.NewProjectile(projectile.position.X, projectile.position.Y - 70, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1f, projectile.owner);
					int e = Projectile.NewProjectile(projectile.position.X + 70, projectile.position.Y + 70, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1f, projectile.owner);
					int f = Projectile.NewProjectile(projectile.position.X - 70, projectile.position.Y + 70, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1f, projectile.owner);
					int g = Projectile.NewProjectile(projectile.position.X + 70, projectile.position.Y - 70, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1f, projectile.owner);
					int h = Projectile.NewProjectile(projectile.position.X - 70, projectile.position.Y - 70, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1f, projectile.owner);
				}

				if (Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("NitroBuff")) && !modPlayer.pyro)
				{
					Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 100);
					int a = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBurst"), projectile.damage, 1f, projectile.owner);
				}

				if (Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("ReinforcedBurstBuff")) && !modPlayer.pyro)
				{
					Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 100);
					int a = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBurst"), projectile.damage, 1f, projectile.owner);
					int b = Projectile.NewProjectile(projectile.position.X + 50, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBurst"), projectile.damage, 1f, projectile.owner);
					int c = Projectile.NewProjectile(projectile.position.X - 50, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBurst"), projectile.damage, 1f, projectile.owner);
				}

				if (Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("LinearBurstBuff")) && !modPlayer.pyro)
				{
					Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 100);
					int a = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBurst"), projectile.damage, 1f, projectile.owner);
					int b = Projectile.NewProjectile(projectile.position.X + 50, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBurst"), projectile.damage, 1f, projectile.owner);
					int c = Projectile.NewProjectile(projectile.position.X - 50, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBurst"), projectile.damage, 1f, projectile.owner);
					int d = Projectile.NewProjectile(projectile.position.X + 100, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBurst"), projectile.damage, 1f, projectile.owner);
					int e = Projectile.NewProjectile(projectile.position.X - 100, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBurst"), projectile.damage, 1f, projectile.owner);
				}

				if (Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("NitroBuff")) && Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("PyroBuff")))
				{
					Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 42);
					int a = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1.5f, projectile.owner);
					Main.projectile[a].scale = 1.5f;
					int b = Projectile.NewProjectile(projectile.position.X + 20, projectile.position.Y, +5, 0, mod.ProjectileType("NovaSkull"), projectile.damage, 1f, projectile.owner);
					int c = Projectile.NewProjectile(projectile.position.X - 20, projectile.position.Y, -5, 0, mod.ProjectileType("NovaSkull"), projectile.damage, 1f, projectile.owner);
				}

				if (Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("ReinforcedBurstBuff")) && Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("PyroBuff")))
				{
					Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 42);
					int a = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1.5f, projectile.owner);
					Main.projectile[a].scale = 1.5f;
					int b = Projectile.NewProjectile(projectile.position.X + 10, projectile.position.Y - 10, +6, 0, mod.ProjectileType("NovaSkull"), projectile.damage, 1f, projectile.owner);
					int c = Projectile.NewProjectile(projectile.position.X - 10, projectile.position.Y - 10, -6, 0, mod.ProjectileType("NovaSkull"), projectile.damage, 1f, projectile.owner);
					int d = Projectile.NewProjectile(projectile.position.X + 40, projectile.position.Y + 10, +4, 0, mod.ProjectileType("NovaSkull"), projectile.damage, 1f, projectile.owner);
					int e = Projectile.NewProjectile(projectile.position.X - 40, projectile.position.Y + 10, -4, 0, mod.ProjectileType("NovaSkull"), projectile.damage, 1f, projectile.owner);
				}

				if (Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("LinearBurstBuff")) && Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("PyroBuff")))
				{
					Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 42);
					int a = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1.5f, projectile.owner);
					Main.projectile[a].scale = 1.5f;
					int b = Projectile.NewProjectile(projectile.position.X + 10, projectile.position.Y - 15, +6, 0, mod.ProjectileType("NovaSkull"), projectile.damage, 1f, projectile.owner);
					int c = Projectile.NewProjectile(projectile.position.X - 10, projectile.position.Y - 15, -6, 0, mod.ProjectileType("NovaSkull"), projectile.damage, 1f, projectile.owner);
					int d = Projectile.NewProjectile(projectile.position.X + 40, projectile.position.Y, +5, 0, mod.ProjectileType("NovaSkull"), projectile.damage, 1f, projectile.owner);
					int e = Projectile.NewProjectile(projectile.position.X - 40, projectile.position.Y, -5, 0, mod.ProjectileType("NovaSkull"), projectile.damage, 1f, projectile.owner);
					int f = Projectile.NewProjectile(projectile.position.X + 70, projectile.position.Y + 15, +4, 0, mod.ProjectileType("NovaSkull"), projectile.damage, 1f, projectile.owner);
					int g = Projectile.NewProjectile(projectile.position.X - 70, projectile.position.Y + 15, -4, 0, mod.ProjectileType("NovaSkull"), projectile.damage, 1f, projectile.owner);
				}

				if (Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("RoundBlastBuff")) && Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("NitroBuff")))
				{
					Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 62);
					int z = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1.5f, projectile.owner);
					Main.projectile[z].scale = 1.25f;
					int a = Projectile.NewProjectile(projectile.position.X + 25, projectile.position.Y, 4, 0, mod.ProjectileType("NovaSkullburst"), projectile.damage * 2, 1f, projectile.owner);
					int b = Projectile.NewProjectile(projectile.position.X - 25, projectile.position.Y, -4, 0, mod.ProjectileType("NovaSkullburst"), projectile.damage * 2, 1f, projectile.owner);
					int c = Projectile.NewProjectile(projectile.position.X, projectile.position.Y + 25, 0, 4, mod.ProjectileType("NovaSkullburst"), projectile.damage * 2, 1f, projectile.owner);
					int d = Projectile.NewProjectile(projectile.position.X, projectile.position.Y - 25, 0, -4, mod.ProjectileType("NovaSkullburst"), projectile.damage * 2, 1f, projectile.owner);
					int e = Projectile.NewProjectile(projectile.position.X + 20, projectile.position.Y + 20, 4, 4, mod.ProjectileType("NovaSkullburst"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[e].scale = 0.8f;
					int f = Projectile.NewProjectile(projectile.position.X - 20, projectile.position.Y + 20, -4, 4, mod.ProjectileType("NovaSkullburst"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[f].scale = 0.8f;
					int g = Projectile.NewProjectile(projectile.position.X + 20, projectile.position.Y - 20, 4, -4, mod.ProjectileType("NovaSkullburst"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[g].scale = 0.8f;
					int h = Projectile.NewProjectile(projectile.position.X - 20, projectile.position.Y - 20, -4, -4, mod.ProjectileType("NovaSkullburst"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[h].scale = 0.8f;
				}


				if (Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("RoundBlastBuff")) && Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("ReinforcedBurstBuff")))
				{
					Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 62);
					int z = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1.5f, projectile.owner);
					Main.projectile[z].scale = 1.25f;
					int a = Projectile.NewProjectile(projectile.position.X + 65, projectile.position.Y, 3, 0, mod.ProjectileType("NovaSkullburst"), projectile.damage * 2, 1f, projectile.owner);
					int b = Projectile.NewProjectile(projectile.position.X - 65, projectile.position.Y, -3, 0, mod.ProjectileType("NovaSkullburst"), projectile.damage * 2, 1f, projectile.owner);
					int c = Projectile.NewProjectile(projectile.position.X, projectile.position.Y + 35, 0, 4, mod.ProjectileType("NovaSkullburst"), projectile.damage * 2, 1f, projectile.owner);
					int d = Projectile.NewProjectile(projectile.position.X, projectile.position.Y - 35, 0, -4, mod.ProjectileType("NovaSkullburst"), projectile.damage * 2, 1f, projectile.owner);
					int e = Projectile.NewProjectile(projectile.position.X + 50, projectile.position.Y + 20, 0, 4, mod.ProjectileType("NovaSkullburst"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[e].scale = 1.2f;
					int f = Projectile.NewProjectile(projectile.position.X - 50, projectile.position.Y + 20, 0, 4, mod.ProjectileType("NovaSkullburst"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[f].scale = 1.2f;
					int g = Projectile.NewProjectile(projectile.position.X + 50, projectile.position.Y - 20, 0, -4, mod.ProjectileType("NovaSkullburst"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[g].scale = 1.2f;
					int h = Projectile.NewProjectile(projectile.position.X - 50, projectile.position.Y - 20, 0, -4, mod.ProjectileType("NovaSkullburst"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[h].scale = 1.2f;
				}

				if (Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("RoundBlastBuff")) && Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("LinearBurstBuff")))
				{
					Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 62);
					int z = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1.5f, projectile.owner);
					Main.projectile[z].scale = 1.25f;
					int a = Projectile.NewProjectile(projectile.position.X + 65, projectile.position.Y, 3, 0, mod.ProjectileType("NovaSkullburst"), projectile.damage * 2, 1f, projectile.owner);
					int b = Projectile.NewProjectile(projectile.position.X - 65, projectile.position.Y, -3, 0, mod.ProjectileType("NovaSkullburst"), projectile.damage * 2, 1f, projectile.owner);
					int c = Projectile.NewProjectile(projectile.position.X, projectile.position.Y + 35, 0, 4, mod.ProjectileType("NovaSkullburst"), projectile.damage * 2, 1f, projectile.owner);
					int d = Projectile.NewProjectile(projectile.position.X, projectile.position.Y - 35, 0, -4, mod.ProjectileType("NovaSkullburst"), projectile.damage * 2, 1f, projectile.owner);
					int e = Projectile.NewProjectile(projectile.position.X + 50, projectile.position.Y + 20, 0, 4, mod.ProjectileType("NovaSkullburst"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[e].scale = 0.8f;
					int f = Projectile.NewProjectile(projectile.position.X - 50, projectile.position.Y + 20, 0, 4, mod.ProjectileType("NovaSkullburst"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[f].scale = 0.8f;
					int g = Projectile.NewProjectile(projectile.position.X + 50, projectile.position.Y - 20, 0, -4, mod.ProjectileType("NovaSkullburst"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[g].scale = 0.8f;
					int h = Projectile.NewProjectile(projectile.position.X - 50, projectile.position.Y - 20, 0, -4, mod.ProjectileType("NovaSkullburst"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[h].scale = 0.8f;
					int i = Projectile.NewProjectile(projectile.position.X + 80, projectile.position.Y + 20, 0, 4, mod.ProjectileType("NovaSkullburst"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[i].scale = 0.6f;
					int k = Projectile.NewProjectile(projectile.position.X - 80, projectile.position.Y + 20, 0, 4, mod.ProjectileType("NovaSkullburst"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[k].scale = 0.6f;
					int l = Projectile.NewProjectile(projectile.position.X + 80, projectile.position.Y - 20, 0, -4, mod.ProjectileType("NovaSkullburst"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[l].scale = 0.6f;
					int m = Projectile.NewProjectile(projectile.position.X - 80, projectile.position.Y - 20, 0, -4, mod.ProjectileType("NovaSkullburst"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[m].scale = 0.6f;
				}

				if (Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("SquareBlastBuff")) && Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("NitroBuff")))
				{
					Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 62);
					int d = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[d].scale = 1.5f;
					int e = Projectile.NewProjectile(projectile.position.X + 30, projectile.position.Y + 30, 3, 3, mod.ProjectileType("NovaSkull"), projectile.damage * 2, 1f, projectile.owner);
					int f = Projectile.NewProjectile(projectile.position.X - 30, projectile.position.Y + 30, -3, 3, mod.ProjectileType("NovaSkull"), projectile.damage * 2, 1f, projectile.owner);
					int g = Projectile.NewProjectile(projectile.position.X + 30, projectile.position.Y - 30, 3, -3, mod.ProjectileType("NovaSkull"), projectile.damage * 2, 1f, projectile.owner);
					int h = Projectile.NewProjectile(projectile.position.X - 30, projectile.position.Y - 30, -3, -3, mod.ProjectileType("NovaSkull"), projectile.damage * 2, 1f, projectile.owner);
				}


				if (Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("SquareBlastBuff")) && Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("ReinforcedBurstBuff")))
				{
					Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 62);
					int d = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[d].scale = 1.5f;
					int e = Projectile.NewProjectile(projectile.position.X + 30, projectile.position.Y + 30, 2, 3, mod.ProjectileType("NovaSkull"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[e].scale = 0.75f;
					int f = Projectile.NewProjectile(projectile.position.X - 30, projectile.position.Y + 30, -2, 3, mod.ProjectileType("NovaSkull"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[f].scale = 0.75f;
					int g = Projectile.NewProjectile(projectile.position.X + 30, projectile.position.Y - 30, 2, -3, mod.ProjectileType("NovaSkull"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[g].scale = 0.75f;
					int h = Projectile.NewProjectile(projectile.position.X - 30, projectile.position.Y - 30, -2, -3, mod.ProjectileType("NovaSkull"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[h].scale = 0.75f;
					int i = Projectile.NewProjectile(projectile.position.X + 30, projectile.position.Y + 30, 3, 2, mod.ProjectileType("NovaSkull"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[i].scale = 0.75f;
					int j = Projectile.NewProjectile(projectile.position.X - 30, projectile.position.Y + 30, -3, 2, mod.ProjectileType("NovaSkull"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[j].scale = 0.75f;
					int k = Projectile.NewProjectile(projectile.position.X + 30, projectile.position.Y - 30, 3, -2, mod.ProjectileType("NovaSkull"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[k].scale = 0.75f;
					int l = Projectile.NewProjectile(projectile.position.X - 30, projectile.position.Y - 30, -3, -2, mod.ProjectileType("NovaSkull"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[l].scale = 0.75f;
				}

				if (Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("SquareBlastBuff")) && Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("LinearBurstBuff")))
				{
					Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 62);
					int d = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("NovaBlast"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[d].scale = 1.5f;
					int e = Projectile.NewProjectile(projectile.position.X + 30, projectile.position.Y + 30, 2, 4, mod.ProjectileType("NovaSkull"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[e].scale = 0.65f;
					int f = Projectile.NewProjectile(projectile.position.X - 30, projectile.position.Y + 30, -2, 4, mod.ProjectileType("NovaSkull"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[f].scale = 0.65f;
					int g = Projectile.NewProjectile(projectile.position.X + 30, projectile.position.Y - 30, 2, -4, mod.ProjectileType("NovaSkull"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[g].scale = 0.65f;
					int h = Projectile.NewProjectile(projectile.position.X - 30, projectile.position.Y - 30, -2, -4, mod.ProjectileType("NovaSkull"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[h].scale = 0.65f;
					int i = Projectile.NewProjectile(projectile.position.X + 30, projectile.position.Y + 30, 4, 2, mod.ProjectileType("NovaSkull"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[i].scale = 0.65f;
					int j = Projectile.NewProjectile(projectile.position.X - 30, projectile.position.Y + 30, -4, 2, mod.ProjectileType("NovaSkull"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[j].scale = 0.65f;
					int k = Projectile.NewProjectile(projectile.position.X + 30, projectile.position.Y - 30, 4, -2, mod.ProjectileType("NovaSkull"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[k].scale = 0.65f;
					int l = Projectile.NewProjectile(projectile.position.X - 30, projectile.position.Y - 30, -4, -2, mod.ProjectileType("NovaSkull"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[l].scale = 0.65f;
					int m = Projectile.NewProjectile(projectile.position.X + 30, projectile.position.Y + 30, 3, 3, mod.ProjectileType("NovaSkull"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[m].scale = 0.7f;
					int n = Projectile.NewProjectile(projectile.position.X - 30, projectile.position.Y + 30, -3, 3, mod.ProjectileType("NovaSkull"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[n].scale = 0.7f;
					int o = Projectile.NewProjectile(projectile.position.X + 30, projectile.position.Y - 30, 3, -3, mod.ProjectileType("NovaSkull"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[o].scale = 0.7f;
					int p = Projectile.NewProjectile(projectile.position.X - 30, projectile.position.Y - 30, -3, -3, mod.ProjectileType("NovaSkull"), projectile.damage * 2, 1f, projectile.owner);
					Main.projectile[p].scale = 0.7f;
				}

				if (Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("NitroBuff")) && Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("ChemikazeBuff")))
				{
					Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 100);
					Projectile.NewProjectile(projectile.position.X - 30, projectile.position.Y, -2, 0, mod.ProjectileType("NovaBurst"), projectile.damage, 1f, projectile.owner);
					Projectile.NewProjectile(projectile.position.X + 30, projectile.position.Y, +2, 0, mod.ProjectileType("NovaBurst"), projectile.damage, 1f, projectile.owner);
				}

				if (Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("ReinforcedBurstBuff")) && Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("ChemikazeBuff")))
				{
					Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 100);
					Projectile.NewProjectile(projectile.position.X - 40, projectile.position.Y, -2, 0, mod.ProjectileType("NovaBurst"), projectile.damage, 1f, projectile.owner);
					Projectile.NewProjectile(projectile.position.X + 40, projectile.position.Y, +2, 0, mod.ProjectileType("NovaBurst"), projectile.damage, 1f, projectile.owner);
					Projectile.NewProjectile(projectile.position.X - 60, projectile.position.Y, -3, 0, mod.ProjectileType("NovaBurst"), projectile.damage, 1f, projectile.owner);
					Projectile.NewProjectile(projectile.position.X + 60, projectile.position.Y, +3, 0, mod.ProjectileType("NovaBurst"), projectile.damage, 1f, projectile.owner);
				}

				if (Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("LinearBurstBuff")) && Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("ChemikazeBuff")))
				{
					Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 100);
					Projectile.NewProjectile(projectile.position.X - 40, projectile.position.Y, -2, 0, mod.ProjectileType("NovaBurst"), projectile.damage, 1f, projectile.owner);
					Projectile.NewProjectile(projectile.position.X + 40, projectile.position.Y, +2, 0, mod.ProjectileType("NovaBurst"), projectile.damage, 1f, projectile.owner);
					Projectile.NewProjectile(projectile.position.X - 60, projectile.position.Y, -3, 0, mod.ProjectileType("NovaBurst"), projectile.damage, 1f, projectile.owner);
					Projectile.NewProjectile(projectile.position.X + 60, projectile.position.Y, +3, 0, mod.ProjectileType("NovaBurst"), projectile.damage, 1f, projectile.owner);
					Projectile.NewProjectile(projectile.position.X - 80, projectile.position.Y, -4, 0, mod.ProjectileType("NovaBurst"), projectile.damage, 1f, projectile.owner);
					Projectile.NewProjectile(projectile.position.X + 80, projectile.position.Y, +4, 0, mod.ProjectileType("NovaBurst"), projectile.damage, 1f, projectile.owner);
				}

				if (Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("CrossBlastBuff")) && Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("NitroBuff")))
				{
					Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 62);
					int a = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 4, 0, mod.ProjectileType("NovaSkullburst"), projectile.damage * 1, 1f, projectile.owner);
					int b = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -4, 0, mod.ProjectileType("NovaSkullburst"), projectile.damage * 1, 1f, projectile.owner);
					int c = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 4, mod.ProjectileType("NovaSkullburst"), projectile.damage * 1, 1f, projectile.owner);
					int d = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, -4, mod.ProjectileType("NovaSkullburst"), projectile.damage * 1, 1f, projectile.owner);
					int e = Projectile.NewProjectile(projectile.position.X + 60, projectile.position.Y, -4, 0, mod.ProjectileType("NovaSkullburst"), projectile.damage * 1, 1f, projectile.owner);
					int f = Projectile.NewProjectile(projectile.position.X - 60, projectile.position.Y, 4, 0, mod.ProjectileType("NovaSkullburst"), projectile.damage * 1, 1f, projectile.owner);
					int g = Projectile.NewProjectile(projectile.position.X, projectile.position.Y + 60, 0, -4, mod.ProjectileType("NovaSkullburst"), projectile.damage * 1, 1f, projectile.owner);
					int h = Projectile.NewProjectile(projectile.position.X, projectile.position.Y - 60, 0, 4, mod.ProjectileType("NovaSkullburst"), projectile.damage * 1, 1f, projectile.owner);
				}

				if (Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("CrossBlastBuff")) && Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("ReinforcedBurstBuff")))
				{
					Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 62);
					int a = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 6, 0, mod.ProjectileType("NovaSkullburst"), projectile.damage * 1, 1f, projectile.owner);
					int b = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -6, 0, mod.ProjectileType("NovaSkullburst"), projectile.damage * 1, 1f, projectile.owner);
					int c = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 6, mod.ProjectileType("NovaSkullburst"), projectile.damage * 1, 1f, projectile.owner);
					int d = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, -6, mod.ProjectileType("NovaSkullburst"), projectile.damage * 1, 1f, projectile.owner);
					int e = Projectile.NewProjectile(projectile.position.X + 60, projectile.position.Y, -6, 0, mod.ProjectileType("NovaSkullburst"), projectile.damage * 1, 1f, projectile.owner);
					int f = Projectile.NewProjectile(projectile.position.X - 60, projectile.position.Y, 6, 0, mod.ProjectileType("NovaSkullburst"), projectile.damage * 1, 1f, projectile.owner);
					int g = Projectile.NewProjectile(projectile.position.X, projectile.position.Y + 60, 0, -6, mod.ProjectileType("NovaSkullburst"), projectile.damage * 1, 1f, projectile.owner);
					int h = Projectile.NewProjectile(projectile.position.X, projectile.position.Y - 60, 0, 6, mod.ProjectileType("NovaSkullburst"), projectile.damage * 1, 1f, projectile.owner);
				}

				if (Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("CrossBlastBuff")) && Main.player[Main.myPlayer].buffType.Contains(mod.BuffType("LinearBurstBuff")))
				{
					Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 62);
					int a = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 8, 0, mod.ProjectileType("NovaSkullburst"), projectile.damage * 1, 1f, projectile.owner);
					int b = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -8, 0, mod.ProjectileType("NovaSkullburst"), projectile.damage * 1, 1f, projectile.owner);
					int c = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 8, mod.ProjectileType("NovaSkullburst"), projectile.damage * 1, 1f, projectile.owner);
					int d = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, -8, mod.ProjectileType("NovaSkullburst"), projectile.damage * 1, 1f, projectile.owner);
					int e = Projectile.NewProjectile(projectile.position.X + 60, projectile.position.Y, -8, 0, mod.ProjectileType("NovaSkullburst"), projectile.damage * 1, 1f, projectile.owner);
					int f = Projectile.NewProjectile(projectile.position.X - 60, projectile.position.Y, 8, 0, mod.ProjectileType("NovaSkullburst"), projectile.damage * 1, 1f, projectile.owner);
					int g = Projectile.NewProjectile(projectile.position.X, projectile.position.Y + 60, 0, -8, mod.ProjectileType("NovaSkullburst"), projectile.damage * 1, 1f, projectile.owner);
					int h = Projectile.NewProjectile(projectile.position.X, projectile.position.Y - 60, 0, 8, mod.ProjectileType("NovaSkullburst"), projectile.damage * 1, 1f, projectile.owner);
				}
			}
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.Kill();
		}

		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			damage = 0;
		}
	}
}