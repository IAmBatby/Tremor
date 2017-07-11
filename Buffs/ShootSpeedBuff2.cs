using Terraria;
using Terraria.ModLoader;

namespace Tremor.Buffs
{
	public class ShootSpeedBuff2 : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Paratrooper's Lens");
			Description.SetDefault("Increased projectile's speed twice");
			Main.buffNoTimeDisplay[Type] = true;
		}
	}
}
