using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class CornSword : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 22;
			item.melee = true;
			item.width = 46;
			item.height = 46;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 1000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Corn Sword");
			Tooltip.SetDefault("");
		}

	}
}
