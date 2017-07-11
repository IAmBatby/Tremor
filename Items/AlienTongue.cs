using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class AlienTongue : ModItem
{
    public override void SetDefaults()
    {

        item.width = 14;
        item.height = 22;
        item.maxStack = 999;
        item.rare = 11;

        item.value = Item.buyPrice(0, 10, 0, 0);
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Alien Tongue");
      Tooltip.SetDefault("'Extraterrestrial abomination'");
    }

}}
