using Terraria.ModLoader;

namespace Tremor
{
	public class Tremor : Mod
	{
		internal static Tremor instance;

		public Tremor()
		{
			Properties = ModProperties.AutoLoadAll;
		}

		public override void Load()
		{
			instance = this;
		}

		public override void Unload()
		{
			TremorUtils.NullStaticFields(this);
		}
	}
}