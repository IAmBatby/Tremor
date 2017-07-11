using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class ChemikazeBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("The Chemikaze");
			Description.SetDefault("Alchemical projectiles leave five explosions");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}