using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class StormBlade : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 25;
        item.melee = true;
        item.width = 50;
        item.height = 52;
        item.useTime = 25;
        item.useAnimation = 25;
        item.useStyle = 1;
        item.shoot = mod.ProjectileType("StormBladePro");
        item.shootSpeed = 10f; 
        item.knockBack = 4;
        item.value = 30000;
        item.rare = 3;
        item.UseSound = SoundID.Item1;
        item.autoReuse = false;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Storm Blade");
      Tooltip.SetDefault("");
    }



    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 15);
    }
}
}
