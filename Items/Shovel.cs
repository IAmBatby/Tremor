using Terraria.ID;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tremor.Items {
public class Shovel : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 24;
        item.melee = true;
        item.width = 46;
        item.height = 50;
        item.useTime = 15;
        item.useAnimation = 15;
        item.useStyle = 1;
        item.knockBack = 7;
        item.value = 121000;
        item.rare = 2;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Shovel");
      Tooltip.SetDefault("");
    }

}}
