using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class DesertSigil : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 34;

			item.rare = 5;
			item.accessory = true;
			item.value = 50000;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Desert Sigil");
			Tooltip.SetDefault("Summons a sigil to shoot your enemies");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(mod.BuffType("DesertSigilBuff"), 60, true);
		}
	}
}
