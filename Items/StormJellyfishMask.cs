using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items { [AutoloadEquip(EquipType.Head)]
public class StormJellyfishMask : ModItem
{



    public override void SetDefaults()
    {

        item.width = 36;
        item.height = 24;
        item.rare = 1;
        item.vanity = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Storm Jellyfish Mask");
      Tooltip.SetDefault("");
    }

}}
