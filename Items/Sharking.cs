using Terraria.ID;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tremor.Items
{
	public class Sharking : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 72;
			item.melee = true;
			item.width = 48;
			item.height = 48;
			item.useTime = 45;
			item.useAnimation = 35;
			item.useStyle = 1;
			item.knockBack = 7;
			item.shoot = 408;
			item.shootSpeed = 14f;
			item.value = 13570;
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sharking");
			Tooltip.SetDefault("");
		}

	}
}
