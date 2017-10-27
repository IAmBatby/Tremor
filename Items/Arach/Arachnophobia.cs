using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Arach
{
	public class Arachnophobia : ModItem
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
			item.shoot = 378;
			item.shootSpeed = 14f;
			item.value = 12500;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Arachnophobia");
			Tooltip.SetDefault("");
		}

	}
}
