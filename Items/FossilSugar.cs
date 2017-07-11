using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class FossilSugar : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 28;
			item.height = 30;

			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 30000;
			item.rare = 2;
			item.UseSound = SoundID.Item79;
			item.noMelee = true;
			item.mountType = mod.MountType("Antlion");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fossil Sugar");
			Tooltip.SetDefault("Summons a rideable Antlion mount");
		}

	}
}
