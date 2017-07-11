using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class FrostKingTrophy : ModItem
{
    public override void SetDefaults()
    {

        item.width = 32;
        item.height = 32;
        item.maxStack = 99;
        item.useTurn = true;
        item.autoReuse = true;
        item.useAnimation = 15;
        item.useTime = 10;
        item.useStyle = 1;
        item.consumable = true;
        item.value = 50000;
        item.createTile = mod.TileType("FrostKingTrophy");
        item.placeStyle = 0;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Frost King Trophy");
      Tooltip.SetDefault("");
    }

}}
