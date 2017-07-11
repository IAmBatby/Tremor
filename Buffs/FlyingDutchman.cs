using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class FlyingDutchman : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.SetDefault("Flying Dutchman");
			Description.SetDefault("Flies like a butterfly!");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(mod.MountType("FlyingDutchman"), player);
			player.buffTime[buffIndex] = 10;
		}
	}
}
