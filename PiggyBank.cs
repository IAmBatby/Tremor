using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using System.Linq;
using Terraria.ID;

namespace Tremor
{
	class PiggyBank : GlobalItem
	{
		public bool ManySimilarItems(Item item, Item[] inventory)
		{
			int count = inventory.ToList().Where(x => x.type == item.type).Count();
			return count >= 2;
		}

		public int GetSimilarItemsStack(Item item, Item[] inventory)
		{
			int stack = 0;
			for (int i = 0; i < inventory.Length; i++)
			{
				if (inventory[i].type == item.type)
				{
					stack += inventory[i].stack;
				}
			}
			return stack;
		}

		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			Player player = Main.player[Main.myPlayer];
			int[] coins = new int[]
			{
				ItemID.CopperCoin,
				ItemID.SilverCoin,
				ItemID.GoldCoin,
				ItemID.PlatinumCoin
			};
			if (item.type == ItemID.PiggyBank || item.type == ItemID.MoneyTrough)
			{
				foreach (Item myItem in player.bank.item)
				{
					if (!myItem.IsAir && coins.Contains(myItem.type))
					{
						if (!ManySimilarItems(myItem, player.bank.item))
						{
							tooltips.Add(new TooltipLine(mod, "", "[i/s1:" + myItem.type + " ]" + "" + " x" + myItem.stack + ""));
						}
						else if (!(tooltips.Where(tooltip => tooltip.text == "[i/s1:" + myItem.type + " ]" + "" + " x" + GetSimilarItemsStack(myItem, player.bank.item) + "").Count() > 0))
						{
							tooltips.Add(new TooltipLine(mod, "", "[i/s1:" + myItem.type + " ]" + "" + " x" + GetSimilarItemsStack(myItem, player.bank.item) + ""));
						}
					}
				}
			}
			if (item.type == ItemID.Safe)
			{
				foreach (Item myItem in player.bank2.item)
				{
					if (!myItem.IsAir && coins.Contains(myItem.type))
					{
						if (!ManySimilarItems(myItem, player.bank2.item))
						{
							tooltips.Add(new TooltipLine(mod, "", "[i/s1:" + "" + " ]" + "" + " x" + myItem.stack + ""));
						}
						else if (!(tooltips.Where(tooltip => tooltip.text == "[i/s1:" + myItem.type + " ]" + "" + " x" + GetSimilarItemsStack(myItem, player.bank2.item) + "").Count() > 0))
						{
							tooltips.Add(new TooltipLine(mod, "", "[i/s1:" + "" + " ]" + "" + " x" + GetSimilarItemsStack(myItem, player.bank2.item) + ""));
						}
					}
				}
			}
		}
	}
}
