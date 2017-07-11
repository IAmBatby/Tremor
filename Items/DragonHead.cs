using Terraria.ID;
using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class DragonHead : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 10;
			item.rare = 2;
			item.noMelee = true;
			item.useStyle = 5;
			item.useAnimation = 40;
			item.useTime = 40;
			item.knockBack = 7.5F;
			item.damage = 19;
			item.scale = 1.1F;
			item.noUseGraphic = true;
			item.shoot = mod.ProjectileType("DragonHead");
			item.shootSpeed = 13f;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.channel = true;
			item.value = 30000;

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dragon Head");
			Tooltip.SetDefault("Has 33% chance to spawn fire when hitting an enemy");
		}

	}
}
