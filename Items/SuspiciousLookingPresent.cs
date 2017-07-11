using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class SuspiciousLookingPresent : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 22;
			item.maxStack = 1;
			item.value = 10000;

			item.rare = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Suspicious Looking Present");
			Tooltip.SetDefault("Allows the Elf to move in");
		}

	}
}
