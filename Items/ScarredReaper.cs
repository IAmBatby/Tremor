using Terraria.ID;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tremor.Items {
public class ScarredReaper : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 60;
        item.melee = true;
        item.width = 48;
        item.height = 48;
        item.useTime = 25;
        item.shootSpeed = 10f;
        item.useAnimation = 25;
        item.useStyle = 1;
        item.knockBack = 3f;
        item.shoot = mod.ProjectileType("ScarredReaperPro");
        item.value = 200600;
        item.rare = 5;
        item.noUseGraphic = true;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Scarred Reaper");
      Tooltip.SetDefault("");
    }


public override bool CanUseItem(Player player)
{
    for (int i = 0; i < 1000; ++i)
    {
        if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
        {
            return false;
        }
    }
    return true;
}

}}
