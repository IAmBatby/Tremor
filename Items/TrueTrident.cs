using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class TrueTrident : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 43;
			item.width = 50;
			item.height = 50;
			item.noUseGraphic = true;
			item.melee = true;
			item.useTime = 30;
			item.shoot = mod.ProjectileType("TrueTridentProjectile");
			item.shootSpeed = 3f;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.knockBack = 15;
			item.value = 40000;
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Trident");
			Tooltip.SetDefault("");
		}

	}
}
