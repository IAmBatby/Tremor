using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class EyeofInfinity : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 68;
			item.melee = true;
			item.width = 42;
			item.height = 42;
			item.useTime = 16;
			item.useAnimation = 16;
			item.noMelee = true;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = Item.buyPrice(0, 1, 50, 0);
			item.rare = 8;
			item.UseSound = SoundID.Item23;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("projEyeofInfinity");
			item.shootSpeed = 15f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eye of Infinity");
			Tooltip.SetDefault("");
		}

	}
}
