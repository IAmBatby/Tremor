using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class TatteredBannerBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("The Tattered Banner");
			Description.SetDefault("25% increased damage");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.meleeDamage += 0.25f;
			player.rangedDamage += 0.25f;
			player.minionDamage += 0.25f;
			player.magicDamage += 0.25f;
			player.thrownDamage += 0.25f;
			player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.25f;
		}
	}
}