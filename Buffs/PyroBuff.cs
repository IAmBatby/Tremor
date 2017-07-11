using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class PyroBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("The Pyro");
			Description.SetDefault("Alchemical projectiles leave an explosion instead of clouds");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}