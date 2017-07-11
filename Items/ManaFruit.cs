using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ManaFruit : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 26;
			item.maxStack = 99;
			item.value = 250;
			item.rare = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mana Fruit");
			Tooltip.SetDefault("");
		}

	}
}
