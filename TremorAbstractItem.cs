using Terraria.ModLoader;

namespace Tremor
{
	public abstract class TremorAbstractItem : ModItem
	{
		protected abstract void Defaults();

		protected abstract void StaticDefaults();

		public virtual void SafeDefaults()
		{

		}

		public virtual void SafeStaticDefaults()
		{

		}

		public sealed override void SetDefaults()
		{
			Defaults();
			SafeDefaults();
		}

		public sealed override void SetStaticDefaults()
		{
			StaticDefaults();
			SafeStaticDefaults();
		}
	}
}
