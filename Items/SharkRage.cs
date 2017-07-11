using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class SharkRage : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 46;
			item.magic = true;
			item.mana = 10;
			item.width = 54;
			item.height = 54;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = 40000;
			item.rare = 5;
			item.UseSound = SoundID.Item43;
			item.autoReuse = true;
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
			item.shoot = 408;
			item.shootSpeed = 15f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shark Rage");
			Tooltip.SetDefault("");
		}

	}
}
