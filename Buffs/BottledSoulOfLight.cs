using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class BottledSoulOfLight : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.SetDefault("Bottled Soul of Light");
			Description.SetDefault("20% increased movement speed");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.moveSpeed += 0.2f;
		}
	}
}
