using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Chain
{
	public class Chainsword : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 55;
			item.melee = true;
			item.width = 56;
			item.height = 64;
			item.useTime = 25;
			item.useAnimation = 25;
			item.axe = 22;

			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 60000;
			item.rare = 5;
			item.UseSound = SoundID.Item22;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chainsword");
			Tooltip.SetDefault("'It looks like a sword, but its actually a saw! Buy yours today!'");
		}

	}
}
