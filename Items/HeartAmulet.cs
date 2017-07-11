using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
    public class HeartAmulet : ModItem
    {
        public override void SetDefaults()
        {

            item.width = 36;
            item.height = 44;
            item.value = 1000;
            item.rare = 4;

            item.accessory = true;
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Heart Amulet");
      Tooltip.SetDefault("You respawn with 80% of maximum health after death");
    }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            TremorPlayer modPlayer = (TremorPlayer)player.GetModPlayer(mod, "TremorPlayer");
            modPlayer.heartAmulet = true;
        }
    }
}
