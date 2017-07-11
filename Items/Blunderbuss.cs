using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Blunderbuss : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 32;
			item.ranged = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 40;
			item.useAnimation = 40;
			item.shoot = 14;
			item.shootSpeed = 8f;
			item.useAmmo = AmmoID.Bullet;
			item.useStyle = 5;
			item.knockBack = 4;
			item.value = 60000;
			item.rare = 5;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blunderbuss");
			Tooltip.SetDefault("");
		}

	}
}
