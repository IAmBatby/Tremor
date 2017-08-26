using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class FragileCondition : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Fragile Condition");
			Description.SetDefault("You deal three times more damage, but your defense is reduced to zero.");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.magicDamage *= 3f;
			player.minionDamage *= 3f;
			player.meleeDamage *= 3f;
			player.rangedDamage *= 3f;
			player.thrownDamage *= 3f;
			MPlayer.GetModPlayer(player).alchemicalDamage *= 3f;
			MPlayer.GetModPlayer(player).fragileContiion = true; // Handles defense reset
		}
	}
}
