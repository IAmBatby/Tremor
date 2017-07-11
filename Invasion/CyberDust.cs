using Terraria;
using Terraria.ModLoader;

namespace Tremor.Invasion
{
	public class CyberDust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
		}

		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X;
			dust.scale -= 0.01f;
			Lighting.AddLight(dust.position, 0.0f, 1.27f, 0.64f);
			if (dust.scale < 0.5f)
			{
				dust.active = false;
			}
			return false;
		}
	}
}