using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class SharkToothSword : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 18;
			item.melee = true;
			item.width = 48;
			item.height = 48;
			item.useTime = 35;
			item.useAnimation = 35;
			item.useStyle = 1;
			item.knockBack = 7;
			item.value = 2740;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shark Tooth Sword");
			Tooltip.SetDefault("");
		}

	}
}
