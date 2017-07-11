using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class BurningTome : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 7;
			item.melee = false;
			item.magic = true;
			item.width = 50;
			item.height = 55;
			item.useTime = 20;
			item.useAnimation = 20;
			item.mana = 6;
			item.useStyle = 5;
			//item.shoot = mod.ProjectileType("BurningTome");
			item.shoot = 376;
			item.shootSpeed = 26f;
			item.knockBack = 4;
			item.value = 12000;
			item.rare = 2;
			//item.UseSound = SoundID.Item9;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Burning Tome");
			Tooltip.SetDefault("");
		}

	}
}
