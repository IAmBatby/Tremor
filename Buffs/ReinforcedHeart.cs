using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class ReinforcedHeart : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.SetDefault("Reinforced Heart");
			Description.SetDefault("Increases maximum health");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.statLifeMax2 += 100;
		}
	}
}
