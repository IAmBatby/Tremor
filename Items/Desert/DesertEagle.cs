using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Desert
{
	public class DesertEagle : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 56;
			item.ranged = true;
			item.width = 52;
			item.height = 34;
			item.useTime = 30;
			item.useAnimation = 30;
			item.shoot = 14;
			item.shootSpeed = 15f;
			item.useAmmo = AmmoID.Bullet;
			item.useStyle = 5;
			item.knockBack = 4;
			item.value = 150000;
			item.rare = 5;
			item.UseSound = SoundID.Item11;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Desert Eagle");
			Tooltip.SetDefault("");
		}

	}
}
