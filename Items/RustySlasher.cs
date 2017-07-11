using Terraria.ID;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tremor.Items {
public class RustySlasher : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 16;
        item.melee = true;
        item.width = 42;
        item.height = 46;
        item.useTime = 13;
        item.useAnimation = 13;
        item.useStyle = 1;
        item.knockBack = 8;
        item.value = 10000;
        item.rare = 2;
        item.UseSound = SoundID.Item71;
        item.autoReuse = true;
        item.useTurn = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Rusty Slasher");
      Tooltip.SetDefault("");
    }

}}
