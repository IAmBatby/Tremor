using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ThunderRay : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 24;
			item.width = 14;
			item.height = 84;
			item.magic = true;
			item.mana = 9;
			item.useTime = 26;
			item.shoot = 255;
			item.shootSpeed = 8f;
			item.useAnimation = 26;
			item.useStyle = 5;
			item.knockBack = 0;
			item.value = 2100;
			item.rare = 2;
			item.UseSound = SoundID.Item114;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thunder Ray");
			Tooltip.SetDefault("");
		}

	}
}
