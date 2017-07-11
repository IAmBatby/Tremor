using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class ChaosElementBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Chaos Element");
			Description.SetDefault("Flasks summon crystal splinters that heal you when hit enemy");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}