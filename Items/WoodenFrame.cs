using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class WoodenFrame : ModItem
{

    public override void SetDefaults()
    {

        item.width = 34;
        item.height = 34;
        item.value = 120000;
        item.rare = 2;
        item.defense = 3;
        item.accessory = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Wooden Frame");
      Tooltip.SetDefault("");
    }


}}
