using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class CornHeater : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 20;
			item.ranged = true;
			item.width = 58;
			item.height = 26;
			item.useTime = 15;
			item.useAnimation = 15;
			item.shoot = mod.ProjectileType("PopcornAmmo");
			item.shootSpeed = 8f;
			item.useStyle = 5;
			item.knockBack = 4;
			item.useAmmo = mod.ItemType("PopcornAmmo");
			item.value = 60000;
			item.rare = 9;
			item.expert = true;
			item.UseSound = SoundID.Item11;

			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Corn Heater");
			Tooltip.SetDefault("Uses popcorn as ammo");
		}

	}
}
