using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Dusts
{
	public class EtherFlame : ModDust
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
			if (!dust.noLight)
			{
				float strength = dust.scale * 1.8f;
				if (strength > 1f)
				{
					strength = 1f;
				}
				Lighting.AddLight(dust.position, 0.3f * strength, 0.3f * strength, 0.3f * strength);
			}
			return true;
		}

		public override Color? GetAlpha(Dust dust, Color lightColor)
		{
			return new Color(lightColor.R, lightColor.G, lightColor.B, 75);
		}
	}
}