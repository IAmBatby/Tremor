using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Projectiles.Minions
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