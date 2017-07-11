using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class PrimeBlade : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 52;
        item.melee = true;
        item.width = 40;
        item.height = 40;

        item.useTime = 20;
        item.useAnimation = 20;
        item.shoot = 503; 
        item.shootSpeed = 12f; 
        item.useStyle = 1;
        item.knockBack = 6;
        item.value = 60000;
        item.rare = 5;
        item.UseSound = SoundID.Item1;
        item.autoReuse = false;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Prime Blade");
      Tooltip.SetDefault("'Mechanical rage!'");
    }

}}
