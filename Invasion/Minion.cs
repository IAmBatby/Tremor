using Terraria.ModLoader;

namespace Tremor.Invasion
{
	public abstract class Minion : ModProjectile
	{
		public override void AI()
		{
			CheckActive();
		}

		public abstract void CheckActive();

	}
}