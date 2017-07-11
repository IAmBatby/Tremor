using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class BallnChain : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 44;

			item.value = 75000;
			item.rare = 3;
			item.accessory = true;
			item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ball n' Chain");
			Tooltip.SetDefault("Grants a spinning ball around the player");
		}


		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(mod.BuffType("BallnChainBuff"), 2);
		}
	}
}
