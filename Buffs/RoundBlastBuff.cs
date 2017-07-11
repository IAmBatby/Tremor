using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class RoundBlastBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Round Blast");
			Description.SetDefault("Alchemical projectiles leave explosions in the shape of round");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}