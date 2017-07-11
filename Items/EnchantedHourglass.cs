using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class EnchantedHourglass : ModItem
	{
		public override void SetDefaults()
		{

			item.melee = false;
			item.magic = true;
			item.width = 50;
			item.height = 55;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 30000;
			item.rare = 9;
			item.expert = true;
			item.UseSound = SoundID.Item4;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Hourglass");
			Tooltip.SetDefault("");
		}


		public override bool UseItem(Player player)
		{
			if (Main.player[Main.myPlayer].active && Main.player[Main.myPlayer].FindBuffIndex(mod.BuffType("HealthRecharging")) != -1)
			{
				item.mana = 0;
				item.healLife = 0;
			}
			else
			{
				player.AddBuff(mod.BuffType("HealthRecharging"), 1200, true);
				//item.mana = 50;
				item.healLife = 30;
			}
			return false;
		}
	}
}
