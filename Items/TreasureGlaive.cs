using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class TreasureGlaive : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 290;
        item.width = 18;
        item.height = 66;
        item.noUseGraphic = true;
        item.thrown = true;
        item.useTime = 30;
        item.shoot = mod.ProjectileType("TreasureGlaive");
        item.shootSpeed = 15f; 
        item.useAnimation = 30;
        item.useStyle = 1;
        item.knockBack = 4;
        item.value = 1000000;
        item.rare = 11;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Treasure Glaive");
      Tooltip.SetDefault("");
    }

}}
