using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class GarnetGlovePro : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.CloneDefaults(303);
			projectile.width = 28;
			projectile.height = 38;
			aiType = 303;
			projectile.timeLeft = 400;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("GarnetGlovePro");

		}

		public override bool CanHitPlayer(Player target)
		{
			return false;
		}

		public override bool? CanHitNPC(NPC target)
		{
			return (target.friendly) ? false : true;
		}

	}
}
