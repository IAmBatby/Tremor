using Terraria;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Items
{
	public class DreadLancePro : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(66);
			aiType = 66;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextBool())
			{
				target.AddBuff(39, 180, false);
			}
		}
	}
}
