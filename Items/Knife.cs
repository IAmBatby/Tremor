using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Knife : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 18;
			item.melee = true;
			item.width = 42;
			item.height = 42;
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Knife");
			Tooltip.SetDefault("");
		}

	}
}
