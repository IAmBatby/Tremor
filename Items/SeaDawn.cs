using Terraria.ID;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tremor.Items
{
	public class SeaDawn : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 225;
			item.melee = true;
			item.width = 72;
			item.height = 72;
			item.useTime = 38;
			item.useAnimation = 38;
			item.useStyle = 1;
			item.shootSpeed = 12f;
			item.shoot = mod.ProjectileType("TyphoonPro");
			item.knockBack = 3;
			item.value = 33000;
			item.rare = 10;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sea Dawn");
			Tooltip.SetDefault("");
		}


	}
}
