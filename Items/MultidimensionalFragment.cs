using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class MultidimensionalFragment : ModItem
{

    public override void SetDefaults()
    {

        item.width = 22;
        item.height = 22;
        item.rare = 11;
        item.maxStack = 999;
        ItemID.Sets.ItemNoGravity[item.type] = true;
        ItemID.Sets.ItemIconPulse[item.type] = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Multidimensional Fragment");
      Tooltip.SetDefault("");
	  Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 12));
    }

}}
