using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class ExtendedManaBooster : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Extended Mana Booster");
			Description.SetDefault("Regenerates 200 mana every 45 seconds");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (player.buffTime[buffIndex] == 0)
			{
				player.statMana += 200;
				player.ManaEffect(200);
				player.AddBuff(mod.BuffType("ExtendedManaBooster"), 2700);
			}
		}
	}
}