using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class BigBottledSpirit : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Big Bottled Spirit");
			Description.SetDefault("Shoots four homing souls when using a flask");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}