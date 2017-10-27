using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class KeyKnife : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 26;
			item.melee = true;
			item.width = 50;
			item.height = 50;
			item.scale = 1.3f;
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = 1;
			item.knockBack = 2;

			item.value = 150000;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Key Knife");
			Tooltip.SetDefault("'Half key, half knife, completely awe.. oh.'");
		}

	}
}
