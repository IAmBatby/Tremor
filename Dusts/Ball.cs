using Terraria;
using Terraria.ModLoader;

namespace Tremor.Dusts
{
	public class Ball : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.velocity.Y = Main.rand.Next(-10, 10) * 0.1f;
			dust.velocity.X *= 0.3f;
			dust.scale *= 0.7f;
		}

		public override bool MidUpdate(Dust dust)
		{
			if (!dust.noGravity)
			{
				dust.velocity.Y += 0.05f;
			}
			return true;
		}
	}
}