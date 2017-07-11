using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class BottledSoulOfMight : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.SetDefault("Bottled Soul of Might");
			Description.SetDefault("5% increased damage");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.meleeDamage += 0.05f;
			player.rangedDamage += 0.05f;
			player.thrownDamage += 0.05f;
			player.minionDamage += 0.05f;
			player.magicDamage += 0.05f;
		}
	}
}
