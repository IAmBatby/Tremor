using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Eggplant : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 30;
			item.melee = true;
			item.width = 48;
			item.height = 48;
			item.useTime = 50;
			item.useAnimation = 50;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 9500;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eggplant");
			Tooltip.SetDefault("");
		}

	}
}
