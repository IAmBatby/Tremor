using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class GreenClaw : ModItem
	{
		public override void SetDefaults()
		{

			item.useStyle = 3;
			item.useTurn = false;
			item.useAnimation = 12;
			item.useTime = 12;
			item.width = 24;
			item.height = 28;
			item.damage = 19;
			item.knockBack = 4f;
			item.scale = 0.9f;
			item.UseSound = SoundID.Item1;
			item.useTurn = true;
			item.value = 8400;
			item.melee = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Green Claw");
			Tooltip.SetDefault("");
		}

	}
}
