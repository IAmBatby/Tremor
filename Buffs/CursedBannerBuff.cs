using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class CursedBannerBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("The Cursed Banner");
			Description.SetDefault("Increases all critical strike chance by 25");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.meleeCrit += 25;
			player.rangedCrit += 25;
			player.magicCrit += 25;
			player.thrownCrit += 25;
			player.GetModPlayer<MPlayer>(mod).alchemicalCrit += 25;
		}
	}
}