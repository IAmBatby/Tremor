using Terraria.ID;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Tremor.Items
{
	public class GehennaStaff : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 455;
			item.magic = true;
			item.mana = 15;
			item.width = 46;
			item.height = 48;
			item.useTime = 45;
			item.useAnimation = 45;
			item.useStyle = 1;
			item.knockBack = 3;
			item.shoot = mod.ProjectileType("InfernoRift");
			item.shootSpeed = 12f;
			item.value = 600000;
			item.rare = 0;
			item.UseSound = SoundID.Item44;
			item.autoReuse = false;
			item.useTurn = false;

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gehenna Staff");
			Tooltip.SetDefault("Summons a controllable inferno rift that rapidly shoots molten bolts at nearby enemies");
		}


		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			player.channel = true;
			return true;
		}

		public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> tooltips)
		{
			tooltips[0].overrideColor = new Color(238, 194, 73);
		}
	}
}
