using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class PieceofFlesh : ModItem
{
    public override void SetDefaults()
    {

        item.width = 30;
        item.height = 24;
        item.maxStack = 99;
        item.value = 100;
        item.rare = 4;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Piece of Flesh");
      Tooltip.SetDefault("");
    }

}}
