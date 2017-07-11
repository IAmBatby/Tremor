using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Pitchfork : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 22;
			item.width = 14;
			item.height = 84;
			item.noUseGraphic = true;
			item.melee = true;
			item.useTime = 25;
			item.shoot = mod.ProjectileType("PitchforkPro");
			item.shootSpeed = 3f;
			item.useAnimation = 25;
			item.useStyle = 5;
			item.knockBack = 4;
			item.value = 50000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pitchfork");
			Tooltip.SetDefault("");
		}

	}
}
