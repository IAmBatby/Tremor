using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Vertebrow : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 15;
			item.width = 16;
			item.height = 32;
			item.useTime = 30;
			item.ranged = true;
			item.shoot = 1;
			item.shootSpeed = 12f;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.knockBack = 8;
			item.value = 540;
			item.useAmmo = AmmoID.Arrow;
			item.rare = 1;
			item.UseSound = SoundID.Item5;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vertebrow");
			Tooltip.SetDefault("");
		}

	}
}
