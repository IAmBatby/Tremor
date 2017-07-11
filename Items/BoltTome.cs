using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class BoltTome : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 26;
			item.melee = false;
			item.magic = true;
			item.width = 50;
			item.height = 55;
			item.useTime = 30;
			item.mana = 7;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.shoot = 645;
			item.shootSpeed = 20f;
			item.knockBack = 3;
			item.value = 30000;
			item.rare = 3;
			item.UseSound = SoundID.Item4;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bolt Tome");
			Tooltip.SetDefault("");
		}

	}
}
