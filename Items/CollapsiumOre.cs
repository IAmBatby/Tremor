using Terraria.ID;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Tremor.Items {
public class CollapsiumOre : ModItem
{
    public override void SetDefaults()
    {

        item.width = 30;
        item.height = 24;
        item.maxStack = 999;
        item.value = 12500;
        item.rare = 110;
        item.createTile = mod.TileType("CollapsiumOreTile");
        item.useTurn = true;
        item.autoReuse = true;
        item.useAnimation = 15;
        item.useTime = 10;
        item.useStyle = 1;
        item.consumable = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Collapsium Ore");
      Tooltip.SetDefault("");
    }


        public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> tooltips)
        {
            tooltips[0].overrideColor = new Color(238, 194, 73);
        }
}}
