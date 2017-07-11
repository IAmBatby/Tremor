using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class BrassNugget : ModItem
{
    public override void SetDefaults()
    {

        item.width = 16;
        item.height = 16;
        item.maxStack = 99;
        item.value = 300;
        item.rare = 5;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Brass Nugget");
      Tooltip.SetDefault("");
    }

}}
