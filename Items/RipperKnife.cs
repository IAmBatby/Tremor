using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class RipperKnife : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 6;
        item.melee = true;
        item.width = 32;
        item.height = 32;
        item.useTime = 9;
        item.useAnimation = 9;
        item.useStyle = 3;
        item.knockBack = 2;
        item.value = 600;
        item.rare = 1;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Ripper Knife");
      Tooltip.SetDefault("");
    }

}}
