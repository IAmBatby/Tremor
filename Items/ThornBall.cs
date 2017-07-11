using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ThornBall : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 36;
			item.thrown = true;
			item.width = 18;
			item.height = 18;
			item.maxStack = 999;
			item.useTime = 14;
			item.useAnimation = 14;
			item.shoot = mod.ProjectileType("ThornBall");
			item.shootSpeed = 8f;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 155;
			item.rare = 5;
			item.consumable = true;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thorn Ball");
			Tooltip.SetDefault("");
		}

	}
}
