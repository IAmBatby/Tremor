using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items {
public class CrimCudgel : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 16;
        item.melee = true;
        item.width = 40;
        item.height = 40;
        item.useTime = 30;
        item.useAnimation = 20;
        item.useStyle = 1;
        item.knockBack = 9;
        item.value = 36000;
        item.rare = 2;
        item.UseSound = SoundID.Item1;
        item.autoReuse = false;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Crimera Cudgel");
      Tooltip.SetDefault("");
    }

}}
