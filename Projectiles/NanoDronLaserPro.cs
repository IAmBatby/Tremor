using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles
{
	public class NanoDronLaserPro : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(435);

			aiType = 435;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nano Dron Laser");

		}

		public override bool CanHitPlayer(Player target)
		{
			return false;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override bool? CanHitNPC(NPC target)
		{
			return (target.friendly) ? false : true;
		}
	}
}
