using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class FlaskCoreBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Flask Core");
			Description.SetDefault("Flasks now have autoreuse");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MPlayer.GetModPlayer(player).core = true;
		}
	}
}