using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class SporeBlade : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 82;
        item.melee = true;
        item.width = 50;
        item.height = 55;
        item.useTime = 35;
        item.useAnimation = 25;
        item.useStyle = 1;
        item.shoot = 228;
        item.shootSpeed = 20f; 
        item.knockBack = 4;
        item.value = 50000;
        item.rare = 6;
        item.UseSound = SoundID.Item1;
        item.autoReuse = false;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Spore Blade");
      Tooltip.SetDefault("");
    }

}
}
