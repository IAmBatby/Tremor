using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{ 
[AutoloadEquip(EquipType.Body)]
	public class ReaperBreastplate : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 18;
			item.height = 18;
			item.value = 10000;

			item.rare = 5;
			item.defense = 9;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Reaper Breastplate");
      Tooltip.SetDefault("Increases alchemic damage by 15%");
    }


		public override void UpdateEquip(Player player)
		{
        player.GetModPlayer<MPlayer>(mod).alchemistDamage += 0.15f;
		}

	}
}
