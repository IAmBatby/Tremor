using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class SteamMageBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Brass Magic Enchanting");
			Description.SetDefault("Increases Brass Stave damage");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}