using Terraria;
using Terraria.ModLoader;

namespace Tremor.Ice
{
	public class IceDust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
		}
	}
}