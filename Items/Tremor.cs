using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Tremor : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 210;
			item.melee = true;
			item.width = 70;
			item.height = 70;
			item.useTime = 18;
			item.useAnimation = 16;
			item.useStyle = 1;
			item.knockBack = 8;
			item.value = 67800;
			item.rare = 10;
			item.UseSound = SoundID.Item71;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Tremor");
			Tooltip.SetDefault("");
		}

	}
}
