using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class BicholmereSpear : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 20;
        item.width = 14;
        item.height = 84;
        item.noUseGraphic = true;
        item.thrown = true;
        item.useTime = 30;
        item.shoot = mod.ProjectileType("BicholmereSpearPro");
        item.shootSpeed = 15f; 
        item.useAnimation = 30;
        item.useStyle = 1;
        item.knockBack = 4;
        item.value = 1000;
        item.rare = 2;
        item.UseSound = SoundID.Item5;
        item.autoReuse = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Bicholmere Spear");
      Tooltip.SetDefault("");
    }

}}
