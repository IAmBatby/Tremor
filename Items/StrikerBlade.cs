using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class StrikerBlade : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 54;
			item.melee = true;
			item.width = 36;
			item.height = 44;
			item.useTime = 11;
			item.useAnimation = 11;
			item.useStyle = 1;
			item.useTurn = true;
			item.knockBack = 6f;
			item.value = 90000;
			item.rare = 7;
			item.UseSound = SoundID.Item71;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Striker Blade");
			Tooltip.SetDefault("");
		}

	}
}
