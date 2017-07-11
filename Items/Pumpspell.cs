using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Pumpspell : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 26;
			item.magic = true;
			item.width = 28;
			item.height = 30;
			item.useTime = 14;
			item.useAnimation = 14;
			item.shoot = mod.ProjectileType("PumpkinPro");
			item.shootSpeed = 10f;
			item.noUseGraphic = true;
			item.mana = 16;
			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 66666;
			item.rare = 4;
			item.UseSound = SoundID.Item21;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pumpspell");
			Tooltip.SetDefault("");
		}

	}
}
