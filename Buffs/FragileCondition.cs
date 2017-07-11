using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class FragileCondition : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Fragile Condition");
			Description.SetDefault("All damage is increased by three times, reduces defense to zero");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.statDefense = 0;
			player.magicDamage *= 3f;
			player.minionDamage *= 3f;
			player.meleeDamage *= 3f;
			player.rangedDamage *= 3f;
			player.thrownDamage *= 3f;
			player.GetModPlayer<MPlayer>(mod).alchemistDamage *= 3f;
		}
	}
}
