using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class TremorProjectiles : GlobalProjectile
	{

		public override void SetDefaults(Projectile projectile)
		{
			if (Main.gameMenu) return;

			if (projectile.minion && Main.player[Main.myPlayer].active && Main.player[Main.myPlayer].FindBuffIndex(mod.BuffType("ZephyrhornBuff")) != -1)
			{
				projectile.scale = 1.5f;
				projectile.width *= (int)1.5f;
				projectile.height *= (int)1.5f;
			}

			if ((projectile.type != mod.ProjectileType("SparkingCloudPro") || projectile.type != mod.ProjectileType("AlchemasterPoisonCloudPro")) && (projectile.aiStyle == 92 || projectile.type == mod.ProjectileType("PurpleBurst") || projectile.type == mod.ProjectileType("PurpleSkull") || projectile.type == mod.ProjectileType("PurpleSkullburst") || projectile.type == mod.ProjectileType("ShadowBurst") || projectile.type == mod.ProjectileType("ShadowSkull") || projectile.type == mod.ProjectileType("ShadowSkullburst") || projectile.type == mod.ProjectileType("ManaSkull") || projectile.type == mod.ProjectileType("ManaSkullburst") || projectile.type == mod.ProjectileType("MoonBurst") || projectile.type == mod.ProjectileType("MoonSkull") || projectile.type == mod.ProjectileType("MoonSkullburst") || projectile.type == mod.ProjectileType("PoisonBurst") || projectile.type == mod.ProjectileType("PoisonSkull") || projectile.type == mod.ProjectileType("PoisonSkullburst") || projectile.type == mod.ProjectileType("HealingSkullburst") || projectile.type == mod.ProjectileType("HealingSkull") || projectile.type == mod.ProjectileType("HealingSkullburst") || projectile.type == mod.ProjectileType("ManaBurst") || projectile.type == mod.ProjectileType("GoldenBurst") || projectile.type == mod.ProjectileType("GoldenSkull") || projectile.type == mod.ProjectileType("GoldenSkullburst") || projectile.type == mod.ProjectileType("HealingBurst") || projectile.type == mod.ProjectileType("FierySkullburst") || projectile.type == mod.ProjectileType("FrostBurst") || projectile.type == mod.ProjectileType("FrostSkull") || projectile.type == mod.ProjectileType("FrostSkullburst") || projectile.type == mod.ProjectileType("BasicBurst") || projectile.type == mod.ProjectileType("BasicSkull") || projectile.type == mod.ProjectileType("BasicSkullburst") || projectile.type == mod.ProjectileType("BoomBurst") || projectile.type == mod.ProjectileType("BoomSkull") || projectile.type == mod.ProjectileType("BoomSkullburst") || projectile.type == mod.ProjectileType("ClusterBurst") || projectile.type == mod.ProjectileType("ClusterSkull") || projectile.type == mod.ProjectileType("ClusterSkullburst") || projectile.type == mod.ProjectileType("CrystalBurst") || projectile.type == mod.ProjectileType("CrystalSkull") || projectile.type == mod.ProjectileType("FieryBurst") || projectile.type == mod.ProjectileType("CrystalSkull") || projectile.type == mod.ProjectileType("FierySkull") || projectile.type == mod.ProjectileType("BoomBlast") || projectile.type == mod.ProjectileType("CrystalBlast") || projectile.type == mod.ProjectileType("FieryBlast") || projectile.type == mod.ProjectileType("FrostBlast") || projectile.type == mod.ProjectileType("GoldenBlast") || projectile.type == mod.ProjectileType("HealingBlast") || projectile.type == mod.ProjectileType("ManaBlast") || projectile.type == mod.ProjectileType("MoonBlast") || projectile.type == mod.ProjectileType("PlagueBlast") || projectile.type == mod.ProjectileType("PoisonBlast") || projectile.type == mod.ProjectileType("PurpleBlast") || projectile.type == mod.ProjectileType("ShadowBlast") || projectile.type == mod.ProjectileType("SparkingBlast") || projectile.type == mod.ProjectileType("SparkingBallz")) && Main.player[Main.myPlayer].active && Main.player[Main.myPlayer].FindBuffIndex(mod.BuffType("FlaskExpansionBuff")) != -1)
			{
				projectile.scale = 1.2f;
				projectile.width *= (int)1.2f;
				projectile.height *= (int)1.2f;
			}
		}

		public override void AI(Projectile projectile)
		{
			if (projectile.aiStyle == 88 && projectile.knockBack == .5f || (projectile.knockBack >= .2f && projectile.knockBack < .5f))
			{
				projectile.hostile = false;
				projectile.friendly = true;
				projectile.magic = true;
				projectile.penetrate = -1;
				if ((projectile.knockBack >= .45f && projectile.knockBack < .5f) && projectile.oldVelocity != projectile.velocity && Main.rand.Next(0, 4) == 0)
				{
					projectile.knockBack -= .0125f;
					Vector2 vector83 = projectile.velocity.RotatedByRandom(.1f);
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector83.X, vector83.Y, projectile.type, projectile.damage, projectile.knockBack - .025f, projectile.owner, projectile.velocity.ToRotation(), projectile.ai[1]);
				}
			}
		}

		public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
		{
			if (projectile.aiStyle == 88 && (projectile.knockBack >= .2f && projectile.knockBack <= .5f))
			{
				target.immune[projectile.owner] = 6;
			}

			if ((projectile.type != mod.ProjectileType("SparkingCloudPro") || projectile.type != mod.ProjectileType("AlchemasterPoisonCloudPro")) && (projectile.aiStyle == 92 || projectile.type == mod.ProjectileType("PurpleBurst") || projectile.type == mod.ProjectileType("PurpleSkull") || projectile.type == mod.ProjectileType("PurpleSkullburst") || projectile.type == mod.ProjectileType("ShadowBurst") || projectile.type == mod.ProjectileType("ShadowSkull") || projectile.type == mod.ProjectileType("ShadowSkullburst") || projectile.type == mod.ProjectileType("ManaSkull") || projectile.type == mod.ProjectileType("ManaSkullburst") || projectile.type == mod.ProjectileType("MoonBurst") || projectile.type == mod.ProjectileType("MoonSkull") || projectile.type == mod.ProjectileType("MoonSkullburst") || projectile.type == mod.ProjectileType("PoisonBurst") || projectile.type == mod.ProjectileType("PoisonSkull") || projectile.type == mod.ProjectileType("PoisonSkullburst") || projectile.type == mod.ProjectileType("HealingSkullburst") || projectile.type == mod.ProjectileType("HealingSkull") || projectile.type == mod.ProjectileType("HealingSkullburst") || projectile.type == mod.ProjectileType("ManaBurst") || projectile.type == mod.ProjectileType("GoldenBurst") || projectile.type == mod.ProjectileType("GoldenSkull") || projectile.type == mod.ProjectileType("GoldenSkullburst") || projectile.type == mod.ProjectileType("HealingBurst") || projectile.type == mod.ProjectileType("FierySkullburst") || projectile.type == mod.ProjectileType("FrostBurst") || projectile.type == mod.ProjectileType("FrostSkull") || projectile.type == mod.ProjectileType("FrostSkullburst") || projectile.type == mod.ProjectileType("BasicBurst") || projectile.type == mod.ProjectileType("BasicSkull") || projectile.type == mod.ProjectileType("BasicSkullburst") || projectile.type == mod.ProjectileType("BoomBurst") || projectile.type == mod.ProjectileType("BoomSkull") || projectile.type == mod.ProjectileType("BoomSkullburst") || projectile.type == mod.ProjectileType("ClusterBurst") || projectile.type == mod.ProjectileType("ClusterSkull") || projectile.type == mod.ProjectileType("ClusterSkullburst") || projectile.type == mod.ProjectileType("CrystalBurst") || projectile.type == mod.ProjectileType("CrystalSkull") || projectile.type == mod.ProjectileType("FieryBurst") || projectile.type == mod.ProjectileType("CrystalSkull") || projectile.type == mod.ProjectileType("FierySkull") || projectile.type == mod.ProjectileType("BoomBlast") || projectile.type == mod.ProjectileType("CrystalBlast") || projectile.type == mod.ProjectileType("FieryBlast") || projectile.type == mod.ProjectileType("FrostBlast") || projectile.type == mod.ProjectileType("GoldenBlast") || projectile.type == mod.ProjectileType("HealingBlast") || projectile.type == mod.ProjectileType("ManaBlast") || projectile.type == mod.ProjectileType("MoonBlast") || projectile.type == mod.ProjectileType("PlagueBlast") || projectile.type == mod.ProjectileType("PoisonBlast") || projectile.type == mod.ProjectileType("PurpleBlast") || projectile.type == mod.ProjectileType("ShadowBlast") || projectile.type == mod.ProjectileType("SparkingBlast") || projectile.type == mod.ProjectileType("SparkingBallz")) && Main.player[Main.myPlayer].active && Main.player[Main.myPlayer].FindBuffIndex(mod.BuffType("CursedCloudBuff")) != -1)
			{
				target.AddBuff(31, 360, false);
			}
		}
		public override bool? CanHitNPC(Projectile projectile, NPC target)
		{
			if (projectile.aiStyle == 88 && ((projectile.knockBack == .5f || projectile.knockBack == .4f) || (projectile.knockBack >= .4f && projectile.knockBack < .5f)) && target.immune[projectile.owner] > 0)
			{
				return false;
			}
			return null;
		}

	}
}


