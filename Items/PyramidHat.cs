using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items { [AutoloadEquip(EquipType.Head)]
public class PyramidHat : ModItem
{


    public override void SetDefaults()
    {

        item.width = 26;
        item.height = 24;
        item.rare = 2;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Pyramid Hat");
      Tooltip.SetDefault("");
    }


}}
