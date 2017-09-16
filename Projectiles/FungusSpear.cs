using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class FungusSpear : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(66);

			aiType = 66;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("FungusSpear");

		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(4) == 0)
			{
				target.AddBuff(31, 120, false);
			}
		}

	}
}
