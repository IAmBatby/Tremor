using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class TheGhostClaymore : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 325;
			item.width = 50;
			item.height = 50;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 750000;
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("TheGhostClaymorePro");
			item.shootSpeed = 16f;
			item.melee = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Ghost Claymore");
			Tooltip.SetDefault("");
		}

	}
}
