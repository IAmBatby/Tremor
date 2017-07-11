using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class LivingTombstone : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Carrot);

			item.useTime = 25;
			item.useAnimation = 25;

			item.shoot = mod.ProjectileType("LivingTombstonePro");
			item.buffType = mod.BuffType("LivingTombstoneBuff");
			item.value = 500000;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Living Tombstone");
			Tooltip.SetDefault("Summons a living tombstone");
		}


		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}
