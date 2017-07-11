using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class CactusBow : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 14;
			item.width = 16;
			item.height = 32;
			item.ranged = true;
			item.useTime = 40;
			item.shoot = 1;
			item.shootSpeed = 10f;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.knockBack = 5;
			item.value = 2040;
			item.useAmmo = AmmoID.Arrow;
			item.rare = 2;
			item.UseSound = SoundID.Item5;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cactus Bow");
			Tooltip.SetDefault("");
		}

	}
}
