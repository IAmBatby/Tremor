using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class LightningTome : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 15;
			item.melee = false;
			item.magic = true;
			item.width = 50;
			item.height = 55;
			item.useTime = 14;
			item.mana = 7;
			item.useAnimation = 14;
			item.useStyle = 5;
			item.shoot = mod.ProjectileType("LightningTome");
			item.shootSpeed = 12f;
			item.knockBack = 4;
			item.value = 50000;
			item.rare = 3;
			item.UseSound = SoundID.Item9;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lightning Tome");
			Tooltip.SetDefault("");
		}

	}
}
