using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class RoyalClaymore : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 8;
			item.melee = true;
			item.width = 56;
			item.height = 56;
			item.useTime = 22;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 35400;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Royal Claymore");
			Tooltip.SetDefault("");
		}

	}
}
