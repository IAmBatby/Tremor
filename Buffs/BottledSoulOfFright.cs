using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class BottledSoulOfFright : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.SetDefault("Bottled Soul of Fright");
			Description.SetDefault("Increases critical strike chance by 2");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.rangedCrit += 2;
			player.meleeCrit += 2;
			player.magicCrit += 2;
			player.thrownCrit += 2;
		}
	}
}
