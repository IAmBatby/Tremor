using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
[AutoloadEquip(EquipType.Head)]
	public class ZerokkHead : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;
			item.value = 30000;

			item.rare = 9;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Zerokk's Headgear");
      Tooltip.SetDefault("'Great for impersonating devs!'");
    }

		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("ZerokkBody") && legs.type == mod.ItemType("ZerokkLegs");
		}
	
		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true; //среднее пульсирование
			player.armorEffectDrawShadowLokis = true; //маленькие тени
		}
	}
}
