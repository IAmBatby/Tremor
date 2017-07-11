using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class WolfToothNecklace : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 30;

			item.useTime = 20;
			item.useAnimation = 20;
			item.pick = 220;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 30000;
			item.rare = 2;
			item.UseSound = SoundID.Item79;
			item.noMelee = true;
			item.mountType = mod.MountType("Wolf");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wolf Tooth Necklace");
			Tooltip.SetDefault("This is a modded mount.");
		}

	}
}
