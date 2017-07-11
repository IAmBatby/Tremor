using Terraria.ID;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	//ported from my tAPI mod because I don't want to make more artwork
	public class BlackRose : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 16;
			item.magic = true;
			item.width = 20;
			item.height = 12;
			item.useTime = 7;
			item.useAnimation = 28;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = Item.buyPrice(0, 5, 0, 0);
			item.rare = 3;
			item.mana = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("BlackRosePro");
			item.shootSpeed = 30f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Black Rose");
			Tooltip.SetDefault("");
		}

	}
}
