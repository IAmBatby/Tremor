using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Tremor.Dusts
{
	public class SoulofTruthDust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
			dust.frame = new Rectangle(0, 0, 10, 10);
		}

		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X;
			dust.scale -= 0.01f;
			Lighting.AddLight(dust.position, 1.0f, 1.0f, 0.0f);
			if (dust.scale < 0.5f)
			{
				dust.active = false;
			}
			return false;
		}
	}
}