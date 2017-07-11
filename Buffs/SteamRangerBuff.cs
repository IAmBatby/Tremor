using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class SteamRangerBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Brass Ranged Enchanting");
			Description.SetDefault("Increases Brass Chain Repeater damage");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}