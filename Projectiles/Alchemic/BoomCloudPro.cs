using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles.Alchemic
{
	public class BoomCloudPro : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 40;
			projectile.height = 40;
			projectile.magic = true;
			projectile.penetrate = 8;
			projectile.aiStyle = 92;
			projectile.friendly = true;
			projectile.timeLeft = 600;
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
			projectile.rotation = 0f;
		}

	}
}