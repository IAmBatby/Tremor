using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class Antlion : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.SetDefault("Antlion");
			Description.SetDefault("It likes your sugar");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(mod.MountType("Antlion"), player);
			player.buffTime[buffIndex] = 10;
		}
	}
}
