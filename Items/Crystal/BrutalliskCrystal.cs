using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Crystal
{
	public class BrutalliskCrystal : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Aquamarine Crystal");
			Tooltip.SetDefault("Summons a rideable aquamarine crystal mount");
		}

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 26;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 4;
			item.value = 50000;
			item.rare = 11;
			item.expert = true;
			item.UseSound = SoundID.Item44;
			item.noMelee = true;
			item.mountType = mod.MountType("BrutalliskCrystal");
		}
	}
}