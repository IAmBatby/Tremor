using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Items
{
	public class IchorCleaverPro : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(595);
			projectile.width = 100;
			projectile.height = 70;
			aiType = 595;
			Main.projFrames[projectile.type] = 28;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextBool(6))
			{
				target.AddBuff(69, 500, false);
			}
		}

		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			if (Main.rand.NextBool(6))
			{
				target.AddBuff(69, 500, false);
			}
		}
	}
}
